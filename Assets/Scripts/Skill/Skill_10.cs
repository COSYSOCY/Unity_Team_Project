using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_10 : Skill_Ori
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
            yield return new WaitForSeconds(2f);
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
                    for (int i = 0; i < info.bulletCnt; i++)
                    {
                        //Debug.Log("발사");
                        int random = Random.Range(0, Enemys.Count - 1);//랜덤뽑기!.
                        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_10", Player.transform.position, Quaternion.identity);
                        bullet.transform.LookAt(Enemys[random].transform);
                        bullet.GetComponent<Bullet_Info>().damage = _Damage();
                        bullet.GetComponent<Bullet_Trigger_10>().Player = Player;
                        //Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                        //rigid.velocity = bulletPos.forward.normalized * 20f;
                        //미사일 생성 하고 적 방향 바라보기
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
