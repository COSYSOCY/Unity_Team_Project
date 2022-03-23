using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_4 : Skill_Ori
{




    void Start_Func()
    {
        LevelUp();

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            for (int i = 0; i < 36; i++)
            {
                GameObject bullet3 = ObjectPooler.SpawnFromPool("Bullet_4", Player.transform.position, Quaternion.Euler(new Vector3(0, i * 10f, 0)));
                bullet3.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;
                //Rigidbody rigid3 = bullet3.GetComponent<Rigidbody>();
                //Vector3 ranvec = new Vector3(Mathf.Sin(Mathf.PI * 3 * i / 50), 0, Mathf.Cos(Mathf.PI * 3 * i / 50));
                //rigid3.velocity = ranvec.normalized * 10f;
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
