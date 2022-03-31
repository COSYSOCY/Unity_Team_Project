using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Info : MonoBehaviour
{
    public float damage;
    public int pie;
    public float move;


    public IEnumerator DeadObj(float t)
    {

        yield return new WaitForSeconds(t);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
