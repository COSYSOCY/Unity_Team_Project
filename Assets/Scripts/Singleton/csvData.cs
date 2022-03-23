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
            SkillNameNum.Add(int.Parse(data[i]["이름텍스트번호"].ToString()));
            SkillInfoNum.Add(int.Parse(data[i]["설명텍스트번호"].ToString()));
            SkillMaxLevel.Add(int.Parse(data[i]["최대레벨"].ToString()));
            SkillBulletCnt.Add(int.Parse(data[i]["투사체수"].ToString()));
            SkillBulletCntMax.Add(int.Parse(data[i]["투사체최대갯수"].ToString()));
            SkillMinDamage.Add(float.Parse(data[i]["최소 데미지"].ToString()));
            SkillMaxDamage.Add(float.Parse(data[i]["최대 데미지"].ToString()));
            SkillBulletSpeed.Add(float.Parse(data[i]["투사체속도"].ToString()));
            SkillBulletPie.Add(int.Parse(data[i]["관통"].ToString()));
            SkillCri.Add(float.Parse(data[i]["치명타 확률"].ToString()));
            SkillCoolTimeMain.Add(float.Parse(data[i]["쿨타임"].ToString()));
            SkillCoolTimeSub1.Add(float.Parse(data[i]["쿨타임_서브1"].ToString()));
            SkillCoolTimeSub2.Add(float.Parse(data[i]["쿨타임_서브2"].ToString()));
            SkillReal1.Add(float.Parse(data[i]["실수_1"].ToString()));
            SkillReal2.Add(float.Parse(data[i]["실수_2"].ToString()));
            SkillReal3.Add(float.Parse(data[i]["실수_3"].ToString()));
            //Tower_Level1_Per.Add(float.Parse(data[i]["PER1"].ToString()));
            //Tower_Level2_Per.Add(float.Parse(data[i]["PER2"].ToString()));
            //Tower_Level3_Per.Add(float.Parse(data[i]["PER3"].ToString()));
        }
    }
}
