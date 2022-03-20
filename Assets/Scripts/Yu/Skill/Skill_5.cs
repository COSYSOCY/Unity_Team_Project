using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_5 : Skill_Ori
{



    public override void LevelUp()
    {
        switch (info.Lv)
        {
            case 0:
                //�ƹ��͵��ƴ�
                break;
            case 1:
                info.bulletCnt += 2;
                break;
            case 2:
                info.bulletCnt += 2;
                break;
            case 3:
                info.bulletCnt += 2;
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
        //���۽� ����
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
