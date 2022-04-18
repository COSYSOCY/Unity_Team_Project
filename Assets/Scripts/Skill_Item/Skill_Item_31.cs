using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_31 : Skill_Item_Ori
{
    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }
    }
    public override void StartFunc()
    {
        manager.skill_item_Add(gameObject, info.Skill_Icon);
        LevelUp();
        if (MainSingleton.instance.playerstat.Skillactive[info.CreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill[info.CreateIdx].GetComponent<Skill_Ori>().CreateFunc();
            CreateFunc();
        }
        CoolTimesystem.SetCoolint(0, 50);
    }

    public void Func()
    {
        int i = (int)info.Real1;
        float HpPlus = info.Real2;
        CoolTimesystem.SetCoolint(MainSingleton.instance.playerinfo.Kill % i, i);
        if (MainSingleton.instance.playerinfo.Kill % i == 0)
        {
            GameObject bullet = ObjectPooler.SpawnFromPool("itemEffect_16", MainSingleton.instance.Player.transform.position, Quaternion.identity);
            MainSingleton.instance.playerstat.HpPlus(HpPlus);
        }
    }


}
