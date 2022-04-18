using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_1 : MonoBehaviour
{
    public Bullet_Info info;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")&&other.gameObject.activeSelf)
        {
            other.GetComponent<Enemy_Info>().Damaged(info.damage);

                gameObject.SetActive(false);

        }
        
    }
}
