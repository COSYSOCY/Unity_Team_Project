using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_4 : Skill_Ori
{
    float angleRange;
    public GameObject bullet;
    IEnumerator coroutine;
    void Start_Func() //시작시 설정
    {
        manager.skill_Add(gameObject,info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
        bullet.SetActive(true);

        //

        angleRange = 45f; // 각도
        //coroutine = Skill_Update2();
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

            yield return new WaitForSeconds(_CoolMain(true));
            bullet.SetActive(true);
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
        while(bullet.activeSelf)
        { 
            Vector3 pos = bulletPos.transform.position;
            pos.y = 1;
            Collider[] Enemys;
            Enemys = Physics.OverlapSphere(pos, Player.transform.lossyScale.x*_AtRange(), layermask);
            if (Enemys.Length >0)
            {
                for (int i = 0; i < Enemys.Length; i++)
                {
                    float dotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));
                    Vector3 direction = Enemys[i].transform.position - bulletPos.transform.position;
                    direction.Normalize();
                    if (Vector3.Dot(direction,Player.transform.forward)>dotValue)
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
        if (start==false&&info.goodstart)
        {
        Start_Func();
            start = true;
        }
    }

}
