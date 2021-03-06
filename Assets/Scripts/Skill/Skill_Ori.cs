using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skill_Ori : MonoBehaviour
{
    public PlayerInfo playerinfo;
    public GameObject Player; //플레이어
    //public GameObject bulletPrefab; //총알Prefab
    public SkillManager manager;
    public Transform bulletPos;//총알생성위치 (따로 생성되는위치가 필요할때 사용)
    public Skill_Info info;
    public LayerMask layermask;
    protected bool start = false;
    public bool CreateUp = false;
    protected SkillCoolTimeSystem CoolTimesystem;


    /*
float _Damage() // 데미지
int _BulletCnt() // 투사체수
float _BulletSpeed() // 투사체이동속도
float _BulletTime() // 투사체 지속시간
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

    protected float _Damage(float CriAdd = 0f)
    {
        float d;
        float d2;
        float d3;
        d= Random.Range(info.DamageMin, info.DamageMax);
        d2 = GameInfo.DamagePlus + manager.AtPlus()+CardStat.inst.CardStat_DamageP()+ playerinfo.Bonus_Dmg+ PowerUpInfo.instance._Dmg();
        d3 = info.BulletAtCri;
        if (Random.Range(0,100f) <= info.BulletAtCri+manager.DmgPer() + CardStat.inst.CardStat_DmgPer()+ PowerUpInfo.instance._Cri()+playerinfo.Bonus_Cri+ CriAdd)
        {
            d2 += 50f;
        }
        d = d + (d * (d2 * 0.01f));
        return d;
    }

    protected int _BulletCnt()
    {
        int i;
        i = info.bulletCnt + GameInfo.BulletCntPlus + manager.BulletCnt()+ CardStat.inst.CardStat_BtCnt() + PowerUpInfo.instance._BtCnt()+ playerinfo.Bonus_BtCnt;
        return i;
    }
    protected float _BulletSpeed()
    {
        float d;
        float d2;
        d = info.BulletSpeed;
        d2 = GameInfo.BulletSpeedPlus+manager.BulletSpeed()+CardStat.inst.CardStat_BuSpeed()+ PowerUpInfo.instance._BtSpeed()+playerinfo.Bonus_BtSpeed;
        d = d + (d * (d2 * 0.01f));
        return d;
    }
    protected float _BulletTime()
    {
        float d;
        float d2;
        d = info.BulletTime;
        d2 = GameInfo.BulletTimePlus + manager.BulletTime() + CardStat.inst.CardStat_BuTime() + PowerUpInfo.instance._BtTime()+playerinfo.Bonus_BtTime;
        d = d + (d * (d2 * 0.01f));
        return d;
    }
    protected int _BulletPie()
    {
        int i;
        i = info.BulletPie+manager._Pie() ;
        return i;
    }

    protected float _BulletAtCri()
    {
        float f;
        f = info.BulletAtCri;
        return f;
    }
    /// <summary>
    /// 전체적인 쿨다운
    /// </summary>
    /// <param name="b"> b가 true면 쿨감적용</param>
    /// <returns></returns>
    public float _CoolMain(bool b) // b 가 true면 쿨감 적용
    {
         float f;
         float f2;
        f = info.CoolMain;
        if (!b)
        {
            return f;
        }
        
        f2 = GameInfo.SkillCoolPlus+manager.Cool()+ CardStat.inst.CardStat_Cool()+ PowerUpInfo.instance._Cool()+playerinfo.Bonus_Cool;
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

        f2 = GameInfo.SkillCoolPlus + manager.Cool() + CardStat.inst.CardStat_Cool() + PowerUpInfo.instance._Cool();
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

        f2 = GameInfo.SkillCoolPlus + manager.Cool() + CardStat.inst.CardStat_Cool() + PowerUpInfo.instance._Cool();
        Mathf.Clamp(f2, 0, 50f);
        f2 = (100 - f2) * 0.01f;
        f *= f2;
        return f;
    }
    protected float _AtRange()
    {
        float f;
        float f2;
        f = info.AtRange;
        f2 = GameInfo.Attack_RangePlus + manager.AtRange()+CardStat.inst.CardStat_AttackRange() + PowerUpInfo.instance._AtRange()+playerinfo.Bonus_AtRange;
        f = f + (f * (f2 * 0.01f));
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
    public virtual void LevelUpFunc()
    {

    }
    public virtual void CreateFunc()
    {

    }
    public void LevelUp()
    {

        int i = 0;
        info.Lv++;
        if (info.Lv>= info.LvMax)
        {
            info.Lv = info.LvMax;
        }
        MainSingleton.instance.playerstat.Skillactive[info.Index]++;
        i = info.Lv - 1;
        info.DamageMin = info.DamageCheckMin[i];
        info.DamageMax = info.DamageCheckMax[i];
        info.bulletCnt = info.BulletCntCheck[i];
        info.bulletCntMax = info.BulletCntMaxCheck[i];
        info.BulletSpeed = info.BulletSpeedCheck[i];
        info.BulletPie = info.BulletPieCheck[i];
        info.BulletTime = info.BulletTimeCheck[i];
        info.BulletAtCri = info.BulletAtCriCheck[i];
        info.CoolMain = info.CoolMainCheck[i];
        info.CoolSub1 = info.CoolSub1Check[i];
        info.CoolSub2 = info.CoolSub2Check[i];
        info.AtRange = info.AtRangeCheck[i];
        info.SkillReal1 = info.SkillReal1Check[i];
        info.SkillReal2 = info.SkillReal2Check[i];
        info.SkillReal3 = info.SkillReal3Check[i];
        LevelUpFunc();
        if (CoolTimesystem ==null)
        {
            CoolTimesystem = MainSingleton.instance.CoolTimeSystem[manager.Skill_Active.Count-1];
            CoolTimesystem.startFUnc(info.Skill_Icon);
        }
    }


}
