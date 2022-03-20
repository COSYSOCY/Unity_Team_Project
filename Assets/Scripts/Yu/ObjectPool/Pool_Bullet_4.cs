using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Bullet_4 : MonoBehaviour
{


    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
