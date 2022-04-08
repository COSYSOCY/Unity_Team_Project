using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_17 : Skill_Ori
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
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
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
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();

        for (int i = 0; i < _BulletCnt(); i++)
        {
            SoundManager.inst.SoundPlay(8);

            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_17", Player.transform.position, Quaternion.Euler(new Vector2(0,Random.Range(0,360f))));
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
            bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
            bullet.GetComponent<Bullet_Info>().KnokTime=_BulletTime();
            bullet.GetComponent<Bullet_Info>().real1=local;
            bullet.transform.localScale = new Vector3(local, local, local);
            yield return new WaitForSeconds(0.1f);
        }
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
