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

    float Range()
    {
        float d = _AtRange();
        int i = GameInfo.inst.PlayerCardCheck[17];
        //GameInfo.inst.CardsInfo[17].CardStat_Real1
        float d_C = 0;
        float d_P = i * GameInfo.inst.CardsInfo[17].CardStat_Real1;
        d = d + d_C;
        d = d + (d * d_P * 0.01f);

        return d;
    }

    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(13);
            for (int i = 0; i < _BulletCnt()+GameInfo.inst.PlayerCardCheck[78]; i++)
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
        float local = Range();
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_6", pos, Quaternion.Euler(new Vector3(0, Random.Range(0, 360f))));
        bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
        bullet.GetComponent<Bullet_Info>().move = _BulletSpeed()/2;
        while (bullet.activeSelf)
        {
            
            Vector3 pos2 = bullet.transform.position;
            pos2.y = 0;
            GameObject effect = ObjectPooler.SpawnFromPool("Bullet_6_1", bullet.transform.position, Quaternion.identity);
            effect.transform.localScale = new Vector3(local, local, local);
            Collider[] Enemys;
            Enemys = Physics.OverlapSphere(pos2, Player.transform.lossyScale.x* _AtRange()*0.5f, layermask);
            if (Enemys.Length > 0)
            {
                for (int i = 0; i < Enemys.Length; i++)
                {
                    if (Enemys[i].transform.CompareTag("DeOb"))
                    {
                        Enemys[i].transform.GetComponent<DeObjectSystem>().Damaged(_Damage());
                    }
                    else
                    {

                    Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage()*UpDamage);
                    }
                }
            }
            yield return new WaitForSeconds(0.3f);
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
