using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("1111");
        }
    }
}
