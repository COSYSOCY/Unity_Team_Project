using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : Skill_Ori
{
    public override void LevelUp()
    {
        switch (Lv)
        {
            case 0:
                //아무것도아님
                break;
            case 1:
                //투사체 증가
                bulletCnt++;
                break;
            case 2:
                //공격력증가
                Damage = 5f;
                break;
            case 3:
                //관통증가
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
        Lv=1;
        bulletCnt = 1;
        Damage = 1f;

        StartCoroutine(Skill_Update());
    }



    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject bullet = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
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
