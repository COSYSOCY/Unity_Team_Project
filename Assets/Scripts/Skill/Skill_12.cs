using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_12 : Skill_Ori
{

    public GameObject gidomon;


    void Start_Func()
    {
        LevelUp();

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(Cool_Main);
            GameObject bullet = Instantiate(gidomon, Player.transform.position, Player.transform.rotation);
            bullet.GetComponent<gidomon>().numberOfObjects = info.bulletCnt;
            bullet.transform.SetParent(Player.transform, true);
            bullet.GetComponent<gidomon>().Dagame = info.Damage;
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