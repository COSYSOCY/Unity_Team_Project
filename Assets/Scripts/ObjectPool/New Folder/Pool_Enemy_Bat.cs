using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Enemy_Bat : MonoBehaviour
{
    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
