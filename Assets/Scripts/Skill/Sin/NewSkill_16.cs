using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_16 : Skill_Ori
{
    float Upscale = 0;
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
        Upscale = 2f;
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv==2) // 2레벨이 될경우 실행
        {

        }
        if (info.Lv == 8) // 8레벨이 될경우 실행
        {
            //8 레벨 획득
            if (GameInfo.inst.Player_Mission[24] == 0)
            {
                GameInfo.inst.MissionGo(24);
            }
        }
    }
    float damage()
    {
        float d = _Damage();
        int i = GameInfo.inst.PlayerCardCheck[58];
        //GameInfo.inst.CardsInfo[17].CardStat_Real1
        float d_C = 0;
        float d_P = i * GameInfo.inst.CardsInfo[58].CardStat_Real1;
        d = d + d_C;
        d = d + (d * d_P * 0.01f);

        return d;
    }
    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {
        
        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(28);
            StartCoroutine(Skill_Update2());
        }
    }
    Vector3 RandomPos()
    {
        float x = Random.Range(-11f, 11f);
        float z = Random.Range(-17f, 26f);
        Vector3 pos = new Vector3(Player.transform.position.x + x,1, Player.transform.position.z+z) ;
        return pos;
    }
    IEnumerator Skill_Update2()
    {

        float local = _AtRange()+ Upscale+1;

        for (int z = 0; z < _BulletCnt(); z++)
        {

        Collider[] Enemys;
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_16", RandomPos(), Quaternion.identity);
        bullet.transform.localScale = new Vector3(local, local, local);
        Enemys = Physics.OverlapSphere(bullet.transform.position, bullet.transform.lossyScale.x, layermask);
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                    if (Enemys[i].transform.CompareTag("DeOb"))
                    {
                        Enemys[i].transform.GetComponent<DeObjectSystem>().Damaged(_Damage());
                    }
                    else
                    {

                    Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(damage());
                    }
            }
        }

        yield return null;

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
