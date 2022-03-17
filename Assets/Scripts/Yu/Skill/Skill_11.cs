using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_11 : Skill_Ori
{



    public override void LevelUp()
    {
        switch (Lv)
        {
            case 0:
                //�ƹ��͵��ƴ�
                break;
            case 1:
                //..;
                break;
            case 2:
                //..;
                break;
            case 3:
                //..
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

        Lv++;
    }

    void Start_Func()
    {
        //���۽� ����
        Lv = 1;
        bulletCnt = 1;
        Damage = 1f;

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        float Range = 300f;
        while (true)
        {
            yield return new WaitForSeconds(1f);
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
                    int random = Random.Range(0, Enemys.Count - 1);//�����̱�!.
                    GameObject bullet = Instantiate(bulletPrefab, hits[random].transform.position, Quaternion.identity);
                    bullet.transform.LookAt(Enemys[random].transform);

                    Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                    rigid.velocity = bulletPos.forward.normalized * 20f;
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
