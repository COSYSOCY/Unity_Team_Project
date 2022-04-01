using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Bullet_7 : MonoBehaviour
{
    public ParticleSystem particle;


    private void OnEnable()
    {
       // particle.Play();
    }

    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
