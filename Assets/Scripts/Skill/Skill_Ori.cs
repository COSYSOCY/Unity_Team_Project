using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ori : MonoBehaviour
{
    public PlayerInfo playerinfo;
    public GameObject Player; //플레이어
    public GameObject bulletPrefab; //총알Prefab
    public SkillManager manager;
    public Transform bulletPos;//총알생성위치 (따로 생성되는위치가 필요할때 사용)
    public Skill_Info info;
    public float Cool_Main;
    public float Cool_sub1;
    public float Cool_sub2;
    protected bool start = false;


    /*
float _Damage() // 데미지
int _BulletCnt() // 투사체수
float _BulletSpeed() // 투사체이동속도
int _BulletPie() // 투사체관통
float _BulletAtCri() // 크리확률
float _CoolMain(bool b) // b가 true이면 쿨감적용
float _CoolSub1(bool b) // b가 true이면 쿨감적용
float _CoolSub2(bool b) // b가 true이면 쿨감적용
float _AtRange() // 공격범위인데 쓸사람만 쓰세요 이걸로 크기를 조절하는방향?
float _SkillReal1() // 실수1 저장 따로할사람만
float _SkillReal2() // 실수2 저장 따로할사람만
float _SkillReal3() // 실수3 저장 따로할사람만
---
이밑은 info.붙여서 써야합니다 쓸사람만
int Lv; // 레벨
int Index; // 인덱스
int bulletCntMax; // 투사체 최대갯수
예시 ( info.bulletCntMax )
     */

    protected float _Damage()
    {
        float d;
        d= Random.Range(info.DamageMin, info.DamageMax);
        d = d + (d * (GameInfo.DamagePlus * 0.01f));
        return d;
    }

    protected int _BulletCnt()
    {
        int i;
        i = info.bulletCnt + GameInfo.BulletCntPlus;
        return i;
    }
    protected float _BulletSpeed()
    {
        float d;
        d = Random.Range(info.DamageMin, info.DamageMax);
        d = d + (d * (GameInfo.BulletSpeedPlus * 0.01f));
        return d;
    }
    protected int _BulletPie()
    {
        int i;
        i = info.BulletPie ;
        return i;
    }

    protected float _BulletAtCri()
    {
        float f;
        f = info.BulletAtCri;
        return f;
    }
    protected float _CoolMain(bool b) // b 가 true면 쿨감 적용
    {
         float f;
         float f2;
        f = info.CoolMain;
        if (!b)
        {
            return f;
        }
        
        f2 = GameInfo.SkillCoolPlus;//나중에 장신구 추가할꺼
        Mathf.Clamp(f2, 0, 50f);
        f2 = (100 - f2)*0.01f;
        f *= f2;
        return f;
    }
    protected float _CoolSub1(bool b) // b 가 true면 쿨감 적용
    {
        float f;
        float f2;
        f = info.CoolSub1;
        if (!b)
        {
            return f;
        }

        f2 = GameInfo.SkillCoolPlus;//나중에 장신구 추가할꺼
        Mathf.Clamp(f2, 0, 50f);
        f2 = (100 - f2) * 0.01f;
        f *= f2;
        return f;
    }
    protected float _CoolSub2(bool b) // b 가 true면 쿨감 적용
    {
        float f;
        float f2;
        f = info.CoolSub2;
        if (!b)
        {
            return f;
        }

        f2 = GameInfo.SkillCoolPlus;//나중에 장신구 추가할꺼
        Mathf.Clamp(f2, 0, 50f);
        f2 = (100 - f2) * 0.01f;
        f *= f2;
        return f;
    }
    protected float _AtRange()
    {
        float f;
        f = info.AtRange;
        return f;
    }

    protected float _SkillReal1()
    {
        float f;
        f = info.SkillReal1;
        return f;
    }
    protected float _SkillReal2()
    {
        float f;
        f = info.SkillReal2;
        return f;
    }
    protected float _SkillReal3()
    {
        float f;
        f = info.SkillReal3;
        return f;
    }
    public void LevelUp()
    {
        

        info.Lv++;
        info.DamageMin = info.DamageCheckMin[info.Lv];
        info.DamageMax = info.DamageCheckMax[info.Lv];
        info.bulletCnt = info.BulletCntCheck[info.Lv];
        info.bulletCntMax = info.BulletCntMaxCheck[info.Lv];
        info.BulletSpeed = info.DamageCheckMin[info.Lv];
        info.BulletPie = info.BulletPieCheck[info.Lv];
        info.BulletAtCri = info.BulletAtCriCheck[info.Lv];
        info.CoolMain = info.CoolMainCheck[info.Lv];
        info.CoolSub1 = info.CoolSub1Check[info.Lv];
        info.CoolSub2 = info.CoolSub2Check[info.Lv];
        info.AtRange = info.AtRangeCheck[info.Lv];
        info.SkillReal1 = info.SkillReal1Check[info.Lv];
        info.SkillReal2 = info.SkillReal2Check[info.Lv];
        info.SkillReal3 = info.SkillReal3Check[info.Lv];

    }

}
