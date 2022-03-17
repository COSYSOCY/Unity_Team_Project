using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_6_RangeAttack : Skill_Ori
{
    //public override void LevelUp()
    //{
    //    switch (Lv)
    //    {
    //        case 0:
    //            //아무것도아님
    //            break;
    //        case 1:
    //            //..
    //            break;
    //        case 2:
    //            //..
    //            break;
    //        case 3:
    //            //..
    //            break;
    //        case 4:
    //            //.
    //            break;
    //        case 5:
    //            //.
    //            break;
    //        case 6:
    //            //.
    //            break;
    //        case 7:
    //            //.
    //            break;
    //        default:
    //            break;
    //    }

    //    Lv++;
    //}

    //private bool isbullet6;

    void Start_Func()
    {
        //시작시 설정
        Lv = 1;
        //bulletCnt = 1;
        Damage = 1f;

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        float Range = 300f;
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//플레이어 위치에 범위(300)내에 오브젝트 배열로 받기
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
                    GameObject enemy;
                    enemy = Enemys[0];
                    for (int i = 0; i < Enemys.Count; i++)
                    {
                        if (Vector3.Distance(Player.transform.position, enemy.transform.position) > Vector3.Distance(Player.transform.position, Enemys[i].transform.position))
                        {
                            enemy = Enemys[i];
                            
                        }
                    }

                    // 플레이어 위치를 기준으로 원형 공격 범위 소환이 직관적 좋고                   
                    //if (isbullet6 == false)
                    //{

                    //}

                    for (int i = 0; i < 20; i++)
                    {                     
                        
                        GameObject bullet6 = Instantiate(Player, transform.position, transform.rotation);
                        Rigidbody rigid = bullet6.GetComponent<Rigidbody>();
                        
                        hits[i].SendMessage("대미지 입힘");       // 콜라이더 안에 들어오는 적들 대미지 주는 방식으로 처리    
                    }


                }
            }

        }
    }


    private void OnEnable()
    {
        if (start == false)
        {
            Start_Func();
            start = true;
        }
    }
}
