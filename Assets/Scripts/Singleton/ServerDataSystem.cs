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
    public void SaveData()
    {
       // serverdata.PlayerLevel= GameInfo.inst.PlayerLevel;
         //serverdata.PlayerXp= GameInfo.inst.PlayerXp;
         // serverdata.PlayerEnergy= GameInfo.inst.PlayerEnergy;
          serverdata.PlayerGold= GameInfo.PlayerGold;
         // serverdata.PlayerPoint= GameInfo.PlayerPoint;
         serverdata.CharacterIdx= GameInfo.inst.CharacterIdx;
         serverdata.MapIdx = GameInfo.inst.MapIdx;
          serverdata.CharacterActive= GameInfo.inst.CharacterActive;
          serverdata.PlayerCardIdxs= GameInfo.inst.PlayerCardIdxs;
         serverdata.PlayerCards= GameInfo.inst.PlayerCards;
         serverdata.PlayerMap= GameInfo.inst.PlayerMap;
         serverdata.Language= GameInfo.inst.Language;
         serverdata.AdGoldFreeMax= GameInfo.inst.AdGoldFreeMax;






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
    }

    public void SaveData2()
    {

        serverdata.PlayerGold = GameInfo.PlayerGold;

        serverdata.CharacterIdx = GameInfo.inst.CharacterIdx;
        serverdata.MapIdx = GameInfo.inst.MapIdx;
        serverdata.CharacterActive = GameInfo.inst.CharacterActive;
        serverdata.PlayerCardIdxs = GameInfo.inst.PlayerCardIdxs;
        serverdata.PlayerCards = GameInfo.inst.PlayerCards;
        serverdata.PlayerMap = GameInfo.inst.PlayerMap;
        serverdata.Language = GameInfo.inst.Language;
        serverdata.AdGoldFreeMax = GameInfo.inst.AdGoldFreeMax;
        string jsonData = JsonConvert.SerializeObject(serverdata);
        PlayerPrefs.SetString("Save", jsonData);
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
            
            IsSave = true;
            GameInfo.inst.PlayerLevel = 1;
            GameInfo.inst.PlayerXp = 0;
            GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];
            GameInfo.inst.CharacterActive[0] = 2; //�⺻ĳ�� ������ �־����.
            GameInfo.inst.AdGoldFreeMax = 3;

            GameInfo.PlayerGold = 600;
            //GameInfo.PlayerPoint = 5;
            GameInfo.inst.PlayerEnergy = 50;

            GameInfo.inst.PlayerMap[0] = 1;

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
            serverdata = JsonConvert.DeserializeObject<ServerData>(jsonData);
            //GameInfo.inst.PlayerLevel = serverdata.PlayerLevel;
            //GameInfo.inst.PlayerXp = serverdata.PlayerXp;
            //GameInfo.inst.PlayerEnergy = serverdata.PlayerEnergy;
            GameInfo.PlayerGold = serverdata.PlayerGold;
            //GameInfo.PlayerPoint = serverdata.PlayerPoint;
            GameInfo.inst.CharacterIdx = serverdata.CharacterIdx;
            GameInfo.inst.MapIdx = serverdata.MapIdx;

            GameInfo.inst.PlayerCardIdxs = serverdata.PlayerCardIdxs;
            GameInfo.inst.PlayerCards = serverdata.PlayerCards;

            GameInfo.inst.Language = serverdata.Language;
            GameInfo.inst.AdGoldFreeMax = serverdata.AdGoldFreeMax;


            for (int i = 0; i < serverdata.CharacterActive.Count; i++)
            {
                GameInfo.inst.CharacterActive[i] = serverdata.CharacterActive[i];
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
    public IEnumerator LoadData()
    {
        //GameInfo.inst.PlayerLevel = 1;
        //GameInfo.inst.PlayerXp = 0;
        //GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];
        //GameInfo.inst.CharacterActive[0] = 2; //�⺻ĳ�� ������ �־����.
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
            
            GameInfo.inst.PlayerCardIdxs = serverdata.PlayerCardIdxs;
            GameInfo.inst.PlayerCards = serverdata.PlayerCards;
            GameInfo.inst.Language = serverdata.Language;
            GameInfo.inst.AdGoldFreeMax = serverdata.AdGoldFreeMax;

            GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];

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
            GameInfo.inst.CharacterActive[0] = 2; //�⺻ĳ�� ������ �־����.
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
    void testFunc()
    {
        IsSave = true;
        GameInfo.inst.CharacterActive[0] = 2; //�⺻ĳ�� ������ �־����.
        GameInfo.inst.AdGoldFreeMax = 3;
        GameInfo.PlayerGold = 0;
        GameInfo.inst.PlayerMap[0] = 1;
        GameInfo.inst.PlayerMap[1] = 1;
        GameInfo.inst.PlayerMap[2] = 1;
        GameInfo.inst.PlayerMap[3] = 1;


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
    public int PlayerGold; // �÷��̾� ���
    public int CharacterIdx;
    public int MapIdx;
    public List<int> CharacterActive;
    public List<int> PlayerCardIdxs;
    public List<int> PlayerCards;
    public List<int> PlayerMap;
    public string Language;
    public int AdGoldFreeMax;

}

