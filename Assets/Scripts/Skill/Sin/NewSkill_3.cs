using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_3 : Skill_Ori
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
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 0;
        float local = _AtRange();
        List<Collider> Enemys;
        Vector3 endpos;
        Enemys = Physics.OverlapSphere(gameObject.transform.position, 30f, layermask).ToList();

        if (Enemys.Count >0)
        {
            for (int i = 0; i < _BulletCnt(); i++)
            {

                GameObject target;
                int ran=Random.Range(0, Enemys.Count-1);
                target = Enemys[ran].gameObject;


                GameObject laser = ObjectPooler.SpawnFromPool("Bullet_3", pos, Quaternion.identity);
                laser.transform.localScale = new Vector3(local, local, local);
                Vector3 d = target.transform.position - Player.transform.position;
                d.Normalize();
                endpos = d * 50;
                laser.GetComponent<LineRenderer>().SetPosition(0, Player.transform.position);
                laser.GetComponent<LineRenderer>().SetPosition(1, endpos);

                RaycastHit[] Rhits = Physics.SphereCastAll(Player.transform.position, laser.transform.lossyScale.x, d,layermask);

                if (Rhits.Length > 0)
                {
                    for (int s = 0; s < Rhits.Length; s++)
                    {
                        if (Rhits[i].transform.gameObject.activeSelf)
                        {
                            Rhits[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
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
