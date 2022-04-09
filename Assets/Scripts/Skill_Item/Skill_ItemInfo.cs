using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_ItemInfo : MonoBehaviour
{
    public int Index; // 인덱스
    public int Index_Text; // 텍스트스킬번호인덱스
    [Space(16)]
    [Header("수치")]
    public int Lv; // 레벨
    public int LvMax; // 레벨
    public float HpPlusC; // 체력증가(상수)
    public float HpPlusPer; // 체력증가(%)
    public float HpRegen; // 체력회복
    public float Defence; // 방어력상수
    public float AtPlus; // 데미지증가%
    public float Cool; // 쿨감소%
    public float AtRange; // 공격범위증가%
    public float Speed; // 이동속도증가%
    public int BulletCnt; // 투사체수증가
    public float GoldPlus; // 골드획득량%
    public float XpPlus; // 경험치획득량%
    public float BulletSpeed; // 투사체이동속도증가%
    public float BulletTime; // 투사체지속시간증가%
    public float Range; // 자석증가
    public float Real1; // 실수1
    public float Real2; // 실수2
    public int CreateIdx; // 실수2
    public int ActiveIdx; // 활성화 번째

    public int Pie; // 관통
    public float DmgPer; // 치명타



    [Space(16)]
    [Header("스킬설명")]
    public string Skill_Item_Name; // 스킬 이름
    public List<string> Lv_Text; // 스킬 업그레이드 설명
    public int Skill_Icon; // 아이콘번호
    [Space(25)]
    [Header("체크하는부분")]
    protected bool start = false;
    public List<float> HpPlusCCheck = new List<float>();
    public List<float> HpPlusPerCheck = new List<float>();
    public List<float> HpRegenCheck = new List<float>();
    public List<float> DefenceCheck = new List<float>();
    public List<float> AtPlusCheck = new List<float>();
    public List<float> CoolCheck = new List<float>();
    public List<float> AtRangeCheck = new List<float>();
    public List<float> SpeedCheck = new List<float>();
    public List<int> BulletCntCheck = new List<int>();
    public List<float> GoldPlusCheck = new List<float>();
    public List<float> XpPlusCheck = new List<float>();
    public List<float> BulletSpeedCheck = new List<float>();
    public List<float> BulletTimeCheck = new List<float>();
    public List<float> RangeCheck = new List<float>();
    public List<float> Real1Check = new List<float>();
    public List<float> Real2Check = new List<float>();

    public List<int> PieCheck = new List<int>();
    public List<float> DmgPerCheck = new List<float>();

    public bool goodstart = false;
    void Awake()
    {
        Skill_Item_Name = csvData.GameText(csvData.SkillItemNameNum[Index_Text]);
        Skill_Icon = csvData.SkillItemIconNum[Index_Text];
        LvMax = csvData.SkillItemMaxLevel[Index_Text];
        
        CreateIdx = csvData.SkillItemCreateIdx[Index_Text];
        for (int i = Index_Text; i < Index_Text + LvMax; i++)
        {
            int a = csvData.SkillItemInfoNum[i];
            Lv_Text.Add(csvData.GameText(a));
            HpPlusCCheck.Add(csvData.SkillItemHpPlusC[i]);
            HpPlusPerCheck.Add(csvData.SkillItemHpPlusP[i]);
            HpRegenCheck.Add(csvData.SkillItemHpRegen[i]);
            DefenceCheck.Add(csvData.SkillItemDefence[i]);
            AtPlusCheck.Add(csvData.SkillItemAtPlus[i]);
            CoolCheck.Add(csvData.SkillItemCool[i]);
            AtRangeCheck.Add(csvData.SkillItemAtRange[i]);
            SpeedCheck.Add(csvData.SkillItemSpeed[i]);
            BulletCntCheck.Add(csvData.SkillItemBtCnt[i]);
            GoldPlusCheck.Add(csvData.SkillItemGoldPlus[i]);
            XpPlusCheck.Add(csvData.SkillItemXpPlus[i]);
            BulletSpeedCheck.Add(csvData.SkillItemBtSpeed[i]);
            BulletTimeCheck.Add(csvData.SkillItemBtTime[i]);
            RangeCheck.Add(csvData.SkillItemRange[i]);
            Real1Check.Add(csvData.SkillItemReal1[i]);
            Real2Check.Add(csvData.SkillItemReal2[i]);

            PieCheck.Add(csvData.SkillItemPie[i]);
            DmgPerCheck.Add(csvData.SkillItemDmgPer[i]);


        }
        goodstart = true;
        gameObject.SetActive(false);
    }
}
