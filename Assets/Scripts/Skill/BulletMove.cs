using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float moveSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime* moveSpeed);
    }
}