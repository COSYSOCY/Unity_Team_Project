using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoDestory : MonoBehaviour
{
    public float deadTime;
    void OnEnable()
    {
        StartCoroutine(DeadObj());
    }

    IEnumerator DeadObj()
    {

        yield return new WaitForSeconds(deadTime);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
