using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_15: Skill_Ori
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
                        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_15", Player.transform.position, Player.transform.rotation);
                        bullet.transform.LookAt(enemy.transform);
                        bullet.GetComponent<Bullet_Info>().damage = _Damage();
                        yield return new WaitForSeconds(0.15f);
                    }



                }
            }

        }
    }


    private void OnEnable()
    {
        if (start==false&&info.goodstart)
        {
        Start_Func();
            start = true;
        }
    }
}
