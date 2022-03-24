using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_8_2 : MonoBehaviour
{
    
    public GameObject nodagame;
    public Bullet_Info info;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")&&other.gameObject!= nodagame)
        {

            other.GetComponent<Enemy_Info>().Damaged(info.damage);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }
}
