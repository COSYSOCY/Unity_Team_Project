using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GidomonAttack : MonoBehaviour
{      
    
    public GameObject gidomon;
    public GameObject paren;
    public GameObject birdparen;
    public GameObject birdBullet;
    


    public Transform bulletPos;
    [SerializeField] private int weapon;   
    [SerializeField] private bool bookATK;    
    [SerializeField] private bool birdATK;

    void Update()
    {
        GunSelect();
    }
    void GunSelect()
    {        
        if (weapon == 5 && bookATK == false)
        {
            StartCoroutine(BookATK());
            bookATK = true;
        }
        if (weapon == 6 && birdATK == false)
        {
            StartCoroutine(BirdAtk());
            birdATK = true;
        }
    }    

    IEnumerator BookATK()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            GameObject bullet = Instantiate(gidomon, new Vector3(transform.position.x,transform.position.y,transform.position.z - 0.914f), transform.rotation);
            bullet.transform.SetParent(paren.transform, true);                                 
        }
    }

    IEnumerator BirdAtk()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);            
            GameObject bullet = Instantiate(birdBullet, birdparen.transform.position, transform.rotation);            
        }
    }
}