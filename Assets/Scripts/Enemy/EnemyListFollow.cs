using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListFollow : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        StartCoroutine(FollowList());
    }
    IEnumerator FollowList()
    {
        while (true)
        {
            gameObject.transform.position = target.transform.position;
            yield return new WaitForFixedUpdate();
        }
    }
}
