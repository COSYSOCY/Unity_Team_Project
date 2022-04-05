using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_3 : Skill_Ori
{
    float UpRange;


    public GameObject partic1;
    public GameObject bullet;
    void Start_Func() //시작시 설정
    {
            SoundManager.inst.SoundPlay(10);
        manager.skill_Add(gameObject,info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
        
        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
        else
        {
            bullet.SetActive(true);
        }
    }
    public override void CreateFunc()
    {

            bullet.gameObject.SetActive(false);
            partic1.gameObject.SetActive(true);
        UpRange = 2;
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
            yield return new WaitForSeconds(_CoolMain(false));

            float ar = _AtRange();

            StartCoroutine(Skill_Update2());
        }
        

    }
    IEnumerator Skill_Update2()
    {

        Vector3 pos = bulletPos.transform.position;
        pos.y = 0;
        Collider[] Enemys;
        Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x*_AtRange()+ UpRange, layermask);
        if (Enemys.Length >0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
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
