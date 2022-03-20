using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_14 : Skill_Ori
{



    public override void LevelUp()
    {
        switch (info.Lv)
        {
            case 0:
                //아무것도아님
                break;
            case 1:
                info.bulletCnt++;
                break;
            case 2:
                info.bulletCnt++;
                break;
            case 3:
                info.bulletCnt++;
                break;
            case 4:
                info.bulletCnt++;
                break;
            case 5:
                info.bulletCnt++;
                break;
            case 6:
                info.bulletCnt++;
                break;
            case 7:
                info.bulletCnt++;
                break;
            default:
                break;
        }

        info.Lv++;
    }

    void Start_Func()
    {
        //시작시 설정
        info.Lv = 1;
        info.bulletCnt = 2;
        info.Damage = 1f;

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            for (int i = 0; i < info.bulletCnt; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, Player.transform.position, Quaternion.identity);

                // 미사일 방향을 y축으로 0~360 랜덤하게 설정
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
