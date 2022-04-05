using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_Ori : MonoBehaviour
{
    public PlayerInfo playerinfo;
    public PlayerStatus stat;
    public Skill_ItemInfo info;
    protected bool startcheck = false;
    public SkillManager manager;
    public void LevelUp()
    {

        MainSingleton.instance.playerstat.SkillItemactive[info.Index]++;
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
        info.Range = info.RangeCheck[info.Lv];
        info.Real1 = info.Real1Check[info.Lv];
        info.Real2 = info.Real2Check[info.Lv];

        if (info.HpPlusC+ info.HpPlusPer > 0)
        {
            stat.PlayerHpMax();
        }
        if (info.Range > 0)
        {
            MainSingleton.instance.pullrange.Check();
        }
        LevelUpFunc();
    }
    public virtual void LevelUpFunc()
    {

    }
    public virtual void CreateFunc()
    {
        manager.FoucsOb[info.ActiveIdx+5].SetActive(true);
    }
    public virtual void StartFunc()
    {
        LevelUp();
        if (MainSingleton.instance.playerstat.Skillactive[info.CreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill[info.CreateIdx].GetComponent<Skill_Ori>().CreateFunc();
            CreateFunc();
        }
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
