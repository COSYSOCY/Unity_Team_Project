using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectIs : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Object"))
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
