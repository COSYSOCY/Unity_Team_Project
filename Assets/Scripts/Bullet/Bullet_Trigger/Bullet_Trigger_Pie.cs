using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_Pie : MonoBehaviour
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
            info.pie--;
            other.GetComponent<Enemy_Info>().Damaged(info.damage);
            if (info.pie <1)
            {
                gameObject.SetActive(false);

            }

        }
        
    }
}
