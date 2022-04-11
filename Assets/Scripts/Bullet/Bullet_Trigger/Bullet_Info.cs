using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Info : MonoBehaviour
{
    public float damage;
    public int pie;
    public float move;
    public float KnokTime;
    public float real1;
    public float real2;
    public bool Up = false;

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
