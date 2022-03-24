using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_CJK : Skill_Ori
{
    void Start_Func()
    {
        LevelUp();
        manager.skill_Add(gameObject, info.Skill_Icon);
        StartCoroutine(Skill_Update());
    }



    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 1; i <= info.bulletCnt; i++)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("BulletJK", bulletPos.transform.position, bulletPos.transform.rotation);
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
            }
        }
    }
    private void OnEnable() // 중복방지용 버그처리용스크립트인데 신경쓰지마세요
    {
        if (start == false)
        {
            Start_Func();
            start = true;
        }
    }

}
