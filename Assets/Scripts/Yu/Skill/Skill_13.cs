using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_13 : Skill_Ori
{



    public override void LevelUp()
    {
        switch (info.Lv)
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

        info.Lv++;
    }

    void Start_Func()
    {
        //시작시 설정
        info.Lv = 1;
        info.bulletCnt = 1;
        info.Damage = 1f;

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject bullet = Instantiate(bulletPrefab, Player.transform.position, Player.transform.rotation);
            Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            rigid.velocity = bulletPos.forward.normalized * 20f;
            //rigid.AddForce(Vector3.zero * 15, ForceMode.Impulse);
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
