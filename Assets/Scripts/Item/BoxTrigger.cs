using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            MainSingleton.instance.BoxScritp.BoxFunc1();
            gameObject.SetActive(false);
        }


    }
}
