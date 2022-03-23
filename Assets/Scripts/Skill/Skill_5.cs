using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_5 : Skill_Ori
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
            yield return new WaitForSeconds(2f);
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//�÷��̾� ��ġ�� ����(40)���� ������Ʈ �迭�� �ޱ�
            if (hits.Length > 0)
            {
                List<GameObject> Enemys = new List<GameObject>(); // ���鸸 �̱�
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].transform.CompareTag("Enemy"))
                    {
                        //Debug.Log(Vector3.Distance(Player.transform.position,hits[i].transform.position));
                        Enemys.Add(hits[i].gameObject);
                    }
                }
                if (Enemys.Count > 0)
                {
                    for (int i = 0; i < info.bulletCnt; i++)
                    {
                        int random = Random.Range(0, Enemys.Count - 1);//�����̱�!.
                        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_5", Enemys[random].transform.position, Quaternion.identity); //����
                        Enemys[random].GetComponent<Enemy_Info>().Damaged(info.Damage);
                        //Destroy(bullet, 0.5f);
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