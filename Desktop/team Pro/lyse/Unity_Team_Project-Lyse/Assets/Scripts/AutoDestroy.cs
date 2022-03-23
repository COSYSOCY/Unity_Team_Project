using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float deadTime;
    void Start()
    {
        Destroy(gameObject, deadTime);
    }
}
