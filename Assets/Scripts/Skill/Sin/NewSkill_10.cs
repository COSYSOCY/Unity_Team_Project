using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_10 : Skill_Ori
{
    float Radius;
    public GameObject bullet;
    float UpRange = 1f;
    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject, info.Skill_Icon);

        LevelUp();
        StartCoroutine(Skill_Update());
        bullet.SetActive(true);

        //

        Radius = 5.5f; // 거리

        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {
        UpRange = 3f;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
    }
    float damage()
    {
        float d = _Damage();
        int i = GameInfo.inst.PlayerCardCheck[19];
        //GameInfo.inst.CardsInfo[17].CardStat_Real1
        float d_C = 0;
        float d_P = i * GameInfo.inst.CardsInfo[19].CardStat_Real1;
        d = d + d_C;
        d = d + (d * d_P * 0.01f);

        return d;
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
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(17);
            StartCoroutine(Skill_Update2());
            yield return new WaitForSeconds(_BulletTime());


        }
    }

    IEnumerator Skill_Update2()
    {
        float local = _AtRange();
        for (int i = 0; i < _BulletCnt(); i++)
        {
            float angle = i * Mathf.PI * 2 / _BulletCnt();
            float x = Mathf.Cos(angle) * Radius;
            float z = Mathf.Sin(angle) * Radius;
            Vector3 pos = bullet.transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            //par = Instantiate(BulletD, pos, rot);
            GameObject par = ObjectPooler.SpawnFromPool("Bullet_10", pos, rot);

            par.transform.localScale = new Vector3(local * UpRange, local * UpRange, local * UpRange);
            par.transform.parent = bullet.gameObject.transform;// 기도문 오브젝트아래 자식객체로 큐브생성
            par.GetComponent<Bullet_Info>().damage = damage();
            par.GetComponent<Bullet_Info>().pie = _BulletPie();
            par.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
        }
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
