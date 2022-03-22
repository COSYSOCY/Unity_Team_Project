using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdBullet : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float ran;
    
    
    void Start()
    {
        target = GameObject.Find("birdtarget");
        birdRandom();
        transform.DOJump(new Vector3(target.transform.position.x + ran, target.transform.position.y,  target.transform.position.z+ ran), 5f, 1, 0.45f); //불렛 포물선움직임
    }      
    
    public void birdRandom()
    {
        ran = Random.Range(-2, 2);        
    }
}
