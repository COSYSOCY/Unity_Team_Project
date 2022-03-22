using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        CameraFollow();
    }
    void CameraFollow()
    {
        transform.position = target.position + offset;
    }
}
