using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_34 : Skill_Item_Ori
{
    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2������ �ɰ�� ����
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
    }


}
