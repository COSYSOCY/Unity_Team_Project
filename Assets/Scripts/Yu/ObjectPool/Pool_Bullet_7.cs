using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Bullet_7 : MonoBehaviour
{
    public void bo()
    {

    }

    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
        CancelInvoke();
    }
}
