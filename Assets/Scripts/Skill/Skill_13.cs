using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_13 : Skill_Ori
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
            yield return new WaitForSeconds(5f);
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//�÷��̾� ��ġ�� ����(40)���� ������Ʈ �迭�� �ޱ�
            if (hits.Length > 0)
            {
                List<GameObject> Enemys = new List<GameObject>(); // ���鸸 �̱�
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].transform.CompareTag("Enemy"))
                    {
                        Enemys.Add(hits[i].gameObject);

                    }
                }
                if (Enemys.Count > 0)
                {
                    //Debug.Log("�߻�");
                    int random = Random.Range(0, Enemys.Count - 1);//�����̱�!.
                    for (int i = 0; i < info.bulletCnt; i++)
                    {
                        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_13", Player.transform.position, Quaternion.identity);
                        bullet.transform.LookAt(Enemys[random].transform);
                        bullet.GetComponent<Bullet_Trigger_5>().Damage = info.Damage;
                        yield return new WaitForSeconds(0.5f);
                    }

                    //Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                    //rigid.velocity = bulletPos.forward.normalized * 20f;
                    //�̻��� ���� �ϰ� �� ���� �ٶ󺸱�

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
