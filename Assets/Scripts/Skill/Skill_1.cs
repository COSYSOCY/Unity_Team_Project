using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : Skill_Ori
{
    
    void Start_Func() //시작시 설정
    {
        playerinfo.SkillCnt++;
        manager.Skill_All_Active.Add(gameObject);
        manager.Skill_Active.Add(gameObject);
        LevelUp();
        StartCoroutine(Skill_Update());
    }



    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 1; i <= info.bulletCnt; i++)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", bulletPos.transform.position, bulletPos.transform.rotation); 
                bullet.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;
                    if (i % 2 == 0)
                    {
                        bullet.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));
                    }
                    else
                    {
                        bullet.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));
                    }
            }
        }
    }


    private void OnEnable() // 중복방지용 버그처리용스크립트인데 신경쓰지마세요
    {
        if (start==false)
        {
        Start_Func();
            start = true;
        }
    }

}
