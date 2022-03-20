using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject bulletC;

    public Transform bulletPos;
    [SerializeField] private int weapon;
    [SerializeField] private bool nomalATK;
    [SerializeField] private bool shotGunATK;
    [SerializeField] private bool machineGunATK;
    [SerializeField] private bool fireRoundATK;
    [SerializeField] private bool ATK1;
    [SerializeField] private bool ATK2;
    [SerializeField] private bool ATK3;
    [SerializeField] private bool ATK4;
    [SerializeField] private bool ATK5;
    [SerializeField] private bool ATK6;
    [SerializeField] private bool ATK7;
    [SerializeField] private bool ATK8;
    [SerializeField] private bool ATK9;

    void Update()
    {
        GunSelect();
    }
    void GunSelect()
    {
        if(weapon == 1 && nomalATK == false)
        {
            StartCoroutine(NomalAtk());
            nomalATK = true;
        }
        if (weapon == 2 && shotGunATK == false)
        {
            StartCoroutine(ShotGunAtk());
            shotGunATK = true;
        }
        if (weapon == 3 && machineGunATK == false)
        {
            StartCoroutine(MachineGun());
            machineGunATK = true;
        }
        if (weapon == 4 && fireRoundATK == false)
        {
            StartCoroutine(FireRoundATK());
            fireRoundATK = true;
        }
        if (weapon == 5 && ATK1 == false)
        {
            //StartCoroutine();
            fireRoundATK = true;
        }
        if (weapon == 6 && ATK2 == false)
        {
            //StartCoroutine();
            fireRoundATK = true;
        }
        if (weapon == 7 && ATK3 == false)
        {
            //StartCoroutine();
            fireRoundATK = true;
        }
        if (weapon == 8 && ATK4 == false)
        {
            //StartCoroutine();
            fireRoundATK = true;
        }
        if (weapon == 9 && ATK5 == false)
        {
            //StartCoroutine();
            fireRoundATK = true;
        }
        if (weapon == 10 && ATK6 == false)
        {
            //StartCoroutine();
            fireRoundATK = true;
        }
        if (weapon == 11 && ATK7 == false)
        {
            //StartCoroutine();
            fireRoundATK = true;
        }
        if (weapon == 12 && ATK8 == false)
        {
            //StartCoroutine();
            fireRoundATK = true;
        }
    }
    IEnumerator NomalAtk()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject bullet = Instantiate(bulletA, bulletPos.transform.position, bulletPos.transform.rotation);
            Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            rigid.velocity = bulletPos.forward.normalized * 20f;
            //rigid.AddForce(Vector3.zero * 15, ForceMode.Impulse);
        }
    }
    IEnumerator ShotGunAtk()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < 5; i++)
            {
                GameObject bullet1 = Instantiate(bulletB, bulletPos.transform.position, bulletPos.transform.rotation);
                Rigidbody rigid1 = bullet1.GetComponent<Rigidbody>();
                bulletPos.transform.Rotate(0, -5 + i + 3, 0);
                rigid1.velocity = bulletPos.forward.normalized * 20f;
            }
        }
    }
    IEnumerator MachineGun()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 30; i++)
            {
                
                GameObject bullet2 = Instantiate(bulletC, bulletPos.transform.position, bulletPos.transform.rotation);
                Rigidbody rigid2 = bullet2.GetComponent<Rigidbody>();
                rigid2.velocity = bulletPos.forward.normalized * 10f;
                yield return new WaitForSeconds(0.15f);
            }
        }  
    }
    IEnumerator FireRoundATK()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
            for (int i = 0; i < 50; i++)
            {
                GameObject bullet3 = Instantiate(bulletC, transform.position, Quaternion.Euler(0,90,0));
                Rigidbody rigid3 = bullet3.GetComponent<Rigidbody>();
                Vector3 ranvec = new Vector3(Mathf.Sin(Mathf.PI * 3 * i / 50),0, Mathf.Cos(Mathf.PI * 3 * i / 50));
                rigid3.velocity = ranvec.normalized * 10f;
            }
        }
    }
}