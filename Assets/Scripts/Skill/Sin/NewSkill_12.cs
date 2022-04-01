using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_12 : Skill_Ori
{

    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();
        



    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }

    }
    public void Skill_Func() // 실질적으로 실행되는 스크립트
    {

        float local = _AtRange();
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_12", pos, Quaternion.identity);
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
