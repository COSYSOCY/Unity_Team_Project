using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_7 : Skill_Ori
{

    public GameObject birdbulletprefabs;
    public GameObject birdtarget;
    public GameObject Dack;
    GameObject bird;

    public override void LevelUp()
    {
        switch (info.Lv)
        {
            case 0:
                //아무것도아님
                break;
            case 1:
                //..;
                break;
            case 2:
                //..;
                break;
            case 3:
                //..
                break;
            case 4:
                //.
                break;
            case 5:
                //.
                break;
            case 6:
                //.
                break;
            case 7:
                //.
                break;
            default:
                break;
        }

        info.Lv++;
    }







    void Start_Func()
    {
        //시작시 설정
        info.Lv = 1;
        info.bulletCnt = 1;
        info.Damage = 1f;
        StartCoroutine(Skill_Update());
        bird = Instantiate(Dack, Dack.transform.position, Dack.transform.rotation);
        bird.transform.SetParent(Player.transform, false);
        birdtarget.SetActive(true);
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject bullet = Instantiate(birdbulletprefabs, bird.transform.position, bird.transform.rotation);
            bullet.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;
        }
    }


    private void OnEnable()
    {
        if (start == false)
        {
            Start_Func();
            start = true;
        }
    }
}
