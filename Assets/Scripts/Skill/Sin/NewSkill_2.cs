using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_2 : Skill_Ori
{
    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject,info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv==2) // 2레벨이 될경우 실행
        {

        }
        
    }

    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {
        
        while (true)
        {
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());
            SoundManager.inst.SoundPlay(7);
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();
        List<Collider> Enemys;
        Vector3 endpos;
        Enemys = Physics.OverlapSphere(pos, 30f, layermask).ToList();

        if (Enemys.Count >0)
        {
            for (int i = 0; i < _BulletCnt(); i++)
            {

                GameObject target;
                int ran=Random.Range(0, Enemys.Count);
                target = Enemys[ran].gameObject;


                
                
                GameObject laser = ObjectPooler.SpawnFromPool("Bullet_2", pos, Quaternion.identity);
                laser.transform.localScale = new Vector3(local, local, local);
                Vector3 d = (target.transform.position - laser.transform.position).normalized;



                endpos = target.transform.position+(d * 30);
                endpos.y = 1f;

                laser.GetComponent<LineRenderer>().SetPosition(0, pos);
                laser.GetComponent<LineRenderer>().SetPosition(1, endpos);
                RaycastHit[] Rhits = Physics.SphereCastAll(pos, laser.transform.lossyScale.x,d,30f,layermask);

                if (Rhits.Length > 0)
                {
                    for (int s = 0; s < Rhits.Length; s++)
                    {
                      
                        if (Rhits[s].transform.gameObject.activeSelf)
                        {
                            Rhits[s].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
                        }
                    }
                }



                
                if (Enemys.Count != 1)
                {
                    Enemys.RemoveAt(ran);
                    yield return new WaitForSeconds(0.1f);
                }
                
            }
        }
        
    }

    private void OnEnable() // 중복방지용 버그처리용스크립트인데 신경쓰지마세요
    {
        if (start==false&&info.goodstart)
        {
        Start_Func();
            start = true;
        }
    }

}
