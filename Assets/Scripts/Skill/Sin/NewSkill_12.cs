using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_12 : Skill_Ori
{

    string bulletname = "Bullet_12";
    int Uppie = 0;
    float UpScale=0;
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
        bulletname = "Bullet_12_1";
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
        Uppie = 999;
        UpScale = 2;
    }
    float damage()
    {
        float d = _Damage();
        int i = GameInfo.inst.PlayerCardCheck[37];
        //GameInfo.inst.CardsInfo[17].CardStat_Real1
        float d_C = 0;
        float d_P = i * GameInfo.inst.CardsInfo[37].CardStat_Real1;
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
        if (info.Lv == 8) // 8레벨이 될경우 실행
        {
            //8 레벨 획득
            if (GameInfo.inst.Player_Mission[20] == 0)
            {
                GameInfo.inst.MissionGo(20);
            }
        }

    }
    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            yield return StartCoroutine(Skill_Update2());
            
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange()+ UpScale;

            for (int i = 0; i < _BulletCnt(); i++)
            {
            SoundManager.inst.SoundPlay(26);

            GameObject bullet = ObjectPooler.SpawnFromPool(bulletname, Player.transform.position, Quaternion.Euler(new Vector2(0,Random.Range(0,360f))));
                bullet.GetComponent<Bullet_Info>().damage = damage();
                bullet.GetComponent<Bullet_Info>().pie = _BulletPie()+Uppie;
                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
                bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                bullet.transform.localScale = new Vector3(local, local, local);
                yield return new WaitForSeconds(0.1f);
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
