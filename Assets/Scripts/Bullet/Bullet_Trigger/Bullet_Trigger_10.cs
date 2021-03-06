using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_10 : MonoBehaviour
{
    public Bullet_Info info;
    public GameObject Player;
    public bool check = false;
    private void OnTriggerEnter(Collider other)
    {
        if (check)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy_Info>().Damaged(info.damage);
            }
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy_Info>().Damaged(info.damage);
            }
        }



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

    private void OnEnable()
    {
        check = false;
        StartCoroutine(gogo());
    }
}
