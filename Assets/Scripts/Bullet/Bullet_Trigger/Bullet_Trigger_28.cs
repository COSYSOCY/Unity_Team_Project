using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_28 : MonoBehaviour
{
    public Bullet_Info info;
    public LayerMask layermask;
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Enemy")&&other.gameObject.activeSelf)
        {
            if (info.Up)
            {
                Collider[] Enemys;

                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_28_1", transform.position, Quaternion.identity);
                Enemys = Physics.OverlapSphere(transform.position, transform.lossyScale.x, layermask);
                if (Enemys.Length > 0)
                {
                    for (int i = 0; i < Enemys.Length; i++)
                    {
                        Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(info.damage);
                    }
                }
                gameObject.SetActive(false);
                return;
            }

                info.pie--;
            other.GetComponent<Enemy_Info>().Damaged(info.damage);
            if (info.pie <1)
            {
                gameObject.SetActive(false);

            }

        }
        else if (other.gameObject.CompareTag("DeOb"))
            {
                other.GetComponent<DeObjectSystem>().Damaged(info.damage);
            info.pie--;
            if (info.pie < 1)
            {
                gameObject.SetActive(false);

            }
        }

    }
}
