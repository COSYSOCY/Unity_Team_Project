using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_28 : Skill_Ori
{
    string bulletname = "Bullet_0";
    float upScale = 0;
    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();
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
        bulletname = "Bullet_0_1";
        upScale = 0.5f;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
        Debug.Log("테스트");
    }
    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }

    }

    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());

        }
    }

    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange() + upScale;
        for (int i = 1; i <= _BulletCnt(); i++)
        {


            GameObject bullet = ObjectPooler.SpawnFromPool(bulletname, Player.transform.position, bulletPos.transform.rotation);
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
            if (i % 2 == 0)
            {
                bullet.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));

                bullet.GetComponent<Bullet_Info>().KnokTime = 0.1f;


                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
                bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                bullet.transform.localScale = new Vector3(local, local, local);
            }
            else
            {
                bullet.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));

                bullet.GetComponent<Bullet_Info>().KnokTime = 0.2f;

                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
                bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                bullet.transform.localScale = new Vector3(local, local, local);
            }

            if (CreateUp)
            {
                GameObject bullet2 = ObjectPooler.SpawnFromPool(bulletname, Player.transform.position, bulletPos.transform.rotation);
                bullet2.transform.Translate(Vector3.back * 4f);
                bullet2.GetComponent<Bullet_Info>().damage = _Damage();
                bullet2.GetComponent<Bullet_Info>().pie = _BulletPie();
                if (i % 2 == 0)
                {
                    bullet2.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));

                    bullet2.GetComponent<Bullet_Info>().KnokTime = 0.2f;


                    bullet2.GetComponent<Bullet_Info>().move = _BulletSpeed();
                    bullet2.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                    bullet2.transform.localScale = new Vector3(local, local, local);
                }
                else
                {
                    bullet2.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));

                    bullet2.GetComponent<Bullet_Info>().KnokTime = 0.2f;

                    bullet2.GetComponent<Bullet_Info>().move = _BulletSpeed();
                    bullet2.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                    bullet2.transform.localScale = new Vector3(local, local, local);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnEnable() // 중복방지용 버그처리용스크립트인데 신경쓰지마세요
    {
        if (start == false && info.goodstart)
        {
            Start_Func();
            start = true;
        }
    }

}
