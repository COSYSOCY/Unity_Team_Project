using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_2 : Skill_Item_Ori
{
    public override void StartFunc()
    {
        LevelUp();
        manager.skill_item_Add(gameObject, info.Skill_Icon);

    }


}
