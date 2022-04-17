using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public int idx=0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            MainSingleton.instance.BoxScritp.BoxFunc1(idx);
            gameObject.SetActive(false);
        }


    }
}
