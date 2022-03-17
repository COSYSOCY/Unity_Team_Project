using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_3 : Skill_Ori
{



    void Start_Func()
    {
        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 30; i++)
            {

                GameObject bullet2 = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
                Rigidbody rigid2 = bullet2.GetComponent<Rigidbody>();
                rigid2.velocity = bulletPos.forward.normalized * 10f;
                yield return new WaitForSeconds(0.15f);
            }
        }
    }


    private void OnEnable()
    {
        if (start==false)
        {
        Start_Func();
            start = true;
        }
    }
}
