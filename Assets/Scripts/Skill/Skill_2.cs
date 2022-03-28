using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2 : Skill_Ori
{


    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
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

            if (Player.transform.rotation.y > 0 && Player.transform.rotation.y < 180)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_2", Player.transform.position + new Vector3(5f, 0f, 0f),Quaternion.identity);

                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                //Destroy(bullet, 0.3f);
                if (info.bulletCnt == 2)
                {
                    GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_2", Player.transform.position + new Vector3(-5f, 0f, 0f), Quaternion.identity);
                    bullet2.GetComponent<Bullet_Info>().damage = _Damage();
                    //Destroy(bullet2, 0.3f);
                }
            }
            else
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_2", Player.transform.position + new Vector3(-5f, 0f, 0f), Quaternion.identity);
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                //Destroy(bullet, 0.3f);
                if (info.bulletCnt == 2)
                {
                    GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_2", Player.transform.position + new Vector3(+5f, 0f, 0f), Quaternion.identity);
                    bullet2.GetComponent<Bullet_Info>().damage = _Damage();
                    //Destroy(bullet2, 0.3f);
                }
            }


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
