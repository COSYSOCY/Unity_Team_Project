using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_18 : Skill_Item_Ori
{
    public GameObject efffectOb;
    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2������ �ɰ�� ����
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
        StartCoroutine(func());
    }

    IEnumerator func()
    {
        yield return null;
        while (true)
        {
            float f = info.Real2;
            playerinfo.BounsDmg +=f;
            // �׼�
            efffectOb.SetActive(true);
            yield return new WaitForSeconds(10f);
            playerinfo.BounsDmg -=f;
            efffectOb.SetActive(false);
            //�׼�
            yield return new WaitForSeconds(info.Real1-10);
        }
    }

}
