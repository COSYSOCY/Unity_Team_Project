using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObj : MonoBehaviour
{
    public float Hp;
    public float Hp_Max;

    private void OnEnable()
    {
        Hp = Hp_Max;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("È÷Æ®");
            Hp--;
            if(Hp <=0)
            {
                ItemSpawn();
                gameObject.SetActive(false);
            }
        }
    }

    void ItemSpawn()
    {
        int ran = Random.Range(0, 10);

        if(ran <= 5)
        {
            ObjectPooler.SpawnFromPool("item_xp_1", transform.position, transform.rotation);
        }
    }

}
