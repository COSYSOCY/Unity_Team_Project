using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_8_2 : MonoBehaviour
{
    
    public GameObject nodagame;
    public float Damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")&&other.gameObject!= nodagame)
        {

            other.GetComponent<Enemy_Info>().Damaged(Damage);
            Destroy(gameObject);
        }

    }
}
