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
    protected SkillCoolTimeSystem CoolTimesystem;
    public bool NoCoolUi = true;
    public void LevelUp()
    {

        MainSingleton.instance.playerstat.SkillItemactive[info.Index]++;
        info.Lv++;
        if (info.Lv >= info.LvMax)
        {
            info.Lv = info.LvMax;
        }

        info.HpPlusC=info.HpPlusCCheck[info.Lv - 1];
        info.HpPlusPer = info.HpPlusPerCheck[info.Lv - 1];
        info.HpRegen = info.HpRegenCheck[info.Lv - 1];
        info.Defence = info.DefenceCheck[info.Lv - 1];
        info.AtPlus = info.AtPlusCheck[info.Lv - 1];
        info.Cool = info.CoolCheck[info.Lv - 1];
        info.AtRange = info.AtRangeCheck[info.Lv - 1];
        info.Speed = info.SpeedCheck[info.Lv - 1];
        info.BulletCnt = info.BulletCntCheck[info.Lv - 1];
        info.GoldPlus = info.GoldPlusCheck[info.Lv - 1];
        info.XpPlus = info.XpPlusCheck[info.Lv - 1];
        info.BulletSpeed = info.BulletSpeedCheck[info.Lv - 1];
        info.BulletTime = info.BulletTimeCheck[info.Lv - 1];
        info.Range = info.RangeCheck[info.Lv - 1];
        info.Real1 = info.Real1Check[info.Lv - 1];
        info.Real2 = info.Real2Check[info.Lv - 1];

        info.Pie = info.PieCheck[info.Lv - 1];
        info.DmgPer = info.DmgPerCheck[info.Lv - 1];

        if (info.HpPlusC+ info.HpPlusPer > 0)
        {
            stat.PlayerHpMax();
        }
        if (info.Range > 0)
        {
            MainSingleton.instance.pullrange.Check();
        }
        LevelUpFunc();
        if (CoolTimesystem == null)
        {
            CoolTimesystem = MainSingleton.instance.CoolTimeSystem_Item[manager.Skill_Item_Active.Count];
            CoolTimesystem.startFUnc(info.Skill_Icon, NoCoolUi);
        }
    }
    public virtual void LevelUpFunc()
    {

    }
    public virtual void CreateFunc()
    {
        manager.FoucsOb[info.ActiveIdx+6].SetActive(true);
    }
    public virtual void StartFunc()
    {
        //Debug.Log("¤±¤¤¤·");
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
