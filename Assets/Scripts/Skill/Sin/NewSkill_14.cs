using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_14 : Skill_Ori
{
    float Upscale = 0f;
    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject,info.Skill_Icon);
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
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
        Upscale = 5f;
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv==2) // 2레벨이 될경우 실행
        {

        }
        if (info.Lv == 8) // 8레벨이 될경우 실행
        {
            //8 레벨 획득
            if (GameInfo.inst.Player_Mission[22] == 0)
            {
                GameInfo.inst.MissionGo(22);
            }
        }
    }

    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {
        
        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());
        }
    }
    IEnumerator Skill_Update2()
    {
        float local = _AtRange()+ Upscale;
        Vector3 pos = bulletPos.transform.position;
        pos.y = 0;
        Collider[] Enemys;
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_14", pos, Quaternion.identity);
        bullet.transform.localScale = new Vector3(local, local, local);
        Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x* local, layermask);
        if (Enemys.Length >0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                if (Enemys[i].transform.CompareTag("DeOb"))
                {
                    Enemys[i].transform.GetComponent<DeObjectSystem>().Damaged(_Damage());
                }
                else
                {
                Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());

                }
            }
        }

        yield return null;
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
