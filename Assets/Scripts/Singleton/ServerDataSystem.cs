using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;



public class ServerDataSystem : MonoBehaviour
{
    //#if UNITY_EDITOR

    //    public string GPath = Application.dataPath;
    //#else
    //    public string GPath = Application.persistentDataPath;
    //#endif
    public ServerData serverdata=new ServerData();

    public static ServerDataSystem inst;
    public bool IsSave = false;
    void Awake()
    {
        inst = this;
    }
    //public void SaveData()
    //{
    //      serverdata.PlayerGold= GameInfo.PlayerGold;
    //     serverdata.CharacterIdx= GameInfo.inst.CharacterIdx;
    //     serverdata.MapIdx = GameInfo.inst.MapIdx;
    //      serverdata.CharacterActive= GameInfo.inst.CharacterActive;
    //      serverdata.PlayerCardIdxs= GameInfo.inst.PlayerCardIdxs;
    //     serverdata.PlayerCards= GameInfo.inst.PlayerCards;
    //     serverdata.PlayerMap= GameInfo.inst.PlayerMap;
    //     serverdata.Language= GameInfo.inst.Language;
    //     serverdata.IsAdGold = GameInfo.inst.IsAdGold;
    //     serverdata.AdGoldTime = GameInfo.inst.AdGoldTime;
    //     serverdata.IsAdCard = GameInfo.inst.IsAdCard;
    //     serverdata.AdCardTime = GameInfo.inst.AdCardTime;





    //string sDirPath;
    //    sDirPath = Application.dataPath + "/Save";

    //    DirectoryInfo di = new DirectoryInfo(sDirPath);

    //    if (di.Exists == false)

    //    {
    //        di.Create();
            
    //    }
    //    FileStream streamSave = new FileStream(Application.dataPath + "/Save/Save.json", FileMode.Create);
    //    string jsonData = JsonConvert.SerializeObject(serverdata);
    //    byte[] data = Encoding.UTF8.GetBytes(jsonData);
    //    streamSave.Write(data, 0, data.Length);
    //    streamSave.Flush();
    //    streamSave.Close();
    //}

    public string SaveData2()
    {

        serverdata.PlayerGold = GameInfo.PlayerGold;
        serverdata.CharacterIdx = GameInfo.inst.CharacterIdx;
        serverdata.MapIdx = GameInfo.inst.MapIdx;
        serverdata.CharacterActive = GameInfo.inst.CharacterActive;
        serverdata.PlayerCardIdxs = GameInfo.inst.PlayerCardIdxs;
        serverdata.PlayerCards = GameInfo.inst.PlayerCards;
        serverdata.PlayerMap = GameInfo.inst.PlayerMap;
        serverdata.Language = GameInfo.inst.Language;
        serverdata.IsAdGold = GameInfo.inst.IsAdGold;
        serverdata.AdGoldTime = GameInfo.inst.AdGoldTime;
        serverdata.IsAdCard = GameInfo.inst.IsAdCard;
        serverdata.AdCardTime = GameInfo.inst.AdCardTime;
        serverdata.PlayerCardMax = GameInfo.inst.PlayerCardMax;
        serverdata.Player_PowerUp = GameInfo.inst.Player_PowerUp;
        serverdata.Daycom1 = GameInfo.inst.Daycom1;
        serverdata.PlayerKill = GameInfo.inst.PlayerKill;

        serverdata.Daycom2 = GameInfo.inst.Daycom2;
        serverdata.Daycom3 = GameInfo.inst.Daycom3;
        serverdata.DayCom2Int = GameInfo.inst.DayCom2Int;
        serverdata.DayCom3Int = GameInfo.inst.DayCom3Int;
        serverdata.Player_Mission = GameInfo.inst.Player_Mission;









        string jsonData = JsonConvert.SerializeObject(serverdata);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
        string format = System.Convert.ToBase64String(bytes); 
        PlayerPrefs.SetString("Save", format);
        return (PlayerPrefs.GetString("Save"));
    }
    public void saveReset()
    {
        PlayerPrefs.SetString("Save", "");
    }

    public IEnumerator CreateFile()
    {
        string sDirPath;

        sDirPath = Application.dataPath + "/Save";

        DirectoryInfo di = new DirectoryInfo(sDirPath);

        if (di.Exists == false)

        {
            di.Create();
        }
        FileStream streamSave = new FileStream(Application.dataPath + "/Save/Save.json", FileMode.Create);
        string jsonData = JsonConvert.SerializeObject(serverdata);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        streamSave.Write(data, 0, data.Length);
        streamSave.Flush();
        streamSave.Close();
        yield return null;
    }
    public void LoadData2()
    {
        if (PlayerPrefs.GetString("Save")=="")
        {
            


            
            testFunc();
            SceneManager.LoadScene("01_Loby_Main");
            SystemLanguage lang = Application.systemLanguage;

            switch (lang)
            {
                case SystemLanguage.Korean:
                    GameInfo.inst.Language = "Korean";
                    break;

                case SystemLanguage.English:
                    GameInfo.inst.Language = "English";
                    break;

                case SystemLanguage.Japanese:
                    GameInfo.inst.Language = "Japan";
                    break;
                case SystemLanguage.Chinese:
                    GameInfo.inst.Language = "China";
                    break;
                case SystemLanguage.German:
                    GameInfo.inst.Language = "Germany";
                    break;
                case SystemLanguage.Spanish:
                    GameInfo.inst.Language = "Spain";
                    break;
            }
            if (GameInfo.inst.Language == "")
            {
                GameInfo.inst.Language = "Korean";
            }
            SaveData2();
        }
        else
        {
            string jsonData = PlayerPrefs.GetString("Save");
            byte[] bytes = System.Convert.FromBase64String(jsonData);
            string reformat = System.Text.Encoding.UTF8.GetString(bytes);
            serverdata = JsonConvert.DeserializeObject<ServerData>(reformat);
            //GameInfo.inst.PlayerLevel = serverdata.PlayerLevel;
            //GameInfo.inst.PlayerXp = serverdata.PlayerXp;
            //GameInfo.inst.PlayerEnergy = serverdata.PlayerEnergy;
            GameInfo.PlayerGold = serverdata.PlayerGold;
            //GameInfo.PlayerPoint = serverdata.PlayerPoint;
            GameInfo.inst.CharacterIdx = serverdata.CharacterIdx;
            GameInfo.inst.MapIdx = serverdata.MapIdx;

            for (int i = 0; i < serverdata.Player_PowerUp.Count; i++)
            {
                GameInfo.inst.Player_PowerUp[i] = serverdata.Player_PowerUp[i];
            }
            for (int i = 0; i < serverdata.PlayerCardIdxs.Count; i++)
            {
                GameInfo.inst.PlayerCardIdxs[i] = serverdata.PlayerCardIdxs[i];
            }
            GameInfo.inst.PlayerCards = serverdata.PlayerCards;

            GameInfo.inst.Language = serverdata.Language;
            GameInfo.inst.IsAdGold = serverdata.IsAdGold;
            GameInfo.inst.AdGoldTime = serverdata.AdGoldTime;
            GameInfo.inst.IsAdCard = serverdata.IsAdCard;
            GameInfo.inst.AdCardTime = serverdata.AdCardTime;
            GameInfo.inst.PlayerCardMax = serverdata.PlayerCardMax;
            GameInfo.inst.Daycom1 = serverdata.Daycom1;
            GameInfo.inst.PlayerKill = serverdata.PlayerKill;

            GameInfo.inst.Daycom2 = serverdata.Daycom2;
            GameInfo.inst.Daycom3 = serverdata.Daycom3;
            GameInfo.inst.DayCom2Int = serverdata.DayCom2Int;
            GameInfo.inst.DayCom3Int = serverdata.DayCom3Int;


            for (int i = 0; i < serverdata.CharacterActive.Count; i++)
            {
                GameInfo.inst.CharacterActive[i] = serverdata.CharacterActive[i];
            }
            for (int i = 0; i < serverdata.Player_Mission.Count; i++)
            {
                GameInfo.inst.Player_Mission[i] = serverdata.Player_Mission[i];
            }
            for (int i = 0; i < serverdata.PlayerMap.Count; i++)
            {
                GameInfo.inst.PlayerMap[i] = serverdata.PlayerMap[i];
            }





            GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];

            IsSave = true;
            SceneManager.LoadScene("01_Loby_Main");
        }
    }
    /*
    public IEnumerator LoadData()
    {
        //GameInfo.inst.PlayerLevel = 1;
        //GameInfo.inst.PlayerXp = 0;
        //GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];
        //GameInfo.inst.CharacterActive[0] = 2; //기본캐릭 무조건 있어야함.
        //GameInfo.inst.AdGoldFreeMax = 3;

        //GameInfo.PlayerGold = 600;
        //GameInfo.PlayerPoint = 5;
        //GameInfo.inst.PlayerEnergy = 50;
        //GameInfo.inst.Language = "Korean";
        //SceneManager.LoadScene("01_Loby_Main");
        //yield break;
        string Check = Application.dataPath + "/Save/Save.json";
        if (File.Exists(Check))
        {
            FileStream streamload = new FileStream(Application.dataPath + "/Save/Save.json", FileMode.Open);
            byte[] data = new byte[streamload.Length];
            streamload.Read(data, 0, data.Length);
            streamload.Flush();
            streamload.Close();
            string jsonData = Encoding.UTF8.GetString(data);
            serverdata = JsonConvert.DeserializeObject<ServerData>(jsonData);
            //yield return serverdata = JsonConvert.DeserializeObject<ServerData>(jsonData);
            //GameInfo.inst.PlayerLevel = serverdata.PlayerLevel;
            //GameInfo.inst.PlayerXp = serverdata.PlayerXp;
            //GameInfo.inst.PlayerEnergy = serverdata.PlayerEnergy;
            GameInfo.PlayerGold = serverdata.PlayerGold;
            //GameInfo.PlayerPoint = serverdata.PlayerPoint;
            GameInfo.inst.CharacterIdx = serverdata.CharacterIdx;
            GameInfo.inst.MapIdx = serverdata.MapIdx;
            


            for (int i = 0; i < serverdata.PlayerCardIdxs.Count; i++)
            {
                GameInfo.inst.PlayerCardIdxs[i] = serverdata.PlayerCardIdxs[i];
            }
            GameInfo.inst.PlayerCards = serverdata.PlayerCards;
            GameInfo.inst.Language = serverdata.Language;
            GameInfo.inst.AdGoldFreeMax = serverdata.AdGoldFreeMax;
            GameInfo.inst.AdCardFreeMax = serverdata.AdCardFreeMax;
            GameInfo.inst.PlayerCardMax = serverdata.PlayerCardMax;
            GameInfo.inst.Daycom1 = serverdata.Daycom1;

            GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];
            
            for (int i = 0; i < serverdata.Player_PowerUp.Count; i++)
            {
                GameInfo.inst.Player_PowerUp[i] = serverdata.Player_PowerUp[i];
            }
            for (int i = 0; i < serverdata.CharacterActive.Count; i++)
            {
                GameInfo.inst.CharacterActive[i] = serverdata.CharacterActive[i];
            }
            for (int i = 0; i < serverdata.PlayerMap.Count; i++)
            {
                GameInfo.inst.PlayerMap[i] = serverdata.PlayerMap[i];
            }

            IsSave = true;
            testFunc();
            SceneManager.LoadScene("01_Loby_Main");
            
        }
        else
        {
            IsSave = true;
            GameInfo.inst.PlayerLevel = 1;
            GameInfo.inst.PlayerXp = 0;
            GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];
            GameInfo.inst.CharacterActive[0] = 2; //기본캐릭 무조건 있어야함.
            GameInfo.inst.AdGoldFreeMax = 3;

            GameInfo.inst.PlayerMap[0] = 1;

            GameInfo.PlayerGold = 600;
            //GameInfo.PlayerPoint = 5;
            GameInfo.inst.PlayerEnergy = 50;
            testFunc();
            SceneManager.LoadScene("01_Loby_Main");

            yield return StartCoroutine(CreateFile());
            SystemLanguage lang = Application.systemLanguage;

            switch (lang)
            {
                case SystemLanguage.Korean:
                    GameInfo.inst.Language = "Korean";
                    break;

                case SystemLanguage.English:
                    GameInfo.inst.Language = "English";
                    break;

                case SystemLanguage.Japanese:
                    GameInfo.inst.Language = "Japan";
                    break;
                case SystemLanguage.Chinese:
                    GameInfo.inst.Language = "China";
                    break;
                case SystemLanguage.German:
                    GameInfo.inst.Language = "Germany";
                    break;
                case SystemLanguage.Spanish:
                    GameInfo.inst.Language = "Spain";
                    break;
            }
            if (GameInfo.inst.Language == "")
            {
                GameInfo.inst.Language = "Korean";
            }
            SaveData();
            





        }
        





            








        

    }
    */
    void testFunc()
    {
        IsSave = true;
        GameInfo.inst.CharacterActive[0] = 2; //기본캐릭 무조건 있어야함.







        GameInfo.PlayerGold = 0;
        GameInfo.inst.PlayerMap[0] = 1;
        GameInfo.inst.PlayerMap[1] = 1;
        GameInfo.inst.PlayerMap[2] = 1;
        GameInfo.inst.PlayerMap[3] = 1;
        GameInfo.inst.PlayerCardMax = 0;


        GameInfo.inst.CharacterActive[0] = 2;
        GameInfo.inst.CharacterActive[1] = 1;
        GameInfo.inst.CharacterActive[2] = 1;
        GameInfo.inst.CharacterActive[3] = 1;
        GameInfo.inst.CharacterActive[4] = 1;
        GameInfo.inst.CharacterActive[5] = 1;
        GameInfo.inst.CharacterActive[6] = 1;
        GameInfo.inst.CharacterActive[7] = 1;
        GameInfo.inst.CharacterActive[8] = 1;
        GameInfo.inst.CharacterActive[9] = 1;
        GameInfo.inst.CharacterActive[10] = 1;
        GameInfo.inst.CharacterActive[11] = 1;
        GameInfo.inst.CharacterActive[12] = 1;

        GameInfo.inst.Daycom1 = DateTime.Now.AddDays(-2);

    }
    void OnApplicationQuit()
    {
        if (IsSave)
        {
        SaveData2();

        }
    }
}

[System.Serializable]
public class ServerData
{
    public int PlayerGold; // 플레이어 골드
    public int CharacterIdx;
    public int MapIdx;
    public List<int> CharacterActive;
    public List<int> Player_PowerUp;
    public List<int> PlayerCardIdxs;
    public List<int> PlayerCards;
    public List<int> PlayerMap;
    public string Language;
    public int AdGoldFreeMax;
    public int AdCardFreeMax;
    public int PlayerCardMax;
    public DateTime Daycom1;
    public int PlayerKill;
    public bool[] IsAdGold;
    public DateTime[] AdGoldTime;
    public bool[] IsAdCard;
    public DateTime[] AdCardTime;
    public DateTime Daycom2; // 연속보상
    public DateTime Daycom3; // 월보상

    public int DayCom2Int;
    public int DayCom3Int;
    public List<int> Player_Mission;

}

