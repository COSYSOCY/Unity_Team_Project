using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csvData : MonoBehaviour
{
    static csvData inst;

    public string dataPath_Characters;
    public string dataPath_Enemy;
    public string dataPath_Skill;
    public string dataPath_item;
    public string dataPath_String;

    [SerializeField]
    public static List<Dictionary<string, object>> data;

    public static List<int> SkillNameNum=new List<int>();
    public static List<int> SkillInfoNum=new List<int>();
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
    public static List<float> SkillReal1=new List<float>();
    public static List<float> SkillReal2=new List<float>();
    public static List<float> SkillReal3=new List<float>();



    void Awake()
    {
        inst = this;
        //Characters_Read();
        Skill_Read();
    }
    public void Characters_Read()
    {
        data = CSVReader.Read(dataPath_Characters);

        for (int i = 0; i < data.Count; i++)
        {
            //Tower_Level1_Per.Add(float.Parse(data[i]["PER1"].ToString()));
            //Tower_Level2_Per.Add(float.Parse(data[i]["PER2"].ToString()));
            //Tower_Level3_Per.Add(float.Parse(data[i]["PER3"].ToString()));
        }
    }
    public void Skill_Read()
    {
        data = CSVReader.Read(dataPath_Skill);
        for (int i = 0; i < data.Count; i++)
        {
            SkillNameNum.Add(int.Parse(data[i]["�̸��ؽ�Ʈ��ȣ"].ToString()));
            SkillInfoNum.Add(int.Parse(data[i]["�����ؽ�Ʈ��ȣ"].ToString()));
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
            SkillReal1.Add(float.Parse(data[i]["�Ǽ�_1"].ToString()));
            SkillReal2.Add(float.Parse(data[i]["�Ǽ�_2"].ToString()));
            SkillReal3.Add(float.Parse(data[i]["�Ǽ�_3"].ToString()));
            //Tower_Level1_Per.Add(float.Parse(data[i]["PER1"].ToString()));
            //Tower_Level2_Per.Add(float.Parse(data[i]["PER2"].ToString()));
            //Tower_Level3_Per.Add(float.Parse(data[i]["PER3"].ToString()));
        }
    }
}
