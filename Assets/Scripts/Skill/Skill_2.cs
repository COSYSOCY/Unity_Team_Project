using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2 : Skill_Ori
{



    public override void LevelUp()
    {
        switch (info.Lv)
        {
            case 0:
                //�ƹ��͵��ƴ�
                break;
            case 1:
                info.bulletCnt++;
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
        //���۽� ����
        info.Lv = 1;
        info.bulletCnt = 1;
        info.Damage = 1f;

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            if (Player.transform.rotation.y > 0 && Player.transform.rotation.y < 180)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_2", Player.transform.position + new Vector3(5f, 0f, 0f),Quaternion.identity);

                bullet.GetComponent<Bullet_Trigger_5>().Damage = info.Damage;
                //Destroy(bullet, 0.3f);
                if (info.bulletCnt == 2)
                {
                    GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_2", Player.transform.position + new Vector3(-5f, 0f, 0f), Quaternion.identity);
                    bullet2.GetComponent<Bullet_Trigger_5>().Damage = info.Damage;
                    //Destroy(bullet2, 0.3f);
                }
            }
            else
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_2", Player.transform.position + new Vector3(-5f, 0f, 0f), Quaternion.identity);
                bullet.GetComponent<Bullet_Trigger_5>().Damage = info.Damage;
                //Destroy(bullet, 0.3f);
                if (info.bulletCnt == 2)
                {
                    GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_2", Player.transform.position + new Vector3(+5f, 0f, 0f), Quaternion.identity);
                    bullet2.GetComponent<Bullet_Trigger_5>().Damage = info.Damage;
                    //Destroy(bullet2, 0.3f);
                }
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
