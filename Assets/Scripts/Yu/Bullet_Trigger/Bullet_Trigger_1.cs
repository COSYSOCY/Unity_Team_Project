using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_1 : MonoBehaviour
{
    public float Damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")&&other.gameObject.activeSelf)
        {
            other.GetComponent<Enemy_Info>().Damaged(Damage);
            Destroy(gameObject);
        }

    }
}
