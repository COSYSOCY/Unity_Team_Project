using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_13 : MonoBehaviour
{
    public Bullet_Info info;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy")&&other.gameObject.activeSelf)
        {
            info.pie--;
            other.GetComponent<Enemy_Info>().Damaged(info.damage);
            float f = transform.rotation.eulerAngles.y + Random.Range(150f, 210f);
            transform.rotation = Quaternion.Euler(new Vector2(0,f));
            if (info.pie <1)
            {
                gameObject.SetActive(false);

            }

        }
        else if (other.gameObject.CompareTag("DeOb"))
            {
                other.GetComponent<DeObjectSystem>().Damaged(info.damage);
            info.pie--;
            if (info.pie < 1)
            {
                gameObject.SetActive(false);

            }
        }

    }
}
