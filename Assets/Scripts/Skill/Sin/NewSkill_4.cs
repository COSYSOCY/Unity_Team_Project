using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_4 : Skill_Ori
{
    float angleRange;
    float upangleRange;
    public GameObject bullet;
    public GameObject upbullet1;
    public GameObject upbullet2;
    IEnumerator coroutine;



    public ParticleSystem partic;

    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject,info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
        //bullet.SetActive(true);

        //
        
        angleRange = 50f; // 각도
                          //coroutine = Skill_Update2();
        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {
        //partic.startSize *= 1.2f;
        upangleRange = 50f;
        upbullet1.SetActive(true);
        upbullet2.SetActive(true);
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv==2) // 2레벨이 될경우 실행
        {

        }
        
    }

    float damage()
    {
        float d = _Damage();
        int i = GameInfo.inst.PlayerCardCheck[18];
        int i2 = GameInfo.inst.PlayerCardCheck[77];
        //GameInfo.inst.CardsInfo[17].CardStat_Real1
        float d_C = 0;
        float d_P = (i * GameInfo.inst.CardsInfo[18].CardStat_Real1)+(i2* GameInfo.inst.CardsInfo[77].CardStat_Real1);
        d = d + d_C;
        d = d + (d * d_P * 0.01f);

        return d;
    }


    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {
        
        while (true)
        {

            yield return new WaitForSeconds(_CoolMain(true));
            bullet.SetActive(true);
            SoundManager.inst.SoundPlay(11);
            yield return null;
            StartCoroutine(Skill_Update2());
            StartCoroutine(Skill_Update3());



        }
    }
    IEnumerator Skill_Update3()
    {
        yield return new WaitForSeconds(_CoolSub2(false));
        bullet.SetActive(false);
        //StopCoroutine(coroutine);
    }
    IEnumerator Skill_Update2()
    {
        yield return new WaitForSeconds(0.1f);
        while (bullet.activeSelf)
        { 
            Vector3 pos = bulletPos.transform.position;
            pos.y = 1;
            Collider[] Enemys;
            Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x*_AtRange()*3f, layermask);
            if (Enemys.Length >0)
            {
                for (int i = 0; i < Enemys.Length; i++)
                {
                    float dotValue = Mathf.Cos(Mathf.Deg2Rad * ((angleRange+ upangleRange) / 2));
                    Vector3 direction = Enemys[i].transform.position - bulletPos.transform.position;
                    direction.Normalize();
                    if (Vector3.Dot(direction,Player.transform.forward)>dotValue)
                    {
                    Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(damage());

                    }
                }
               
             }

        yield return new WaitForSeconds(_CoolSub1(false));
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
