using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_15 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Bullet_Info info;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            other.GetComponent<Enemy_Info>().Damaged(info.damage);

            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_15_2", transform.position, transform.rotation);
            //bullet.GetComponent<Bullet_Trigger_15_2>().Damage = info.damage;
            bullet.GetComponent<Bullet_Trigger_15_2>().nodagame = other.gameObject;
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }
}
