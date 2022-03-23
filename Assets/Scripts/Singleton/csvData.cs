using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csvData : MonoBehaviour
{
    static csvData inst;

    public string dataPath_Characters;
    public string dataPath_Enemy;
    public string dataPath_Skill;
    public string dataPath_SkillItem;
    public string dataPath_Xp;
    public string dataPath_String;

    [SerializeField]
    public static List<Dictionary<string, object>> data;


    public static List<int> CharactersNameNum = new List<int>();
    public static List<int> CharactersInfoNum = new List<int>();
    public static List<int> CharactersBSNum = new List<int>();
    public static List<float> CharactersHpMax = new List<float>();
    public static List<float> CharactersHpRegen = new List<float>();
    public static List<float> CharactersDefece = new List<float>();
    public static List<float> CharactersSpeed = new List<float>();
    public static List<float> CharactersAtPlus = new List<float>();
    public static List<float> CharactersAtRange = new List<float>();
    public static List<float> CharactersBtSpeed = new List<float>();
    public static List<float> CharactersBtTime = new List<float>();
    public static List<int> CharactersBtCnt = new List<int>();
    public static List<float> CharactersBtCool = new List<float>();
    public static List<float> CharactersRange = new List<float>();
    public static List<float> CharactersXpPlus = new List<float>();


    public static List<int> SkillNameNum=new List<int>();
    public static List<int> SkillInfoNum=new List<int>();
    public static List<int> SkillIconNum=new List<int>();
    public static List<int> SkillMaxLevel=new List<int>();
    public static List<int> SkillBulletCnt=new List<int>();
    public static List<int> SkillBulletCntMax=new List<int>();
    public static List<float> SkillMinDamage=new List<float>();
    public static List<float> SkillMaxDamage=new List<float>();
    public static List<float> SkillBulletSpeed=new List<float>();
    public static List<int> SkillBulletPie=new List<int>();
    public static List<float> SkillCri=new List<float>();
    public static List<float> SkillCoolTimeMain=new List<float>();
    public static List<float> SkillCoolTimeSub1=new List<float>();
    public static List<float> SkillCoolTimeSub2=new List<float>();
    public static List<float> SkillAtRange=new List<float>();
    public static List<float> SkillReal1=new List<float>();
    public static List<float> SkillReal2=new List<float>();
    public static List<float> SkillReal3=new List<float>();

    public static List<int> SkillItemNameNum = new List<int>();
    public static List<int> SkillItemInfoNum = new List<int>();
    public static List<int> SkillItemIconNum = new List<int>();
    public static List<int> SkillItemMaxLevel = new List<int>();
    public static List<float> SkillItemHpPlusC = new List<float>();
    public static List<float> SkillItemHpPlusP = new List<float>();
    public static List<float> SkillItemHpRegen = new List<float>();
    public static List<float> SkillItemDefence = new List<float>();
    public static List<float> SkillItemAtPlus = new List<float>();
    public static List<float> SkillItemCool = new List<float>();
    public static List<float> SkillItemAtRange = new List<float>();
    public static List<float> SkillItemSpeed = new List<float>();
    public static List<int> SkillItemBtCnt = new List<int>();
    public static List<float> SkillItemBtSpeed = new List<float>();
    public static List<float> SkillItemBtTime = new List<float>();
    public static List<float> SkillItemGoldPlus = new List<float>();
    public static List<float> SkillItemXpPlus = new List<float>();
    public static List<float> SkillItemReal1 = new List<float>();
    public static List<float> SkillItemReal2 = new List<float>();


    public static List<float> MonsterHp = new List<float>();
    public static List<float> MonsterDefence = new List<float>();
    public static List<float> MonsterSpeed = new List<float>();
    public static List<float> MonsterDamage = new List<float>();
    public static List<int> MonsterItemIdx = new List<int>();

    public static List<int> Exp = new List<int>();



    public static List<string> GameText_Korean = new List<string>();
    public static List<string> GameText_English = new List<string>();


    void Awake()
    {
        inst = this;
        Characters_Read();
        Enemy_Read();
        Skill_Read();
        SkillItem_Read();
        String_Read();
       Exp_Read();
    }
    public void Characters_Read()
    {
        data = CSVReader.Read(dataPath_Characters);

        for (int i = 0; i < data.Count; i++)
        {
            CharactersNameNum.Add(int.Parse(data[i]["�̸��ؽ�Ʈ��ȣ"].ToString()));
            CharactersInfoNum.Add(int.Parse(data[i]["�����ؽ�Ʈ��ȣ"].ToString()));
            CharactersBSNum.Add(int.Parse(data[i]["�⺻��ų��ȣ"].ToString()));
            CharactersHpMax.Add(float.Parse(data[i]["�ִ�ü��"].ToString()));
            CharactersHpRegen.Add(float.Parse(data[i]["ȸ��"].ToString()));
            CharactersDefece.Add(float.Parse(data[i]["����"].ToString()));
            CharactersSpeed.Add(float.Parse(data[i]["�̵��ӵ�"].ToString()));
            CharactersAtPlus.Add(float.Parse(data[i]["����"].ToString()));
            CharactersAtRange.Add(float.Parse(data[i]["���ݹ���"].ToString()));
            CharactersBtSpeed.Add(float.Parse(data[i]["����ü�ӵ�"].ToString()));
            CharactersBtTime.Add(float.Parse(data[i]["���ӽð�"].ToString()));
            CharactersBtCnt.Add(int.Parse(data[i]["����ü��"].ToString()));
            CharactersBtCool.Add(float.Parse(data[i]["��Ÿ��"].ToString()));
            CharactersRange.Add(float.Parse(data[i]["�ڼ�"].ToString()));
            CharactersXpPlus.Add(float.Parse(data[i]["����ġ����"].ToString()));

        }
    }
    public void Enemy_Read()
    {
        data = CSVReader.Read(dataPath_Enemy);

        for (int i = 0; i < data.Count; i++)
        {
            MonsterHp.Add(float.Parse(data[i]["Hp"].ToString()));
            MonsterDefence.Add(float.Parse(data[i]["Defence"].ToString()));
            MonsterSpeed.Add(float.Parse(data[i]["Speed"].ToString()));
            MonsterDamage.Add(float.Parse(data[i]["Dagame"].ToString()));
            MonsterItemIdx.Add(int.Parse(data[i]["ItemIdx"].ToString()));
        }
    }
    public void Skill_Read()
    {
        data = CSVReader.Read(dataPath_Skill);
        for (int i = 0; i < data.Count; i++)
        {
            SkillNameNum.Add(int.Parse(data[i]["�̸��ؽ�Ʈ��ȣ"].ToString()));
            SkillInfoNum.Add(int.Parse(data[i]["�����ؽ�Ʈ��ȣ"].ToString()));
            SkillIconNum.Add(int.Parse(data[i]["�����ܹ�ȣ"].ToString()));
            SkillMaxLevel.Add(int.Parse(data[i]["�ִ뷹��"].ToString()));
            SkillBulletCnt.Add(int.Parse(data[i]["����ü��"].ToString()));
            SkillBulletCntMax.Add(int.Parse(data[i]["����ü�ִ밹��"].ToString()));
            SkillMinDamage.Add(float.Parse(data[i]["�ּ� ������"].ToString()));
            SkillMaxDamage.Add(float.Parse(data[i]["�ִ� ������"].ToString()));
            SkillBulletSpeed.Add(float.Parse(data[i]["����ü�ӵ�"].ToString()));
            SkillBulletPie.Add(int.Parse(data[i]["����"].ToString()));
            SkillCri.Add(float.Parse(data[i]["ġ��Ÿ Ȯ��"].ToString()));
            SkillCoolTimeMain.Add(float.Parse(data[i]["��Ÿ��"].ToString()));
            SkillCoolTimeSub1.Add(float.Parse(data[i]["��Ÿ��_����1"].ToString()));
            SkillCoolTimeSub2.Add(float.Parse(data[i]["��Ÿ��_����2"].ToString()));
            SkillAtRange.Add(float.Parse(data[i]["���ݹ���"].ToString()));
            SkillReal1.Add(float.Parse(data[i]["�Ǽ�_1"].ToString()));
            SkillReal2.Add(float.Parse(data[i]["�Ǽ�_2"].ToString()));
            SkillReal3.Add(float.Parse(data[i]["�Ǽ�_3"].ToString()));
            //Tower_Level1_Per.Add(float.Parse(data[i]["PER1"].ToString()));
            //Tower_Level2_Per.Add(float.Parse(data[i]["PER2"].ToString()));
            //Tower_Level3_Per.Add(float.Parse(data[i]["PER3"].ToString()));
        }
    }

    public void SkillItem_Read()
    {
        data = CSVReader.Read(dataPath_SkillItem);

        for (int i = 0; i < data.Count; i++)
        {
            SkillItemNameNum.Add(int.Parse(data[i]["�̸��ؽ�Ʈ��ȣ"].ToString()));
            SkillItemInfoNum.Add(int.Parse(data[i]["�����ؽ�Ʈ��ȣ"].ToString()));
            SkillItemIconNum.Add(int.Parse(data[i]["�����ܹ�ȣ"].ToString()));
            SkillItemMaxLevel.Add(int.Parse(data[i]["�ִ� ����"].ToString()));
            SkillItemHpPlusC.Add(float.Parse(data[i]["ü������(���)"].ToString()));
            SkillItemHpPlusP.Add(float.Parse(data[i]["ü������(%)"].ToString()));
            SkillItemHpRegen.Add(float.Parse(data[i]["ü��ȸ��"].ToString()));
            SkillItemDefence.Add(float.Parse(data[i]["����"].ToString()));
            SkillItemAtPlus.Add(float.Parse(data[i]["���ݷ�"].ToString()));
            SkillItemCool.Add(float.Parse(data[i]["��Ÿ�Ӱ���"].ToString()));
            SkillItemAtRange.Add(float.Parse(data[i]["���ݹ���"].ToString()));
            SkillItemSpeed.Add(float.Parse(data[i]["�̵��ӵ�"].ToString()));
            SkillItemBtCnt.Add(int.Parse(data[i]["����ü������"].ToString()));
            SkillItemBtSpeed.Add(float.Parse(data[i]["����ü�̵��ӵ�����"].ToString()));
            SkillItemBtTime.Add(float.Parse(data[i]["����ü���ӽð�����"].ToString()));
            SkillItemGoldPlus.Add(float.Parse(data[i]["���ȹ�淮"].ToString()));
            SkillItemXpPlus.Add(float.Parse(data[i]["����ġȹ�淮"].ToString()));
            SkillItemReal1.Add(float.Parse(data[i]["�Ǽ�_1"].ToString()));
            SkillItemReal2.Add(float.Parse(data[i]["�Ǽ�_2"].ToString()));
        }
    }

    public void Exp_Read()
    {
        data = CSVReader.Read(dataPath_Xp);

        for (int i = 0; i < data.Count; i++)
        {
            Exp.Add(int.Parse(data[i]["Exp"].ToString()));

        }
    }
    public void String_Read()
    {
        data = CSVReader.Read(dataPath_String);
        for (int i = 0; i < data.Count; i++)
        {
            GameText_Korean.Add(data[i]["Korea"].ToString());
            GameText_English.Add(data[i]["English"].ToString());
        }


    }

    public static string GameText(int i)
    {


        if (GameInfo.Language=="English")
        {
            return GameText_English[i];
        }
        else if(GameInfo.Language == "Japanese")
        {

        }
        else if (GameInfo.Language == "Chinese")
        {

        }

        else
        {
            return GameText_Korean[i];
        }

            return GameText_Korean[i];
    }
}
