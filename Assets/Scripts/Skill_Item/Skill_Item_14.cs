using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_14 : Skill_Item_Ori
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
        StartCoroutine(Func());
    }
    IEnumerator Func()
    {
        while (true)
        {
            MainSingleton.instance.playerstat.Shiled();
            SoundManager.inst.SoundPlay(23);
            CoolTimesystem.NextFunc(info.Real1);
            // 보호막 액션
            yield return new WaitForSeconds(info.Real1);

        }
    }


}
