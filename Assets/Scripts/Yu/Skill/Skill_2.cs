using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2 : Skill_Ori
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
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < 5; i++)
            {
                GameObject bullet1 = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
                Rigidbody rigid1 = bullet1.GetComponent<Rigidbody>();
                bulletPos.transform.Rotate(0, -5 + i + 3, 0);
                rigid1.velocity = bulletPos.forward.normalized * 20f;
            }
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
