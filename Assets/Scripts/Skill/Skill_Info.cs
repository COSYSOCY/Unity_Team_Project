using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Info : MonoBehaviour
{
    public int Index; // �ε���
    public int Index_Text; // �ؽ�Ʈ��ų��ȣ�ε���
    [Space(16)]
    [Header("��ġ")]
    public int Lv; // ����
    public float Damage; // ������
    public float DamageMin; // �ִ뵥����
    public float DamageMax; // �ּҵ�����
    public int bulletCnt; // ����ü��
    public int bulletCntMax; // ����ü�ִ��
    public float BulletSpeed; // ����ü�ӵ�
    public int BulletPie; // ����ü�����
    public float BulletAtCri; // ġ��ŸȮ��
    public float CoolMain; // ��Ÿ�� ����
    public float CoolSub1; // ��Ÿ�� ����1
    public float CoolSub2; // ��Ÿ�� ����2
    public float AtRange; // ���ݹ���
    public float SkillReal1; // �Ǽ�1
    public float SkillReal2; // �Ǽ�2
    public float SkillReal3; // �Ǽ�3


    [Space(16)]
    [Header("��ų����")]
    public string Skill_Name; // ��ų �̸�
    public List<string> Lv_Text; // ��ų ���׷��̵� ����
    public int Skill_Icon; // �����ܹ�ȣ
    [Space(25)]
    [Header("üũ�ϴºκ�")]
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
