using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_8 : Skill_Ori
{


    void Start_Func()
    {
        LevelUp();

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        float Range = 40f;
        while (true)
        {
            yield return new WaitForSeconds(3f);
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
                    GameObject enemy;
                    enemy = Enemys[0];
                    for (int i = 0; i < Enemys.Count; i++)
                    {
                        if (Vector3.Distance(Player.transform.position, enemy.transform.position) > Vector3.Distance(Player.transform.position, Enemys[i].transform.position))
                        {
                            enemy = Enemys[i];
                        }
                    }
                    for (int i = 0; i < info.bulletCnt; i++)
                    {
                        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_8", Player.transform.position, Player.transform.rotation);
                        bullet.transform.LookAt(enemy.transform);
                        bullet.GetComponent<Bullet_Trigger_8>().Damage = info.Damage;
                        yield return new WaitForSeconds(0.15f);
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
