using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_27 : Skill_Ori
{

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2������ �ɰ�� ����
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
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
    }
    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
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

        float f1 = 0f;

        for (int i = 1; i <= _BulletCnt(); i++)
        {
            float ff = 0f;
            if (Player.transform.rotation.eulerAngles.y >= 180)
            {
                ff = -1f;
            }
            Vector3 pos = bulletPos.transform.position;
            pos.y = 1;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_27", pos + new Vector3(5f * ff, 0f, f1), Quaternion.Euler(new Vector3(0, 90f, 0)));

            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.transform.localScale = new Vector3(local, local, local);
            if (CreateUp)
            {
                GameObject bullet3 = ObjectPooler.SpawnFromPool("Bullet_27", pos + new Vector3(f1, 0f, 2), Quaternion.Euler(new Vector3(0, 0f, 0)));

                bullet3.GetComponent<Bullet_Info>().damage = _Damage();
                bullet3.transform.localScale = new Vector3(local, local, local);
            }
            yield return new WaitForSeconds(0.2f);
            if (i % 2 == 0)
            {
                pos = bulletPos.transform.position;
                pos.y = 1;
                if (Player.transform.rotation.eulerAngles.y >= 180)
                {
                    ff = 1f;
                }
                GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_27", pos + new Vector3(5f * ff, 0f, f1), Quaternion.Euler(new Vector3(0, -90f, 0)));
                bullet2.GetComponent<Bullet_Info>().damage = _Damage();
                bullet.transform.localScale = new Vector3(local, local, local);
                yield return new WaitForSeconds(0.2f);
                f1 += 2f;
                if (CreateUp)
                {
                    GameObject bullet3 = ObjectPooler.SpawnFromPool("Bullet_27", pos + new Vector3(f1, 0f, -2), Quaternion.Euler(new Vector3(0, 180f, 0)));

                    bullet3.GetComponent<Bullet_Info>().damage = _Damage();
                    bullet3.transform.localScale = new Vector3(local, local, local);
                }
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
