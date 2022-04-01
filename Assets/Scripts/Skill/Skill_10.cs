using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_10 : Skill_Ori
{


    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2������ �ɰ�� ����
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
                    for (int i = 0; i < info.bulletCnt; i++)
                    {
                        //Debug.Log("�߻�");
                        int random = Random.Range(0, Enemys.Count - 1);//�����̱�!.
                        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_10", Player.transform.position, Quaternion.identity);
                        bullet.transform.LookAt(Enemys[random].transform);
                        bullet.GetComponent<Bullet_Info>().damage = _Damage();
                        bullet.GetComponent<Bullet_Trigger_10>().Player = Player;
                        //Rigidbody rigid = bullet.GetComponent<Rigidbody>();
                        //rigid.velocity = bulletPos.forward.normalized * 20f;
                        //�̻��� ���� �ϰ� �� ���� �ٶ󺸱�
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
