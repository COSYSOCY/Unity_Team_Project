using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdAttack : MonoBehaviour
{
    public GameObject birdBullet;
    public Transform birdPos;
       

    [SerializeField] private int weapon;
    [SerializeField] private bool birdATK;

    
    private void Update()
    {
        birdgun();

        
    }

    public void birdgun()
    {       
        if (weapon == 1 && birdATK == false)
        {
            StartCoroutine(BirdAtk());
            birdATK = true;
        }
    }

    IEnumerator BirdAtk()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject bullet = Instantiate(birdBullet, transform.position, transform.rotation);                        
        }
    }

}
