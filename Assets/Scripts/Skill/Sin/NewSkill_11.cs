using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_11 : Skill_Ori
{


    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2?????? ???? ????
        {

        }
    }


    void Start_Func()
    {
        LevelUp();
        manager.skill_Add(gameObject, info.Skill_Icon);
        StartCoroutine(Skill_Update());
    }
    IEnumerator Skill_Update() // ?????????? ?????? ??????
    {

        while (true)
        {
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());
        }
    }

    IEnumerator Skill_Update2()
    {
        float local = _AtRange();
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float f1 = 0f;

            for (int i = 1; i <= _BulletCnt(); i++)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_11", pos + new Vector3(5f, 0f, f1), Quaternion.identity);

                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                bullet.transform.localScale = new Vector3(local, local, local);
                yield return new WaitForSeconds(0.1f);
                if (i % 2 == 0)
                {
                    GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_11", pos + new Vector3(-5f, 0f, f1), Quaternion.identity);
                    bullet2.GetComponent<Bullet_Info>().damage = _Damage();
                    bullet.transform.localScale = new Vector3(local, local, local);
                    yield return new WaitForSeconds(0.1f);
                    f1 += 2f;
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
