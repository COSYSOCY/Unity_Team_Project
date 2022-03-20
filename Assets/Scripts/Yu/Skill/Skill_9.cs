using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_9 : Skill_Ori
{

    public Vector3 endpos;
    public GameObject laserPrefab;

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
        float Range = 100f;
        while (true)
        {
            yield return new WaitForSeconds(Cool_Main);
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//플레이어 위치에 범위(100)내에 오브젝트 배열로 받기
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
                    for (int z = 0; z < info.bulletCnt; z++)
                    {
                        int random = Random.Range(0, Enemys.Count - 1);
                        GameObject laser = Instantiate(laserPrefab, Player.transform.position, Quaternion.identity);
                        Vector3 d = Enemys[random].transform.position - Player.transform.position;
                        d.Normalize();
                        endpos = d * 500;
                        laser.GetComponent<LineRenderer>().SetPosition(0, Player.transform.position);
                        laser.GetComponent<LineRenderer>().SetPosition(1, endpos);

                        RaycastHit[] Rhits = Physics.SphereCastAll(Player.transform.position, 2f, d);

                        if (Rhits.Length > 0)
                        {
                            for (int i = 0; i < Rhits.Length; i++)
                            {
                                if (Rhits[i].transform.CompareTag("Enemy") && Rhits[i].transform.gameObject.activeSelf)
                                {
                                    Rhits[i].transform.GetComponent<Enemy_Info>().Damaged(info.Damage);


                                }
                            }
                        }
                        Destroy(laser, 0.5f);
                    }
                    

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
