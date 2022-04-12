using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_7 : Skill_Ori
{
    float Upscale = 0f;
    int Upcnt = 0;

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }
    }


    void Start_Func()
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
        //Upscale = 4f;
        Upcnt = 2;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
    }
    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(14);
            StartCoroutine(Skill_Update2());
        }
    }
    float Range()
    {
        float d = _AtRange();
        int i = GameInfo.inst.PlayerCardCheck[20];
        //GameInfo.inst.CardsInfo[17].CardStat_Real1
        float d_C = 0;
        float d_P = i * GameInfo.inst.CardsInfo[20].CardStat_Real1;
        d = d + d_C;
        d = d + (d * d_P * 0.01f);

        return d;
    }
    IEnumerator Skill_Update2()
    {
        
        float local = Range()+ Upscale;

        float f1 = 0f;
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        for (int i = 1; i <= _BulletCnt()+ Upcnt; i++)
        {
            float ff = 0f;

            
            if (i % 2 == 0)
            {
                pos = bulletPos.transform.position;
                pos.y = 1;
                if (Player.transform.rotation.eulerAngles.y >= 180)
                {
                    ff = 1f;
                }
                else
                {
                    ff = -1f;
                }
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(4f*ff, 0f, f1), Quaternion.Euler(new Vector3(0, 80f, 0)));
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                bullet.GetComponent<Bullet_Info>().KnokTime = 0.1f;
                bullet.transform.localScale = new Vector3(local, 2, local);
                yield return new WaitForSeconds(0.15f);
                f1 += 3f;
            }
            else
            {
                pos = bulletPos.transform.position;
                pos.y = 1;
                if (Player.transform.rotation.eulerAngles.y >= 180)
                {
                    ff = -1f;
                }
                else
                {
                    ff = 1f;
                }

                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(4f * ff, 0f, f1), Quaternion.Euler(new Vector3(0, -80f, 0)));

                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                bullet.GetComponent<Bullet_Info>().KnokTime = 0.1f;
                bullet.transform.localScale = new Vector3(local, 2, local);
                yield return new WaitForSeconds(0.15f);
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
