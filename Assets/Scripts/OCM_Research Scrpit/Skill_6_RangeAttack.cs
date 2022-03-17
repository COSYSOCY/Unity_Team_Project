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
    //            //�ƹ��͵��ƴ�
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
        //���۽� ����
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
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//�÷��̾� ��ġ�� ����(300)���� ������Ʈ �迭�� �ޱ�
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
                    GameObject enemy;
                    enemy = Enemys[0];
                    for (int i = 0; i < Enemys.Count; i++)
                    {
                        if (Vector3.Distance(Player.transform.position, enemy.transform.position) > Vector3.Distance(Player.transform.position, Enemys[i].transform.position))
                        {
                            enemy = Enemys[i];
                            
                        }
                    }

                    // �÷��̾� ��ġ�� �������� ���� ���� ���� ��ȯ�� ������ ����                   
                    //if (isbullet6 == false)
                    //{

                    //}

                    for (int i = 0; i < 20; i++)
                    {                     
                        
                        GameObject bullet6 = Instantiate(Player, transform.position, transform.rotation);
                        Rigidbody rigid = bullet6.GetComponent<Rigidbody>();
                        
                        hits[i].SendMessage("����� ����");       // �ݶ��̴� �ȿ� ������ ���� ����� �ִ� ������� ó��    
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
