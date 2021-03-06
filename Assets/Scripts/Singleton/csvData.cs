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

    public string dataPath_MixInfo;
    public string dataPath_PlayerExp;
    public string dataPath_Characters;
    public string dataPath_Enemy;
    public string dataPath_Skill;
    public string dataPath_SkillItem;
    public string dataPath_Xp;
    public string dataPath_String;
    public string dataPath_Card;
    public string dataPath_Map;
    public string dataPath_PowerUp;
    public string dataPath_Mission;

    [SerializeField]
    public static List<Dictionary<string, object>> data;


    public static List<int> PlayerExpMax = new List<int>();


    public static List<int> CharactersNameNum = new List<int>();
    public static List<int> CharactersInfoNum = new List<int>();
    public static List<int> CharactersIconNum = new List<int>();
    public static List<int> CharactersSkillIconNum = new List<int>();
    public static List<int> CharactersSkill_ItemIconNum = new List<int>();
    public static List<int> CharactersSkillName = new List<int>();
    public static List<int> CharactersSkill_ItemName = new List<int>();
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
    public static List<int> SkillCreateIdx=new List<int>();


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
    public static List<int> SkillItemCreateIdx = new List<int>();
    public static List<int> SkillItemPie = new List<int>();
    public static List<float> SkillItemDmgPer = new List<float>();

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
    public  List<string> GameText_Germany = new List<string>();
    public  List<string> GameText_Spain = new List<string>();

    public  List<string> GameText_Portugal = new List<string>();
    public  List<string> GameText_Sweden = new List<string>();
    public  List<string> GameText_Italy = new List<string>();
    public  List<string> GameText_ind = new List<string>();
    public  List<string> GameText_ukr = new List<string>();
    public  List<string> GameText_rus = new List<string>();
    public  List<string> GameText_tha = new List<string>();
    public  List<string> GameText_pol = new List<string>();
    public  List<string> GameText_fra = new List<string>();
    public  List<string> GameText_tur = new List<string>();




    public  List<int> MapNameNum = new List<int>();
    public  List<int> MapInfoNum = new List<int>();
    public  List<int> MapIconNum = new List<int>();
    public  List<int> MapLockInfoNum = new List<int>();

    public static List<int> CardNameNum = new List<int>();
    public static List<int> CardInfoNum = new List<int>();
    public static List<int> CardIconNum = new List<int>();
    public static List<int> CardLevel = new List<int>();
    public static List<int> CardPrice = new List<int>();
    public static List<int> CardFocus = new List<int>();
    public static List<float> CardHpC = new List<float>();
    public static List<float> CardHpP = new List<float>();
    public static List<float> CardHpRegen = new List<float>();
    public static List<float> CardDefence = new List<float>();
    public static List<float> CardSpeed = new List<float>();
    public static List<float> CardDamage = new List<float>();
    public static List<int> CardBtCnt = new List<int>();
    public static List<float> CardCood = new List<float>();
    public static List<float> CardXpPlus = new List<float>();
    public static List<float> CardGoldPlus = new List<float>();
    public static List<float> CardAttackRange = new List<float>();
    public static List<float> CardRange = new List<float>();

    public static List<float> CardDmgPer = new List<float>();
    public static List<float> CardBuSpeed = new List<float>();
    public static List<float> CardBuTime = new List<float>();

    public static List<float> CardReal1 = new List<float>();
    public static List<float> CardReal2 = new List<float>();








    public static List<int> Pu_NameNum = new List<int>();
    public static List<int> Pu_InfoNum = new List<int>();
    public static List<int> Pu_LevelMax = new List<int>();
    public static List<int> Pu_Cost1 = new List<int>();
    public static List<int> Pu_Cost2 = new List<int>();
    public static List<int> Pu_Cost3 = new List<int>();
    public static List<int> Pu_Cost4 = new List<int>();
    public static List<int> Pu_Cost5 = new List<int>();
    public static List<int> Pu_Cost6 = new List<int>();
    public static List<int> Pu_Cost7 = new List<int>();
    public static List<int> Pu_Cost8 = new List<int>();
    public static List<int> Pu_Cost9 = new List<int>();
    public static List<int> Pu_Cost10 = new List<int>();



    public static List<float> MixPer = new List<float>();


    public static List<int> MissionIconNum = new List<int>();
    public static List<int> MissionInfoNum = new List<int>();
    public static List<int> MissionGold = new List<int>();
    public static List<int> MissionOrder= new List<int>();



    void Awake()
    {
        inst = this;
        Mix_Read();
        Mission_Read();
        PowerUp_Read();
        Player_EXP_Read();
        Characters_Read();
        Enemy_Read();
        Skill_Read();
        SkillItem_Read();
        String_Read();
       Exp_Read();
       Card_Read();
       Map_Read();
        GameInfo.inst.GameStart = true;
    }
    public void Mission_Read()
    {
        data = CSVReader.Read(dataPath_Mission);
        for (int i = 0; i < data.Count; i++)
        {
            MissionIconNum.Add(int.Parse(data[i]["??????????"].ToString()));
            MissionInfoNum.Add(int.Parse(data[i]["??????????"].ToString()));
            MissionGold.Add(int.Parse(data[i]["????"].ToString()));
            MissionOrder.Add(int.Parse(data[i]["????"].ToString()));


            GameInfo.inst.Player_Mission.Add(0);
        }
    }
    public void Mix_Read()
    {
        data = CSVReader.Read(dataPath_MixInfo);
        for (int i = 0; i < data.Count; i++)
        {
            MixPer.Add(float.Parse(data[i]["????"].ToString()));



        }
    }
    public void PowerUp_Read()
    {
        data = CSVReader.Read(dataPath_PowerUp);
        for (int i = 0; i < data.Count; i++)
        {
            Pu_NameNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            Pu_InfoNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            Pu_LevelMax.Add(int.Parse(data[i]["????????"].ToString()));
            Pu_Cost1.Add(int.Parse(data[i]["1????????"].ToString()));
            Pu_Cost2.Add(int.Parse(data[i]["2????????"].ToString()));
            Pu_Cost3.Add(int.Parse(data[i]["3????????"].ToString()));
            Pu_Cost4.Add(int.Parse(data[i]["4????????"].ToString()));
            Pu_Cost5.Add(int.Parse(data[i]["5????????"].ToString()));
            Pu_Cost6.Add(int.Parse(data[i]["6????????"].ToString()));
            Pu_Cost7.Add(int.Parse(data[i]["7????????"].ToString()));
            Pu_Cost8.Add(int.Parse(data[i]["8????????"].ToString()));
            Pu_Cost9.Add(int.Parse(data[i]["9????????"].ToString()));
            Pu_Cost10.Add(int.Parse(data[i]["10????????"].ToString()));



        }
    }

    public void Player_EXP_Read()
    {
        data = CSVReader.Read(dataPath_PlayerExp);
        //GameInfo.inst.MapsInfo = new List(MapInfo);
        for (int i = 0; i < data.Count; i++)
        {
            PlayerExpMax.Add(int.Parse(data[i]["Exp"].ToString()));



        }
    }

    public void Map_Read()
    {
        data = CSVReader.Read(dataPath_Map);
        //GameInfo.inst.MapsInfo = new List(MapInfo);
        for (int i = 0; i < data.Count; i++)
        {
            MapNameNum.Add(int.Parse(data[i]["????????????????"].ToString()));
            MapInfoNum.Add(int.Parse(data[i]["????????????????"].ToString()));
            MapIconNum.Add(int.Parse(data[i]["????????????"].ToString()));
            MapLockInfoNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            GameInfo.inst.MapsInfo.Add(new MapInfo(i,MapNameNum[i],MapInfoNum[i], MapIconNum[i],MapLockInfoNum[i]));
            GameInfo.inst.PlayerMap.Add(0);



        }

        


    }
    public void Card_Read()
    {
        data = CSVReader.Read(dataPath_Card);

        for (int i = 0; i < data.Count; i++)
        {
            CardNameNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            CardInfoNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            CardIconNum.Add(int.Parse(data[i]["??????????"].ToString()));
            CardLevel.Add(int.Parse(data[i]["????"].ToString()));
            CardPrice.Add(int.Parse(data[i]["????"].ToString()));
            CardFocus.Add(int.Parse(data[i]["??????"].ToString()));
            CardHpC.Add(float.Parse(data[i]["????????(????)"].ToString()));
            CardHpP.Add(float.Parse(data[i]["????????(%)"].ToString()));
            CardHpRegen.Add(float.Parse(data[i]["????"].ToString()));
            CardDefence.Add(float.Parse(data[i]["??????"].ToString()));
            CardSpeed.Add(float.Parse(data[i]["????????"].ToString()));
            CardDamage.Add(float.Parse(data[i]["??????????"].ToString()));
            CardBtCnt.Add(int.Parse(data[i]["????????"].ToString()));
            CardCood.Add(float.Parse(data[i]["??????"].ToString()));
            CardXpPlus.Add(float.Parse(data[i]["??????????"].ToString()));
            CardGoldPlus.Add(float.Parse(data[i]["????????"].ToString()));
            CardAttackRange.Add(float.Parse(data[i]["????????????"].ToString()));
            CardRange.Add(float.Parse(data[i]["????????"].ToString()));
            CardDmgPer.Add(float.Parse(data[i]["??????"].ToString()));
            CardBuSpeed.Add(float.Parse(data[i]["??????????????"].ToString()));
            CardBuTime.Add(float.Parse(data[i]["??????????????"].ToString()));
            CardReal1.Add(float.Parse(data[i]["????1"].ToString()));
            CardReal2.Add(float.Parse(data[i]["????2"].ToString()));

        }
        GameInfo.inst.CardMax = data.Count;
        GameInfo.inst.CardCheck();
    }
    public void Characters_Read()
    {
        data = CSVReader.Read(dataPath_Characters);

        for (int i = 0; i < data.Count; i++)
        {
            CharactersNameNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            CharactersInfoNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            CharactersIconNum.Add(int.Parse(data[i]["??????????"].ToString()));
            CharactersSkillIconNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            CharactersSkill_ItemIconNum.Add(int.Parse(data[i]["????????????????"].ToString()));

            CharactersSkillName.Add(int.Parse(data[i]["??????????????????"].ToString()));
            CharactersSkill_ItemName.Add(int.Parse(data[i]["????????????????????"].ToString()));
            CharactersBSNum.Add(int.Parse(data[i]["????????????"].ToString()));
            CharactersPrice.Add(int.Parse(data[i]["????"].ToString()));
            CharactersHpMax.Add(float.Parse(data[i]["????????"].ToString()));
            CharactersHpRegen.Add(float.Parse(data[i]["????"].ToString()));
            CharactersDefece.Add(float.Parse(data[i]["??????"].ToString()));
            CharactersSpeed.Add(float.Parse(data[i]["????????"].ToString()));
            CharactersAtPlus.Add(float.Parse(data[i]["????"].ToString()));
            CharactersAtRange.Add(float.Parse(data[i]["????????"].ToString()));
            CharactersBtSpeed.Add(float.Parse(data[i]["??????????"].ToString()));
            CharactersBtTime.Add(float.Parse(data[i]["????????"].ToString()));
            CharactersBtCnt.Add(int.Parse(data[i]["????????"].ToString()));
            CharactersBtCool.Add(float.Parse(data[i]["??????"].ToString()));
            CharactersRange.Add(float.Parse(data[i]["????"].ToString()));
            CharactersXpPlus.Add(float.Parse(data[i]["??????????"].ToString()));


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
            SkillNameNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            SkillInfoNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            SkillIconNum.Add(int.Parse(data[i]["??????????"].ToString()));
            SkillMaxLevel.Add(int.Parse(data[i]["????????"].ToString()));
            SkillCreateIdx.Add(int.Parse(data[i]["??????????"].ToString()));
            SkillBulletCnt.Add(int.Parse(data[i]["????????"].ToString()));
            SkillBulletCntMax.Add(int.Parse(data[i]["??????????????"].ToString()));
            SkillMinDamage.Add(float.Parse(data[i]["???? ??????"].ToString()));
            SkillMaxDamage.Add(float.Parse(data[i]["???? ??????"].ToString()));
            SkillBulletSpeed.Add(float.Parse(data[i]["??????????"].ToString()));
            SkillBulletTime.Add(float.Parse(data[i]["??????????????"].ToString()));
            SkillBulletPie.Add(int.Parse(data[i]["????"].ToString()));
            SkillCri.Add(float.Parse(data[i]["?????? ????"].ToString()));
            SkillCoolTimeMain.Add(float.Parse(data[i]["??????"].ToString()));
            SkillCoolTimeSub1.Add(float.Parse(data[i]["??????_????1"].ToString()));
            SkillCoolTimeSub2.Add(float.Parse(data[i]["??????_????2"].ToString()));
            SkillAtRange.Add(float.Parse(data[i]["????????"].ToString()));
            SkillReal1.Add(float.Parse(data[i]["????_1"].ToString()));
            SkillReal2.Add(float.Parse(data[i]["????_2"].ToString()));
            SkillReal3.Add(float.Parse(data[i]["????_3"].ToString()));
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
            SkillItemNameNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            SkillItemInfoNum.Add(int.Parse(data[i]["??????????????"].ToString()));
            SkillItemIconNum.Add(int.Parse(data[i]["??????????"].ToString()));
            SkillItemMaxLevel.Add(int.Parse(data[i]["???? ????"].ToString()));
           SkillItemCreateIdx.Add(int.Parse(data[i]["??????????"].ToString()));
            SkillItemHpPlusC.Add(float.Parse(data[i]["????????(????)"].ToString()));
            SkillItemHpPlusP.Add(float.Parse(data[i]["????????(%)"].ToString()));
            SkillItemHpRegen.Add(float.Parse(data[i]["????????"].ToString()));
            SkillItemDefence.Add(float.Parse(data[i]["??????"].ToString()));
            SkillItemAtPlus.Add(float.Parse(data[i]["??????"].ToString()));
            SkillItemCool.Add(float.Parse(data[i]["??????????"].ToString()));
            SkillItemAtRange.Add(float.Parse(data[i]["????????"].ToString()));
            SkillItemSpeed.Add(float.Parse(data[i]["????????"].ToString()));
            SkillItemBtCnt.Add(int.Parse(data[i]["????????????"].ToString()));
            SkillItemBtSpeed.Add(float.Parse(data[i]["??????????????????"].ToString()));
            SkillItemBtTime.Add(float.Parse(data[i]["??????????????????"].ToString()));
            SkillItemGoldPlus.Add(float.Parse(data[i]["??????????"].ToString()));
            SkillItemXpPlus.Add(float.Parse(data[i]["????????????"].ToString()));
            SkillItemRange.Add(float.Parse(data[i]["????????"].ToString()));
            SkillItemReal1.Add(float.Parse(data[i]["????_1"].ToString()));
            SkillItemReal2.Add(float.Parse(data[i]["????_2"].ToString()));

            SkillItemPie.Add(int.Parse(data[i]["????"].ToString()));
            SkillItemDmgPer.Add(float.Parse(data[i]["??????"].ToString()));
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
            GameText_Germany.Add(data[i]["Germany"].ToString());
            GameText_Spain.Add(data[i]["Spain"].ToString());

            GameText_Portugal.Add(data[i]["Portugal"].ToString());
            GameText_Sweden.Add(data[i]["Sweden"].ToString());
            GameText_Italy.Add(data[i]["Italy"].ToString());
            GameText_ind.Add(data[i]["ind"].ToString());
            GameText_ukr.Add(data[i]["ukr"].ToString());
            GameText_rus.Add(data[i]["rus"].ToString());
            GameText_tha.Add(data[i]["tha"].ToString());
            GameText_pol.Add(data[i]["pol"].ToString());
            GameText_fra.Add(data[i]["fra"].ToString());
            GameText_tur.Add(data[i]["tur"].ToString());


                      


    GameText_Korean[i] = GameText_Korean[i].Replace("`w`", "\n");
            GameText_English[i] = GameText_English[i].Replace("`w`", "\n");
            GameText_Japan[i] = GameText_Japan[i].Replace("`w`", "\n");
            GameText_China[i] = GameText_China[i].Replace("`w`", "\n");
            GameText_Germany[i] = GameText_Germany[i].Replace("`w`", "\n");
            GameText_Spain[i] = GameText_Spain[i].Replace("`w`", "\n");

            GameText_Portugal[i] = GameText_Portugal[i].Replace("`w`", "\n");
            GameText_Sweden[i] = GameText_Sweden[i].Replace("`w`", "\n");
            GameText_Italy[i] = GameText_Italy[i].Replace("`w`", "\n");
            GameText_ind[i] = GameText_ind[i].Replace("`w`", "\n");
            GameText_ukr[i] = GameText_ukr[i].Replace("`w`", "\n");
            GameText_rus[i] = GameText_rus[i].Replace("`w`", "\n");
            GameText_tha[i] = GameText_tha[i].Replace("`w`", "\n");
            GameText_pol[i] = GameText_pol[i].Replace("`w`", "\n");
            GameText_fra[i] = GameText_fra[i].Replace("`w`", "\n");
            GameText_tur[i] = GameText_tur[i].Replace("`w`", "\n");
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
        else if (GameInfo.inst.Language == "Germany")
        {
            return inst.GameText_Germany[i];
        }
        else if (GameInfo.inst.Language == "Spain")
        {
            return inst.GameText_Spain[i];
        }

        else if (GameInfo.inst.Language == "Sweden")
        {
            return inst.GameText_Sweden[i];
        }
        else if (GameInfo.inst.Language == "Portugal")
        {
            return inst.GameText_Portugal[i];
        }
        else if (GameInfo.inst.Language == "Italy")
        {
            return inst.GameText_Italy[i];
        }
        else if (GameInfo.inst.Language == "ind")
        {
            return inst.GameText_ind[i];
        }
        else if (GameInfo.inst.Language == "ukr")
        {
            return inst.GameText_ukr[i];
        }
        else if (GameInfo.inst.Language == "rus")
        {
            return inst.GameText_rus[i];
        }
        else if (GameInfo.inst.Language == "tha")
        {
            return inst.GameText_tha[i];
        }
        else if (GameInfo.inst.Language == "pol")
        {
            return inst.GameText_pol[i];
        }
        else if (GameInfo.inst.Language == "fra")
        {
            return inst.GameText_fra[i];
        }
        else if (GameInfo.inst.Language == "tur")
        {
            return inst.GameText_tur[i];
        }

                  

        else
        {
            return inst.GameText_Korean[i];
        }

            //return inst.GameText_Korean[i];
    }
}
