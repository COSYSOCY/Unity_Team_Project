using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_7 : Skill_Ori
{


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
        StartCoroutine(Skill_Update());
        
    }
    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());
            SoundManager.inst.SoundPlay(12);
        }
    }

    IEnumerator Skill_Update2()
    {
        float local = _AtRange();
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;

                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(5f, 0f, 2f), Quaternion.identity);
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.transform.localScale = new Vector3(local, local, local);
            GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(5f, 0f, -2f), Quaternion.identity);
            bullet2.GetComponent<Bullet_Info>().damage = _Damage();
            bullet2.transform.localScale = new Vector3(local, local, local);

            yield return new WaitForSeconds(0.1f);
                    GameObject bullet3 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(-5f, 0f,2), Quaternion.identity);
                    bullet3.GetComponent<Bullet_Info>().damage = _Damage();
                    bullet3.transform.localScale = new Vector3(local, local, local);
            GameObject bullet4 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(-5f, 0f,-2f), Quaternion.identity);
            bullet4.GetComponent<Bullet_Info>().damage = _Damage();
            bullet4.transform.localScale = new Vector3(local, local, local);

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
