using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2 : Skill_Ori
{



    void Start_Func()
    {
        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < 5; i++)
            {
                GameObject bullet1 = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
                Rigidbody rigid1 = bullet1.GetComponent<Rigidbody>();
                bulletPos.transform.Rotate(0, -5 + i + 3, 0);
                rigid1.velocity = bulletPos.forward.normalized * 20f;
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
