using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_1 : Skill_Item_Ori
{
    public override void StartFunc()
    {
        LevelUp();
        playerinfo.SkillItemCnt++;
        manager.Skill_All_Active.Add(gameObject);
        manager.Skill_Item_Active.Add(gameObject);
    }


}
