using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_14 : Skill_Ori
{




    void Start_Func()
    {
        LevelUp();

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < info.bulletCnt; i++)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", Player.transform.position, Quaternion.identity);

                // �̻��� ������ y������ 0~360 �����ϰ� ����
                //Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                bullet.transform.rotation = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
                bullet.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;
            }

            //rigid.velocity = bulletPos.forward.normalized * 20f;

        }
    }


    private void OnEnable()
    {
        if (start==false)
        {
        Start_Func();
            start = true;
        }
    }
}
