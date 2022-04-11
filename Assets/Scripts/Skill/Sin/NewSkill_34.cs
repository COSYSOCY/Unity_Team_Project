using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_34 : Skill_Ori
{


    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }
    }


    void Start_Func()
    {
        LevelUp();
        manager.skill_Add(gameObject, info.Skill_Icon);
        StartCoroutine(Skill_Update());
        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {
        CreateUp = true;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
    }
    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(16);
            StartCoroutine(Skill_Update2());
        }
    }

    IEnumerator Skill_Update2()
    {

        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();
        List<Collider> Enemys;
        Enemys = Physics.OverlapSphere(pos, 30f, layermask).ToList();
        Enemys.Sort(delegate (Collider t1, Collider t2) {
            return ((t1.transform.position - Player.transform.position).magnitude).CompareTo((t2.transform.position - Player.transform.position).magnitude);
        });

        if (Enemys.Count > 0)
        {
            for (int i = 0; i < _BulletCnt(); i++)
            {

                GameObject target = Enemys[0].gameObject;

                Vector3 dir = target.transform.position - Player.transform.position;
                dir.Normalize();
                dir.y = 0;
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_34", Player.transform.position, Quaternion.LookRotation(dir));
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                bullet.GetComponent<Bullet_Trigger_9>().CurTime = _BulletTime();
                bullet.GetComponent<Bullet_Trigger_9>().StartFunc();
                bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
                bullet.GetComponent<Bullet_Info>().Up = CreateUp;
                bullet.GetComponent<Bullet_Info>().real1 = _BulletTime();
                bullet.GetComponent<Bullet_Info>().real2 = local;
                bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                bullet.transform.localScale = new Vector3(local , local , local );
                yield return new WaitForSeconds(0.2f);
            }
        }

    }


    private void OnEnable()
    {
        if (start == false && info.goodstart)
        {
            Start_Func();
            start = true;
        }
    }

}
