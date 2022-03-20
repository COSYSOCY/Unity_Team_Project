using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_10 : MonoBehaviour
{
    public float Damage;
    public GameObject Player;
    public bool check = false;
    private void OnTriggerEnter(Collider other)
    {
        if (check)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy_Info>().Damaged(Damage);
            }
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy_Info>().Damaged(Damage);
            }
        }



    }
    private void Start()
    {
        StartCoroutine(gogo());
    }

    IEnumerator gogo()
    {
        yield return new WaitForSeconds(1f);
        //gameObject.transform.LookAt(Player.transform.position);
        check = true;
        while (true)
        {
            gameObject.transform.LookAt(Player.transform.position);
            yield return null;
        }
    }
}
