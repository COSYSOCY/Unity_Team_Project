using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_13 : Skill_Item_Ori
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


}
