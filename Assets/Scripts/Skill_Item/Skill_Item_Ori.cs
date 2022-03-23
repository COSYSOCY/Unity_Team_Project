using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_Ori : MonoBehaviour
{
    public PlayerInfo playerinfo;
    public Skill_ItemInfo info;
    protected bool startcheck = false;
    public SkillManager manager;
    public void LevelUp()
    {
        

        info.Lv++;
        info.HpPlusC=info.HpPlusCCheck[info.Lv];
        info.HpPlusPer = info.HpPlusPerCheck[info.Lv];
        info.HpRegen = info.HpRegenCheck[info.Lv];
        info.Defence = info.DefenceCheck[info.Lv];
        info.AtPlus = info.AtPlusCheck[info.Lv];
        info.Cool = info.CoolCheck[info.Lv];
        info.AtRange = info.AtRangeCheck[info.Lv];
        info.Speed = info.SpeedCheck[info.Lv];
        info.BulletCnt = info.BulletCntCheck[info.Lv];
        info.GoldPlus = info.GoldPlusCheck[info.Lv];
        info.XpPlus = info.XpPlusCheck[info.Lv];
        info.BulletSpeed = info.BulletSpeedCheck[info.Lv];
        info.BulletTime = info.BulletTimeCheck[info.Lv];
        info.Real1 = info.Real1Check[info.Lv];
        info.Real2 = info.Real2Check[info.Lv];


}

    public virtual void StartFunc()
    {
        LevelUp();
    }
    protected void OnEnable()
    {
        if (!startcheck&&info.goodstart)
        {
            startcheck=true;
            StartFunc();
        }
    }
}
