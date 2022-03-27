using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : Skill_Ori
{
    
    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject,info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv==2) // 2레벨이 될경우 실행
        {

        }
    }

    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(Skill_Update2());
        }
    }
    float damage()
    {
        float f = _Damage();
        
        if (GameInfo.inst.PlayerCardCheck[8]>0)
        {
            f = f + (GameInfo.inst.PlayerCardCheck[8] * f);
        }
        return f;
    }
    IEnumerator Skill_Update2()
    {
        for (int i = 1; i <= _BulletCnt(); i++)
        {
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", bulletPos.transform.position, bulletPos.transform.rotation);
            bullet.GetComponent<Bullet_Info>().damage = damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
            if (i % 2 == 0)
            {
                bullet.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));
            }
            else
            {
                bullet.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnEnable() // 중복방지용 버그처리용스크립트인데 신경쓰지마세요
    {
        if (start==false&&info.goodstart)
        {
        Start_Func();
            start = true;
        }
    }

}
