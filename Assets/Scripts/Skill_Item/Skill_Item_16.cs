using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_16 : Skill_Item_Ori
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
        LevelUp();
        manager.skill_item_Add(gameObject, info.Skill_Icon);
        if (MainSingleton.instance.playerstat.Skillactive[info.CreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill[info.CreateIdx].GetComponent<Skill_Ori>().CreateFunc();
            CreateFunc();
        }
    }

    public void Func()
    {
        int i= (int)info.Real1;
        float HpPlus= info.Real2;
        if (MainSingleton.instance.playerinfo.Kill %i==0)
        {
            GameObject bullet = ObjectPooler.SpawnFromPool("itemEffect_16", MainSingleton.instance.Player.transform.position, Quaternion.identity);
            MainSingleton.instance.playerstat.HpPlus(HpPlus);
        }
    }
}
