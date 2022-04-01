using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_3 : Skill_Ori
{



    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }
    }

    void Start_Func()
    {
        LevelUp();
        manager.skill_Add(gameObject, info.Skill_Icon);
        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_3", Player.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            //Destroy(bullet, 1f);
        }
    }


    private void OnEnable()
    {
        if (start==false && info.goodstart)
        {
        Start_Func();
            start = true;
        }
    }
}
