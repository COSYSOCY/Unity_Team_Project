using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_14 : Skill_Ori
{



    public override void LevelUp()
    {
        switch (Lv)
        {
            case 0:
                //아무것도아님
                break;
            case 1:
                //..;
                break;
            case 2:
                //..;
                break;
            case 3:
                //..
                break;
            case 4:
                //.
                break;
            case 5:
                //.
                break;
            case 6:
                //.
                break;
            case 7:
                //.
                break;
            default:
                break;
        }

        Lv++;
    }

    void Start_Func()
    {
        //시작시 설정
        Lv = 1;
        bulletCnt = 1;
        Damage = 1f;

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject bullet = Instantiate(bulletPrefab, Player.transform.position, Quaternion.identity);
            bullet.transform.rotation = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
            // 미사일 방향을 y축으로 0~360 랜덤하게 설정
            Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            rigid.velocity = bulletPos.forward.normalized * 20f;

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
