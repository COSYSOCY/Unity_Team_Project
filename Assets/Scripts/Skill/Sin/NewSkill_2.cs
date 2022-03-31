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
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 0;
        float local = _AtRange();
        List<Collider> Enemys;
        Enemys = Physics.OverlapSphere(gameObject.transform.position, 30f, layermask).ToList();
        Enemys.Sort(delegate (Collider t1, Collider t2) {
            return ((t1.transform.position - Player.transform.position).magnitude).CompareTo((t2.transform.position - Player.transform.position).magnitude);
        });

        if (Enemys.Count >0)
        {
            for (int i = 0; i < _BulletCnt(); i++)
            {

                GameObject target;
                if (i >= Enemys.Count)
                {
                    target = Enemys[0].gameObject;
                }
                else
                {
                    target = Enemys[i].gameObject;
                }

                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_2", pos, Quaternion.identity);
                bullet.transform.LookAt(target.transform);
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
                StartCoroutine(bullet.GetComponent<Bullet_Info>().DeadObj(_BulletTime()));
                bullet.transform.localScale = new Vector3(local, local, local);
                yield return new WaitForSeconds(0.1f);
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
