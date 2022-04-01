using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Info : MonoBehaviour
{
    public float damage;
    public int pie;
    public float move;

    public void Destorybullet(float t)
    {
        StartCoroutine(DeadObj(t));
    }
    IEnumerator DeadObj(float t)
    {

        yield return new WaitForSeconds(t);
        gameObject.SetActive(false);
    }
}
