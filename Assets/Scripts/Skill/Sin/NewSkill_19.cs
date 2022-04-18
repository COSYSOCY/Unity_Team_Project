using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_19 : Skill_Ori
{


    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());


        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
        CreateUp = true;
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }
        if (info.Lv == 8) // 8레벨이 될경우 실행
        {
            //8 레벨 획득
            if (GameInfo.inst.Player_Mission[27] == 0)
            {
                GameInfo.inst.MissionGo(27);
            }
        }
    }

    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(21);
            if (CreateUp)
            {

            StartCoroutine(Skill_Update3());
            }
            else
            {

            StartCoroutine(Skill_Update2());
            }



        }
    }




    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();



            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_19", pos, Quaternion.Euler(new Vector3(0,0,0)));
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
            bullet.GetComponent<Bullet_Info>().KnokTime = 0.1f;
            bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
            bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
            bullet.transform.localScale = new Vector3(local, local, local);
            GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_19", pos, Quaternion.Euler(new Vector3(0, 180, 0)));
            bullet2.GetComponent<Bullet_Info>().damage = _Damage();
            bullet2.GetComponent<Bullet_Info>().pie = _BulletPie();
            bullet2.GetComponent<Bullet_Info>().KnokTime = 0.1f;
            bullet2.GetComponent<Bullet_Info>().move = _BulletSpeed();
            bullet2.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
            bullet2.transform.localScale = new Vector3(local, local, local);
            yield return null;
    }
    IEnumerator Skill_Update3()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();



        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_19", pos, Quaternion.Euler(new Vector3(0, 0, 0)));
        bullet.transform.Translate(new Vector3(0,0,1));
        bullet.GetComponent<Bullet_Info>().damage = _Damage();
        bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
        bullet.GetComponent<Bullet_Info>().KnokTime = 0.1f;
        bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
        bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
        bullet.transform.localScale = new Vector3(local, local, local);
        GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_19", pos, Quaternion.Euler(new Vector3(0, 180, 0)));
        bullet2.GetComponent<Bullet_Info>().damage = _Damage();
        bullet2.GetComponent<Bullet_Info>().pie = _BulletPie();
        bullet2.GetComponent<Bullet_Info>().KnokTime = 0.1f;
        bullet2.GetComponent<Bullet_Info>().move = _BulletSpeed();
        bullet2.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
        bullet2.transform.localScale = new Vector3(local, local, local);
        bullet2.transform.Translate(new Vector3(0, 0, 1));


        GameObject bullet3 = ObjectPooler.SpawnFromPool("Bullet_19", pos, Quaternion.Euler(new Vector3(0, 0, 0)));
        bullet3.transform.Translate(new Vector3(2, 0, 0));
        bullet3.GetComponent<Bullet_Info>().damage = _Damage();
        bullet3.GetComponent<Bullet_Info>().pie = _BulletPie();
        bullet3.GetComponent<Bullet_Info>().KnokTime = 0.1f;
        bullet3.GetComponent<Bullet_Info>().move = _BulletSpeed();
        bullet3.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
        bullet3.transform.localScale = new Vector3(local, local, local);
        GameObject bullet4 = ObjectPooler.SpawnFromPool("Bullet_19", pos, Quaternion.Euler(new Vector3(0, 180, 0)));
        bullet4.GetComponent<Bullet_Info>().damage = _Damage();
        bullet4.GetComponent<Bullet_Info>().pie = _BulletPie();
        bullet4.GetComponent<Bullet_Info>().KnokTime = 0.1f;
        bullet4.GetComponent<Bullet_Info>().move = _BulletSpeed();
        bullet4.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
        bullet4.transform.localScale = new Vector3(local, local, local);
        bullet4.transform.Translate(new Vector3(-2, 0, 0));



        yield return null;
    }
    private void OnEnable() // 중복방지용 버그처리용스크립트인데 신경쓰지마세요
    {
        if (start == false && info.goodstart)
        {
            Start_Func();
            start = true;
        }
    }
}
