using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_29 : Skill_Ori
{
    float angleRange;
    float upangleRange;
    public GameObject bullet;
    public bool stop = false;




    public ParticleSystem partic;

    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
        //bullet.SetActive(true);

        //

        angleRange = 80f; // 각도
                          //coroutine = Skill_Update2();
        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {
        CreateUp = true;
        StopAllCoroutines();
        StartCoroutine(Skill_Update4());
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
            if (stop)
            {
                yield break;
            }
            yield return new WaitForSeconds(_CoolMain(true));
            if (stop)
            {
                yield break;
            }
            bullet.SetActive(true);
            SoundManager.inst.SoundPlay(11);
            yield return null;
            StartCoroutine(Skill_Update2());
            StartCoroutine(Skill_Update3());



        }
    }
    IEnumerator Skill_Update3()
    {
        if (stop)
        {
            yield break;
        }
        yield return new WaitForSeconds(_CoolSub2(false));
        if (stop)
        {
            yield break;
        }
        bullet.SetActive(false);
        //StopCoroutine(coroutine);
    }
    IEnumerator Skill_Update4()
    {
        yield return new WaitForSeconds(0.5f);
        bullet.SetActive(true);
        while (true)
        {
            
            Vector3 pos = bulletPos.transform.position;
            pos.y = 1;
            Collider[] Enemys;
            Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x * _AtRange() * 2.5f, layermask);
            if (Enemys.Length > 0)
            {
                for (int i = 0; i < Enemys.Length; i++)
                {
                    float dotValue = Mathf.Cos(Mathf.Deg2Rad * ((angleRange + upangleRange) / 2));
                    Vector3 direction = Enemys[i].transform.position - bulletPos.transform.position;
                    direction.Normalize();
                    if (Vector3.Dot(direction, Player.transform.forward) > dotValue)
                    {
                        Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());

                    }
                }

            }

            yield return new WaitForSeconds(_CoolSub1(false));
        }
    }
    IEnumerator Skill_Update2()
    {
        yield return new WaitForSeconds(0.1f);
        while (bullet.activeSelf)
        {
            if (stop)
            {
                yield break;
            }
            Vector3 pos = bulletPos.transform.position;
            pos.y = 1;
            Collider[] Enemys;
            Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x * _AtRange() * 2f, layermask);
            if (Enemys.Length > 0)
            {
                for (int i = 0; i < Enemys.Length; i++)
                {
                    float dotValue = Mathf.Cos(Mathf.Deg2Rad * ((angleRange + upangleRange) / 2));
                    Vector3 direction = Enemys[i].transform.position - bulletPos.transform.position;
                    direction.Normalize();
                    if (Vector3.Dot(direction, Player.transform.forward) > dotValue)
                    {
                        Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());

                    }
                }

            }

            yield return new WaitForSeconds(_CoolSub1(false));
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
