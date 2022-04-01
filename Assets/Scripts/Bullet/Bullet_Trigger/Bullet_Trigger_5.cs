using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_5 : MonoBehaviour
{
    public Bullet_Info info;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy_Info>().Damaged(info.damage);
        }

    }
}
