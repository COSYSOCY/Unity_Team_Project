using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_14 : Skill_Ori
{


    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2������ �ɰ�� ����
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
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < info.bulletCnt; i++)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", Player.transform.position, Quaternion.identity);

                // �̻��� ������ y������ 0~360 �����ϰ� ����
                //Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                bullet.transform.rotation = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
            }

            //rigid.velocity = bulletPos.forward.normalized * 20f;

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
