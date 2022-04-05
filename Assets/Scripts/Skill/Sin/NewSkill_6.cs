using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_6 : Skill_Ori
{
    float UpDamage=1f;
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
        UpDamage = 2f;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
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
            SoundManager.inst.SoundPlay(13);
            for (int i = 0; i < _BulletCnt(); i++)
            {
            StartCoroutine(Skill_Update2());

            }
        }
    }
    IEnumerator Skill_Update2()
    {
        yield return null;
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_6", pos, Quaternion.Euler(new Vector3(0, Random.Range(0, 360f))));
        bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
        bullet.GetComponent<Bullet_Info>().move = _BulletSpeed()/2;
        while (bullet.activeSelf)
        {
            yield return new WaitForSeconds(0.4f);
            Vector3 pos2 = bullet.transform.position;
            pos2.y = 0;
            GameObject effect = ObjectPooler.SpawnFromPool("Bullet_6_1", pos2, Quaternion.identity);
            effect.transform.localScale = new Vector3(local, local, local);
            Collider[] Enemys;
            Enemys = Physics.OverlapSphere(pos2, effect.transform.lossyScale.x * _AtRange(), layermask);
            if (Enemys.Length > 0)
            {
                for (int i = 0; i < Enemys.Length; i++)
                {
                    Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage()*UpDamage);
                }
            }
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
