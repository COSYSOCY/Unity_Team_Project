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

        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {
        CreateUp = true;
    }
    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(14);
            StartCoroutine(Skill_Update2());
        }
    }

    IEnumerator Skill_Update2()
    {

        float local = _AtRange();
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;

                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(5f, 0f, 2f), Quaternion.Euler(new Vector3(0,90f,0)));
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.transform.localScale = new Vector3(local, local, local);
            GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(5f, 0f, -2f), Quaternion.Euler(new Vector3(0, 90f, 0)));
            bullet2.GetComponent<Bullet_Info>().damage = _Damage();
            bullet2.transform.localScale = new Vector3(local, local, local);

            yield return new WaitForSeconds(0.3f);
                    GameObject bullet3 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(-5f, 0f,2), Quaternion.Euler(new Vector3(0, -90f, 0)));
                    bullet3.GetComponent<Bullet_Info>().damage = _Damage();
                    bullet3.transform.localScale = new Vector3(local, local, local);
            GameObject bullet4 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(-5f, 0f,-2f), Quaternion.Euler(new Vector3(0, -90f, 0)));
            bullet4.GetComponent<Bullet_Info>().damage = _Damage();
            bullet4.transform.localScale = new Vector3(local, local, local);
        if (CreateUp)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject bullet5 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(5f, 0f, 8f), Quaternion.Euler(new Vector3(0, 90f, 0)));
            bullet5.GetComponent<Bullet_Info>().damage = _Damage();
            bullet5.transform.localScale = new Vector3(local, local, local);
            GameObject bullet6 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(5f, 0f, 4f), Quaternion.Euler(new Vector3(0, 90f, 0)));
            bullet6.GetComponent<Bullet_Info>().damage = _Damage();
            bullet6.transform.localScale = new Vector3(local, local, local);

            yield return new WaitForSeconds(0.3f);
            GameObject bullet7 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(-5f, 0f, 8), Quaternion.Euler(new Vector3(0, -90f, 0)));
            bullet7.GetComponent<Bullet_Info>().damage = _Damage();
            bullet7.transform.localScale = new Vector3(local, local, local);
            GameObject bullet8 = ObjectPooler.SpawnFromPool("Bullet_7", pos + new Vector3(-5f, 0f, 4f), Quaternion.Euler(new Vector3(0, -90f, 0)));
            bullet8.GetComponent<Bullet_Info>().damage = _Damage();
            bullet8.transform.localScale = new Vector3(local, local, local);
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
