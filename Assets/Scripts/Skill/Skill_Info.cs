using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Info : MonoBehaviour
{
    public int Index; // 인덱스
    public int Index_Text; // 텍스트스킬번호인덱스
    [Space(16)]
    [Header("수치")]
    public int Lv; // 레벨
    public float Damage; // 데미지
    public float DamageMin; // 최대데미지
    public float DamageMax; // 최소데미지
    public int bulletCnt; // 투사체수
    public int bulletCntMax; // 투사체최대수
    public float BulletSpeed; // 투사체속도
    public int BulletPie; // 투사체관통수
    public float BulletAtCri; // 치명타확률
    public float CoolMain; // 쿨타임 메인
    public float CoolSub1; // 쿨타임 서브1
    public float CoolSub2; // 쿨타임 서브2
    public float AtRange; // 공격범위
    public float SkillReal1; // 실수1
    public float SkillReal2; // 실수2
    public float SkillReal3; // 실수3


    [Space(16)]
    [Header("스킬설명")]
    public string Skill_Name; // 스킬 이름
    public List<string> Lv_Text; // 스킬 업그레이드 설명
    public int Skill_Icon; // 아이콘번호
    [Space(25)]
    [Header("체크하는부분")]
    protected bool start = false;
    public List<float> DamageCheckMin=new List<float>();
    public List<float> DamageCheckMax=new List<float>();
    public List<int> BulletCntCheck=new List<int>();
    public List<int> BulletCntMaxCheck=new List<int>();
    public List<float> BulletSpeedCheck=new List<float>();
    public List<int> BulletPieCheck=new List<int>();
    public List<float> BulletAtCriCheck=new List<float>();
    public List<float> CoolMainCheck=new List<float>();
    public List<float> CoolSub1Check=new List<float>();
    public List<float> CoolSub2Check=new List<float>();
    public List<float> AtRangeCheck=new List<float>();
    public List<float> SkillReal1Check=new List<float>();
    public List<float> SkillReal2Check=new List<float>();
    public List<float> SkillReal3Check=new List<float>();

    void Awake()
    {
        Skill_Name = csvData.GameText(csvData.SkillNameNum[Index_Text]);
        Skill_Icon = csvData.SkillIconNum[Index_Text];
        bulletCntMax=csvData.SkillBulletCntMax[Index_Text];
        for (int i = Index_Text; i < Index_Text+ csvData.SkillMaxLevel[Index_Text]; i++)
        {
            int a= csvData.SkillInfoNum[i];
            Lv_Text.Add(csvData.GameText(a));
            DamageCheckMin.Add(csvData.SkillMinDamage[i]);
            DamageCheckMax.Add(csvData.SkillMaxDamage[i]);
            BulletCntCheck.Add(csvData.SkillBulletCnt[i]);
            BulletCntMaxCheck.Add(csvData.SkillBulletCntMax[i]);

            BulletSpeedCheck.Add(csvData.SkillBulletSpeed[i]);
            BulletPieCheck.Add(csvData.SkillBulletPie[i]);
            BulletAtCriCheck.Add(csvData.SkillCri[i]);
            CoolMainCheck.Add(csvData.SkillCoolTimeMain[i]);
            CoolSub1Check.Add(csvData.SkillCoolTimeSub1[i]);
            CoolSub2Check.Add(csvData.SkillCoolTimeSub2[i]);
            AtRangeCheck.Add(csvData.SkillAtRange[i]);
            SkillReal1Check.Add(csvData.SkillReal1[i]);
            SkillReal2Check.Add(csvData.SkillReal2[i]);
            SkillReal3Check.Add(csvData.SkillReal3[i]);



        }
        
    }

    public void LevelUpCheck()
    {
        switch (Index)
        {
            case 0:
                gameObject.GetComponent<Skill_1>().LevelUp();
                break;
            case 1:
                gameObject.GetComponent<Skill_2>().LevelUp();
                break;
            case 2:
                gameObject.GetComponent<Skill_3>().LevelUp();
                break;
            case 3:
                gameObject.GetComponent<Skill_4>().LevelUp();
                break;
            case 4:
                gameObject.GetComponent<Skill_5>().LevelUp();
                break;
            case 5:
                gameObject.GetComponent<Skill_6>().LevelUp();
                break;
            case 6:
                gameObject.GetComponent<Skill_7>().LevelUp();
                break;
            case 7:
                gameObject.GetComponent<Skill_8>().LevelUp();
                break;
            case 8:
                gameObject.GetComponent<Skill_9>().LevelUp();
                break;
            case 9:
                gameObject.GetComponent<Skill_10>().LevelUp();
                break;
            case 10:
                gameObject.GetComponent<Skill_11>().LevelUp();
                break;
            case 11:
                gameObject.GetComponent<Skill_12>().LevelUp();
                break;
            case 12:
                gameObject.GetComponent<Skill_13>().LevelUp();
                break;
            case 13:
                gameObject.GetComponent<Skill_14>().LevelUp();
                break;
            default:
                break;
        }

    }
}
