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
    [SerializeField] private bool ShotGunATK;
    [SerializeField] private bool machineGunATK;
    [SerializeField] private bool fireRoundATK;

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
        if (weapon == 2 && ShotGunATK == false)
        {
            StartCoroutine(ShotGunAtk());
            ShotGunATK = true;
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
    }
    IEnumerator NomalAtk()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject bullet = Instantiate(bulletA, transform.position, transform.rotation);
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
                GameObject bullet1 = Instantiate(bulletB, transform.position, transform.rotation);
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
                GameObject bullet2 = Instantiate(bulletC, transform.position, transform.rotation);
                Rigidbody rigid2 = bullet2.GetComponent<Rigidbody>();
                Vector3 ranvec = new Vector3(0, Mathf.Sin(Mathf.PI * 20), 0);
                rigid2.velocity = bulletPos.position + ranvec.normalized * 100f;
                yield return new WaitForSeconds(0.1f);
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