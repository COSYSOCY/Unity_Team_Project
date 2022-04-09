using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_NoPie : MonoBehaviour
{
    public Bullet_Info info;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy")&&other.gameObject.activeSelf)
        {
            if (info.KnokTime > 0)
            {
                other.GetComponent<Enemy_Info>().KnockEnemy(info.KnokTime);
            }
            other.GetComponent<Enemy_Info>().Damaged(info.damage);


        }
        else if (other.gameObject.CompareTag("DeOb"))
            {
                other.GetComponent<DeObjectSystem>().Damaged(info.damage);
        }

    }
}
