using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_5 : Skill_Ori
{



    void Start_Func()
    {
        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        float Range = 300f;
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            Collider[] hits = Physics.OverlapSphere(transform.position, Range);//�÷��̾� ��ġ�� ����(300)���� ������Ʈ �迭�� �ޱ�
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
                    int random = Random.Range(0, Enemys.Count - 1);//�����̱�!.
                                                                   //Instantiate(bullet1, hits[random].transform.position, Quaternion.identity); ����
                    Debug.Log(Enemys[random].name + "������ ����");

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
