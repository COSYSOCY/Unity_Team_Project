using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_4 : Skill_Ori
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
            yield return new WaitForSeconds(3f);
            for (int i = 0; i < 50; i++)
            {
                GameObject bullet3 = Instantiate(bulletPrefab, Player.transform.position, Quaternion.Euler(0, 90, 0));
                Rigidbody rigid3 = bullet3.GetComponent<Rigidbody>();
                Vector3 ranvec = new Vector3(Mathf.Sin(Mathf.PI * 3 * i / 50), 0, Mathf.Cos(Mathf.PI * 3 * i / 50));
                rigid3.velocity = ranvec.normalized * 10f;
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
