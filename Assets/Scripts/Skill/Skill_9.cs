using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_9 : Skill_Ori
{

    public Vector3 endpos;

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
        float Range = 50f;
        while (true)
        {
            yield return new WaitForSeconds(Cool_Main);
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//플레이어 위치에 범위(50)내에 오브젝트 배열로 받기
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
                        GameObject laser = ObjectPooler.SpawnFromPool("Bullet_9", Player.transform.position, Quaternion.identity);
                        Vector3 d = Enemys[random].transform.position - Player.transform.position;
                        d.Normalize();
                        endpos = d * 50;
                        laser.GetComponent<LineRenderer>().SetPosition(0, Player.transform.position);
                        laser.GetComponent<LineRenderer>().SetPosition(1, endpos);

                        RaycastHit[] Rhits = Physics.SphereCastAll(Player.transform.position, 2f, d);

                        if (Rhits.Length > 0)
                        {
                            for (int i = 0; i < Rhits.Length; i++)
                            {
                                if (Rhits[i].transform.CompareTag("Enemy") && Rhits[i].transform.gameObject.activeSelf)
                                {
                                    Rhits[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());


                                }
                            }
                        }

                        //Destroy(laser, 0.5f);
                    }
                    

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
