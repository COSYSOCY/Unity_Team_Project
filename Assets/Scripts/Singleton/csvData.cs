using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapInfo
{
    public int MapIdx;
    public int MapNameNum;
    public int MapInfoNum;
    public int MapIconNum;
    public int MapLockInfoNum;

    public MapInfo(int _MapIdx, int _MapNameNum, int _MapInfoNum, int _MapIconNum, int _MapLockInfoNum)
    {
        MapIdx= _MapIdx;
        MapNameNum= _MapNameNum;
        MapInfoNum= _MapInfoNum;    
        MapIconNum= _MapIconNum;
        MapLockInfoNum= _MapLockInfoNum;
    }


}


public class csvData : MonoBehaviour
{
    static csvData inst;

    public string dataPath_Characters;
    public string dataPath_Enemy;
    public string dataPath_Skill;
    public string dataPath_SkillItem;
    public string dataPath_Xp;
    public string dataPath_String;
    public string dataPath_Card;
    public string dataPath_Map;

    [SerializeField]
    public static List<Dictionary<string, object>> data;


    public static List<int> CharactersNameNum = new List<int>();
    public static List<int> CharactersInfoNum = new List<int>();
    public static List<int> CharactersIconNum = new List<int>();
    public static List<int> CharactersSkillIconNum = new List<int>();
    public static List<int> CharactersBSNum = new List<int>();
    public static List<int> CharactersPrice = new List<int>();
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
    public static List<float> SkillBulletTime=new List<float>();
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
    public static List<float> SkillItemRange = new List<float>();
    public static List<float> SkillItemReal1 = new List<float>();
    public static List<float> SkillItemReal2 = new List<float>();


    public static List<float> MonsterHp = new List<float>();
    public static List<float> MonsterDefence = new List<float>();
    public static List<float> MonsterSpeed = new List<float>();
    public static List<float> MonsterDamage = new List<float>();
    public static List<int> MonsterItemIdx = new List<int>();

    public static List<int> Exp = new List<int>();



    public  List<string> GameText_Korean = new List<string>();
    public  List<string> GameText_English = new List<string>();
    public  List<string> GameText_Japan = new List<string>();
    public  List<string> GameText_China = new List<string>();

    public  List<int> MapNameNum = new List<int>();
    public  List<int> MapInfoNum = new List<int>();
    public  List<int> MapIconNum = new List<int>();
    public  List<int> MapLockInfoNum = new List<int>();

    public static List<int> CardNameNum = new List<int>();
    public static List<int> CardInfoNum = new List<int>();
    public static List<int> CardIconNum = new List<int>();
    public static List<int> CardLevel = new List<int>();
    public static List<int> CardPrice = new List<int>();
    public static List<float> CardHpC = new List<float>();
    public static List<float> CardHpP = new List<float>();
    public static List<float> CardHpRegen = new List<float>();
    public static List<float> CardDefence = new List<float>();
    public static List<float> CardSpeed = new List<float>();
    public static List<float> CardDamage = new List<float>();
    public static List<int> CardBtCnt = new List<int>();
    public static List<float> CardCood = new List<float>();
    public static List<float> CardXpPlus = new List<float>();


    void Awake()
    {
        inst = this;
        Characters_Read();
        Enemy_Read();
        Skill_Read();
        SkillItem_Read();
        String_Read();
       Exp_Read();
       Card_Read();
       Map_Read();
    }

    public void Map_Read()
    {
        data = CSVReader.Read(dataPath_Map);
        //GameInfo.inst.MapsInfo = new List(MapInfo);
        for (int i = 0; i < data.Count; i++)
        {
            MapNameNum.Add(int.Parse(data[i]["맵이름텍스트번호"].ToString()));
            MapInfoNum.Add(int.Parse(data[i]["맵설명텍스트번호"].ToString()));
            MapIconNum.Add(int.Parse(data[i]["맵아이콘번호"].ToString()));
            MapLockInfoNum.Add(int.Parse(data[i]["잠금텍스트번호"].ToString()));
            GameInfo.inst.MapsInfo.Add(new MapInfo(i,MapNameNum[i],MapInfoNum[i], MapIconNum[i],MapLockInfoNum[i]));
        GameInfo.inst.PlayerMap.Add(0);



        }
        GameInfo.inst.mapcheck();
    }
    public void Card_Read()
    {
        data = CSVReader.Read(dataPath_Card);

        for (int i = 0; i < data.Count; i++)
        {
            CardNameNum.Add(int.Parse(data[i]["이름텍스트번호"].ToString()));
            CardInfoNum.Add(int.Parse(data[i]["설명텍스트번호"].ToString()));
            CardIconNum.Add(int.Parse(data[i]["아이콘번호"].ToString()));
            CardLevel.Add(int.Parse(data[i]["등급"].ToString()));
            CardPrice.Add(int.Parse(data[i]["가격"].ToString()));
            CardHpC.Add(float.Parse(data[i]["체력증가(상수)"].ToString()));
            CardHpP.Add(float.Parse(data[i]["체력증가(%)"].ToString()));
            CardHpRegen.Add(float.Parse(data[i]["회복"].ToString()));
            CardDefence.Add(float.Parse(data[i]["방어력"].ToString()));
            CardSpeed.Add(float.Parse(data[i]["이동속도"].ToString()));
            CardDamage.Add(float.Parse(data[i]["데미지증가"].ToString()));
            CardBtCnt.Add(int.Parse(data[i]["투사체수"].ToString()));
            CardCood.Add(float.Parse(data[i]["쿨타임"].ToString()));
            CardXpPlus.Add(float.Parse(data[i]["경험치증가"].ToString()));


        }
        GameInfo.inst.CardMax = data.Count;
        GameInfo.inst.CardCheck();
    }
    public void Characters_Read()
    {
        data = CSVReader.Read(dataPath_Characters);

        for (int i = 0; i < data.Count; i++)
        {
            CharactersNameNum.Add(int.Parse(data[i]["이름텍스트번호"].ToString()));
            CharactersInfoNum.Add(int.Parse(data[i]["설명텍스트번호"].ToString()));
            CharactersIconNum.Add(int.Parse(data[i]["아이콘번호"].ToString()));
            CharactersSkillIconNum.Add(int.Parse(data[i]["무기아이콘번호"].ToString()));
            CharactersBSNum.Add(int.Parse(data[i]["기본스킬번호"].ToString()));
            CharactersPrice.Add(int.Parse(data[i]["가격"].ToString()));
            CharactersHpMax.Add(float.Parse(data[i]["최대체력"].ToString()));
            CharactersHpRegen.Add(float.Parse(data[i]["회복"].ToString()));
            CharactersDefece.Add(float.Parse(data[i]["방어력"].ToString()));
            CharactersSpeed.Add(float.Parse(data[i]["이동속도"].ToString()));
            CharactersAtPlus.Add(float.Parse(data[i]["괴력"].ToString()));
            CharactersAtRange.Add(float.Parse(data[i]["공격범위"].ToString()));
            CharactersBtSpeed.Add(float.Parse(data[i]["투사체속도"].ToString()));
            CharactersBtTime.Add(float.Parse(data[i]["지속시간"].ToString()));
            CharactersBtCnt.Add(int.Parse(data[i]["투사체수"].ToString()));
            CharactersBtCool.Add(float.Parse(data[i]["쿨타임"].ToString()));
            CharactersRange.Add(float.Parse(data[i]["자석"].ToString()));
            CharactersXpPlus.Add(float.Parse(data[i]["경험치증가"].ToString()));

        }
        GameInfo.inst.CharacterMax = data.Count;
        GameInfo.inst.CharaMax();
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
            SkillNameNum.Add(int.Parse(data[i]["이름텍스트번호"].ToString()));
            SkillInfoNum.Add(int.Parse(data[i]["설명텍스트번호"].ToString()));
            SkillIconNum.Add(int.Parse(data[i]["아이콘번호"].ToString()));
            SkillMaxLevel.Add(int.Parse(data[i]["최대레벨"].ToString()));
            SkillBulletCnt.Add(int.Parse(data[i]["투사체수"].ToString()));
            SkillBulletCntMax.Add(int.Parse(data[i]["투사체최대갯수"].ToString()));
            SkillMinDamage.Add(float.Parse(data[i]["최소 데미지"].ToString()));
            SkillMaxDamage.Add(float.Parse(data[i]["최대 데미지"].ToString()));
            SkillBulletSpeed.Add(float.Parse(data[i]["투사체속도"].ToString()));
            SkillBulletTime.Add(float.Parse(data[i]["투사체지속시간"].ToString()));
            SkillBulletPie.Add(int.Parse(data[i]["관통"].ToString()));
            SkillCri.Add(float.Parse(data[i]["치명타 확률"].ToString()));
            SkillCoolTimeMain.Add(float.Parse(data[i]["쿨타임"].ToString()));
            SkillCoolTimeSub1.Add(float.Parse(data[i]["쿨타임_서브1"].ToString()));
            SkillCoolTimeSub2.Add(float.Parse(data[i]["쿨타임_서브2"].ToString()));
            SkillAtRange.Add(float.Parse(data[i]["공격범위"].ToString()));
            SkillReal1.Add(float.Parse(data[i]["실수_1"].ToString()));
            SkillReal2.Add(float.Parse(data[i]["실수_2"].ToString()));
            SkillReal3.Add(float.Parse(data[i]["실수_3"].ToString()));
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
            SkillItemNameNum.Add(int.Parse(data[i]["이름텍스트번호"].ToString()));
            SkillItemInfoNum.Add(int.Parse(data[i]["설명텍스트번호"].ToString()));
            SkillItemIconNum.Add(int.Parse(data[i]["아이콘번호"].ToString()));
            SkillItemMaxLevel.Add(int.Parse(data[i]["최대 레벨"].ToString()));
            SkillItemHpPlusC.Add(float.Parse(data[i]["체력증가(상수)"].ToString()));
            SkillItemHpPlusP.Add(float.Parse(data[i]["체력증가(%)"].ToString()));
            SkillItemHpRegen.Add(float.Parse(data[i]["체력회복"].ToString()));
            SkillItemDefence.Add(float.Parse(data[i]["방어력"].ToString()));
            SkillItemAtPlus.Add(float.Parse(data[i]["공격력"].ToString()));
            SkillItemCool.Add(float.Parse(data[i]["쿨타임감소"].ToString()));
            SkillItemAtRange.Add(float.Parse(data[i]["공격범위"].ToString()));
            SkillItemSpeed.Add(float.Parse(data[i]["이동속도"].ToString()));
            SkillItemBtCnt.Add(int.Parse(data[i]["투사체수증가"].ToString()));
            SkillItemBtSpeed.Add(float.Parse(data[i]["투사체이동속도증가"].ToString()));
            SkillItemBtTime.Add(float.Parse(data[i]["투사체지속시간증가"].ToString()));
            SkillItemGoldPlus.Add(float.Parse(data[i]["골드획득량"].ToString()));
            SkillItemXpPlus.Add(float.Parse(data[i]["경험치획득량"].ToString()));
            SkillItemRange.Add(float.Parse(data[i]["자석증가"].ToString()));
            SkillItemReal1.Add(float.Parse(data[i]["실수_1"].ToString()));
            SkillItemReal2.Add(float.Parse(data[i]["실수_2"].ToString()));
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
            GameText_Japan.Add(data[i]["Japan"].ToString());
            GameText_China.Add(data[i]["China"].ToString());
            GameText_Korean[i] = GameText_Korean[i].Replace("`w`", "\n");
            GameText_English[i] = GameText_English[i].Replace("`w`", "\n");
            GameText_Japan[i] = GameText_Japan[i].Replace("`w`", "\n");
            GameText_China[i] = GameText_China[i].Replace("`w`", "\n");
        }


    }

    public static string GameText(int i)
    {


        if (GameInfo.inst.Language== "English")
        {
            return inst.GameText_English[i];
        }
        else if(GameInfo.inst.Language == "Japan")
        {
            return inst.GameText_Japan[i];

        }
        else if (GameInfo.inst.Language == "China")
        {
            return inst.GameText_China[i];
        }

        else
        {
            return inst.GameText_Korean[i];
        }

            //return inst.GameText_Korean[i];
    }
}
