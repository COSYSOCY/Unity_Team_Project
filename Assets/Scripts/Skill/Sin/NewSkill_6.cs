using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_6 : Skill_Ori
{
    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
        
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
            for (int i = 0; i < _BulletCnt(); i++)
            {
            StartCoroutine(Skill_Update2());

            }
        }
    }
    IEnumerator Skill_Update2()
    {
        float da = _Damage();
        if (MainSingleton.instance.playerstat.SkillItemactive[8] >= 1)
        {
            da *= 1.2f;
        }
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
                    Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(da);
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
