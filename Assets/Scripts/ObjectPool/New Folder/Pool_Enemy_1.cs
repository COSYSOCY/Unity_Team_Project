using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Enemy_1 : MonoBehaviour
{

    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
