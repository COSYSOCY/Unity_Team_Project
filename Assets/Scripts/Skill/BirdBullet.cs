using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdBullet : MonoBehaviour
{
    [SerializeField] private float ran;
    
    
    void Start()
    {

    }

    private void OnEnable()
    {
        birdRandom();
        transform.DOJump(new Vector3(MainSingleton.instance.birdtarget.transform.position.x + ran, MainSingleton.instance.birdtarget.transform.position.y, MainSingleton.instance.birdtarget.transform.position.z + ran), 5f, 1, 0.45f); //불렛 포물선움직임

    }
    public void birdRandom()
    {
        ran = Random.Range(-2, 2);        
    }
}
