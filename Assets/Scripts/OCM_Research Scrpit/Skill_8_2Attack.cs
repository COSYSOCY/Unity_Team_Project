using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_8 : Skill_Ori
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


                    //�Ѿ˻����ؼ� �����ø鳡
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject bullet8_1 = Instantiate(bulletPrefab, transform.position, transform.rotation);
                        Rigidbody rigid = bullet8_1.GetComponent<Rigidbody>();
                        rigid.velocity = bulletPos.forward.normalized * 20f;
                        if (hits[i].transform.CompareTag("bullet8_1")) // ��� ���� ������ 2��° ������ ��8_1�� ������ �� �ڸ��� ��8_2�� ��ȯ�Ѵ�
                        {
                            GameObject bullet8_2 = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
                            Rigidbody rigid1 = bullet8_2.GetComponent<Rigidbody>();
                            yield return new WaitForSeconds(0.1f);
                        }
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

    //void OnColliderEnter(Collider other)
    //{

    //    if (other.gameObject.tag == "Bullet8_1") // ��� ���� ������ 2��° ������ ��8_1�� ������ �� �ڸ��� ��8_2�� ��ȯ�Ѵ�
    //    {
    //        GameObject bullet8_2 = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
    //        Rigidbody rigid1 = bullet8_2.GetComponent<Rigidbody>();
    //    }

    //}
}

