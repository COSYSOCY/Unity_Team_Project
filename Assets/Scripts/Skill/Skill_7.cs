using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_7 : Skill_Ori
{

    //public GameObject birdbulletprefabs;
    public GameObject birdtarget;

    public GameObject Dack;
    //GameObject bird;



    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }
    }




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
        for (int i = 0; i < 10; i++)
        {
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_7", Player.transform.position, Player.transform.rotation);
            //Vector3 dir = Player.transform.position - bird.transform.position;
            Vector3 dir = Player.transform.position;// - new Vector3(0f, 2.0f, 0f); ;
                                                    //Vector3 moveVector = new Vector3(dir.x * 50f * Time.deltaTime, -1.0f, dir.z * 50f * Time.deltaTime);
                                                    //Vector3 moveVector = new Vector3(0f, -1.0f, 0f);
            bullet.transform.position = dir;
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            yield return new WaitForSeconds(0.1f);
            //Destroy(bullet, 0.5f);
        }
    }

    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());
            
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
