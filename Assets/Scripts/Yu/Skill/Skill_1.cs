using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : Skill_Ori
{
    
    public override void LevelUp()
    {
        switch (info.Lv)
        {
            case 0:
                //아무것도아님
                break;
            case 1:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 2:
                //공격력증가
                info.Damage = 5f;
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
            for (int i = 0; i < info.bulletCnt; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation* Quaternion.Euler(0f,i*10,0f));
                bullet.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;
            }
            
            //Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            //rigid.velocity = bulletPos.forward.normalized * 20f;
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
