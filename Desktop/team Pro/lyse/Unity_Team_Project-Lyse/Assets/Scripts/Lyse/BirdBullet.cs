using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdBullet : MonoBehaviour
{
    float x;
    float z;
    
    
    
    
    void Start()
    {
        x = Random.Range(-7, 7);
        z = Random.Range(-7, 7);       
        transform.DOJump(new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z), 3f, 1, 0.5f);
    }

    
    void Update()
    {
        
    }
}
