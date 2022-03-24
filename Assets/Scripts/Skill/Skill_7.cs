using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_7 : Skill_Ori
{

    //public GameObject birdbulletprefabs;
    public GameObject birdtarget;

    public GameObject Dack;
    //GameObject bird;
    public bool startcheck;








    void Start_Func()
    {
        LevelUp();
        manager.skill_Add(gameObject, info.Skill_Icon);
        StartCoroutine(Skill_Update2());
        StartCoroutine(Skill_Update());
        //bird = Instantiate(Dack, Player.transform.position, Dack.transform.rotation);
        birdtarget.SetActive(true);

    }
    IEnumerator Skill_Update2()
    {
        while (true)
        {
            if (!startcheck)
            {
                startcheck = true;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                startcheck = false;
                yield return new WaitForSeconds(Cool_Main);
            }


        }
    }

    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (startcheck)
            {



                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_7", Player.transform.position, Player.transform.rotation);
                //Vector3 dir = Player.transform.position - bird.transform.position;
                Vector3 dir = Player.transform.position - new Vector3(0f, 2.0f, 0f); ;
                    //Vector3 moveVector = new Vector3(dir.x * 50f * Time.deltaTime, -1.0f, dir.z * 50f * Time.deltaTime);
                    //Vector3 moveVector = new Vector3(0f, -1.0f, 0f);
                    bullet.transform.position = dir;
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                //Destroy(bullet, 0.5f);

            }
            
        }
    }


    private void OnEnable()
    {
        if (start == false && info.goodstart)
        {
            Start_Func();
            start = true;
        }
    }
}
