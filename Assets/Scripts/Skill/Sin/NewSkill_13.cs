using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_13: Skill_Ori
{
    public int P = 0;
    public int P_Max = 0;

    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();


        //
        P_Max = 5;


        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {

    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 3) // 2레벨이 될경우 실행
        {
            P_Max = 4;
        }

    }
    public void Skill13Func()
    {
        P++;
        if (P>= P_Max)
        {
            P = 0;
            Skill_Func();
        }
    }
    public void Skill_Func() // 실질적으로 실행되는 스크립트
    {

        float local = _AtRange();
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_13", pos, Quaternion.identity);
        bullet.transform.localScale = new Vector3(local, local, local);
        Collider[] Enemys;
        Enemys = Physics.OverlapSphere(Player.transform.position, bullet.transform.lossyScale.x * _AtRange(), layermask);
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
            }
        }

    }


    private void OnEnable()
    {
        if (start == false && info.goodstart)
        {
            Start_Func();
            start = true;
        }
    }
}
