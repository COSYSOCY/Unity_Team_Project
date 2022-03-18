using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_AutoDestory : MonoBehaviour
{
    public float deadTime;
    void OnEnable()
    {
        StartCoroutine(DeadObj());
    }

    IEnumerator DeadObj()
    {

        yield return new WaitForSeconds(deadTime);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
