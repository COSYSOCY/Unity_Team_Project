using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_11 : Skill_Ori
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
        float Range = 40f;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//플레이어 위치에 범위(40)내에 오브젝트 배열로 받기
            if (hits.Length > 0)
            {
                List<GameObject> Enemys = new List<GameObject>(); // 적들만 뽑기
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].transform.CompareTag("Enemy"))
                    {
                        Enemys.Add(hits[i].gameObject);

                    }
                }
                if (Enemys.Count > 0)
                {
                    //Debug.Log("발사");
                    int random = Random.Range(0, Enemys.Count - 1);//랜덤뽑기!.
                    for (int i = 0; i < info.bulletCnt; i++)
                    {
                        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_11", Player.transform.position, Quaternion.identity);
                        bullet.transform.LookAt(Enemys[random].transform);
                        bullet.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;
                        yield return new WaitForSeconds(0.15f);
                    }

                    //Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                    //rigid.velocity = bulletPos.forward.normalized * 20f;
                    //미사일 생성 하고 적 방향 바라보기

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
