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
                //투사체 증가
                info.bulletCnt++;
                break;
            case 3:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 4:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 5:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 6:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 7:
                //투사체 증가
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
        info.bulletCnt = 1;
        info.Damage = 2f;

        StartCoroutine(Skill_Update());
    }



    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 1; i <= info.bulletCnt; i++)
            {

                //GameObject bullet = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", bulletPos.transform.position, bulletPos.transform.rotation); 
                bullet.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;





                    if (i % 2 == 0)
                    {
                        bullet.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));

                    }
                    else
                    {

                        bullet.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));
                    }
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
