using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Object : MonoBehaviour
{


    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
