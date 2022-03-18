using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_8 : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public float Damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            other.GetComponent<Enemy_Info>().Damaged(Damage);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Bullet_Trigger_8_2>().Damage = Damage;
            bullet.GetComponent<Bullet_Trigger_8_2>().nodagame = other.gameObject;
            GameObject bullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation*Quaternion.Euler(0f,30f,0f));
            bullet2.GetComponent<Bullet_Trigger_8_2>().Damage = Damage;
            bullet.GetComponent<Bullet_Trigger_8_2>().nodagame = other.gameObject;
            GameObject bullet3 = Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0f, -30f, 0f));
            bullet3.GetComponent<Bullet_Trigger_8_2>().Damage = Damage;
            bullet.GetComponent<Bullet_Trigger_8_2>().nodagame = other.gameObject;
            Destroy(gameObject);
        }

    }
}
