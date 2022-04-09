using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_ItemInfo : MonoBehaviour
{
    public int Index; // �ε���
    public int Index_Text; // �ؽ�Ʈ��ų��ȣ�ε���
    [Space(16)]
    [Header("��ġ")]
    public int Lv; // ����
    public int LvMax; // ����
    public float HpPlusC; // ü������(���)
    public float HpPlusPer; // ü������(%)
    public float HpRegen; // ü��ȸ��
    public float Defence; // ���»��
    public float AtPlus; // ����������%
    public float Cool; // �𰨼�%
    public float AtRange; // ���ݹ�������%
    public float Speed; // �̵��ӵ�����%
    public int BulletCnt; // ����ü������
    public float GoldPlus; // ���ȹ�淮%
    public float XpPlus; // ����ġȹ�淮%
    public float BulletSpeed; // ����ü�̵��ӵ�����%
    public float BulletTime; // ����ü���ӽð�����%
    public float Range; // �ڼ�����
    public float Real1; // �Ǽ�1
    public float Real2; // �Ǽ�2
    public int CreateIdx; // �Ǽ�2
    public int ActiveIdx; // Ȱ��ȭ ��°

    public int Pie; // ����
    public float DmgPer; // ġ��Ÿ



    [Space(16)]
    [Header("��ų����")]
    public string Skill_Item_Name; // ��ų �̸�
    public List<string> Lv_Text; // ��ų ���׷��̵� ����
    public int Skill_Icon; // �����ܹ�ȣ
    [Space(25)]
    [Header("üũ�ϴºκ�")]
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
