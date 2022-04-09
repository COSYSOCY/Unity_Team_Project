using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Item_17 : Skill_Item_Ori
{
    int Cnt;
    public LayerMask layermask;
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
        Cnt = 0;
    }

    public void Func()
    {
        int i = (int)info.Real2;
        float t = (int)info.Real1;
        float s = 3;
        Cnt++;
        if (Cnt>=i)
        {
            Vector3 pos = MainSingleton.instance.Player.transform.position;
            pos.y = 1f;
            Collider[] Enemys;
            GameObject bullet = ObjectPooler.SpawnFromPool("itemEffect_17", pos, Quaternion.Euler(new Vector3(-90,0,0)));
            Enemys = Physics.OverlapSphere(MainSingleton.instance.Player.transform.position, MainSingleton.instance.Player.transform.lossyScale.x * s, layermask);
            if (Enemys.Length > 0)
            {
                for (int x = 0; x < Enemys.Length; x++)
                {
                    Enemys[x].transform.GetComponent<Enemy_Info>().StunFunc(t);
                }
            }
            MainSingleton.instance.playerstat.TimeIn(0.5f);
            Cnt = 0;
            SoundManager.inst.SoundPlay(24);
        }
    }


}
