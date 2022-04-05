using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_18 : Skill_Ori
{


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

    public Vector3 RandomSphereInPoint(float radius)
    {
        //Random.onUnitSphere : 반경 1을 갖는 구의 표면상에서 임의의 지점을 반환합니다. (읽기 전용)
        Vector3 getPoint = Random.onUnitSphere;
        getPoint.y = 0.0f;

        // 0.0f 부터 지정한 반지름의 길이 사이의 랜덤한 값 추출.
        float r = Random.Range(0.0f, radius);

        // 현재 이 위치만큼 평행이동이 필요하므로. position을 더해준다.
        return (getPoint * r) + Player.transform.position;
    }


    IEnumerator Skill_Update2()
    {
        float local = _AtRange();
        for (int i = 0; i < _BulletCnt(); i++)
        {
            Vector3 pos = RandomSphereInPoint(20f);
            pos.y = 0;
            Collider[] Enemys;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_18", pos, Quaternion.identity);
            bullet.transform.localScale = new Vector3(local, local, local);
            Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x * local, layermask);
            if (Enemys.Length > 0)
            {
                for (int a = 0; a < Enemys.Length; i++)
                {
                    Enemys[a].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
                }
            }

            yield return null;
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
