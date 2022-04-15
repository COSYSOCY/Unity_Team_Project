using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            MainSingleton.instance.BoxScritp.BoxFunc2();
            gameObject.SetActive(false);
        }


    }
}
