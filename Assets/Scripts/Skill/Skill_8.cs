using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_8 : Skill_Ori
{



    void Start_Func()
    {
        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            for (int i = 0; i < 50; i++)
            {
                GameObject bullet3 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 90, 0));
                Rigidbody rigid3 = bullet3.GetComponent<Rigidbody>();
                Vector3 ranvec = new Vector3(Mathf.Sin(Mathf.PI * 3 * i / 50), 0, Mathf.Cos(Mathf.PI * 3 * i / 50));
                rigid3.velocity = ranvec.normalized * 10f;
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
