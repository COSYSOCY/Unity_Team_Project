using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkill_15 : Skill_Ori
{
    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject,info.Skill_Icon);
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
            yield return StartCoroutine(Skill_Update2());
        }
    }
    IEnumerator Skill_Update2()
    {
        float Sp = 50;
        MainSingleton.instance.playerinfo.Speed += Sp;
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = bulletPos.transform.position;
            pos.y = 0;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_15", pos, Quaternion.identity);
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie() ;
            bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
            yield return new WaitForSeconds(0.5f);
        }
        MainSingleton.instance.playerinfo.Speed -= Sp;

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
