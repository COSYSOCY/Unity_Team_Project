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
    public ServerData serverdata=new ServerData();

    public static ServerDataSystem inst;
    public bool IsSave = false;
    void Awake()
    {
        inst = this;
    }
    public void SaveData()
    {
        serverdata.PlayerLevel= GameInfo.inst.PlayerLevel;
         serverdata.PlayerXp= GameInfo.inst.PlayerXp;
          serverdata.PlayerEnergy= GameInfo.inst.PlayerEnergy;
          serverdata.PlayerGold= GameInfo.PlayerGold;
          serverdata.PlayerPoint= GameInfo.PlayerPoint;
         serverdata.CharacterIdx= GameInfo.inst.CharacterIdx;
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
        FileStream streamSave = new FileStream(Application.dataPath + "/Save/Save.json", FileMode.OpenOrCreate);
        string jsonData = JsonConvert.SerializeObject(serverdata);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        streamSave.Write(data, 0, data.Length);
        streamSave.Close();
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
        FileStream streamSave = new FileStream(Application.dataPath + "/Save/Save.json", FileMode.OpenOrCreate);
        string jsonData = JsonConvert.SerializeObject(serverdata);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        streamSave.Write(data, 0, data.Length);
        streamSave.Close();
        yield return null;
    }
    public IEnumerator LoadData()
    {
        string Check = Application.dataPath + "/Save/Save.json";
        if (File.Exists(Check)==false)
        {
            yield return CreateFile();
        }
        FileStream streamload = new FileStream(Application.dataPath + "/Save/Save.json", FileMode.Open);
        byte[] data = new byte[streamload.Length];
        streamload.Read(data, 0, data.Length);
        streamload.Close();
        string jsonData = Encoding.UTF8.GetString(data);

        yield return serverdata = JsonConvert.DeserializeObject<ServerData>(jsonData);



        if (serverdata.PlayerLevel == 0)
        {
            GameInfo.inst.PlayerLevel = 1;
            GameInfo.inst.PlayerXp = 0;
            GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];
            GameInfo.inst.CharacterActive[0] = 2; //기본캐릭 무조건 있어야함.
            GameInfo.inst.AdGoldFreeMax = 3;

            GameInfo.PlayerGold = 600;
            GameInfo.PlayerPoint = 5;
            GameInfo.inst.PlayerEnergy = 50;


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
            


        }
        else
        {
            GameInfo.inst.PlayerLevel = serverdata.PlayerLevel;
            GameInfo.inst.PlayerXp = serverdata.PlayerXp;
            GameInfo.inst.PlayerEnergy = serverdata.PlayerEnergy;
            GameInfo.PlayerGold = serverdata.PlayerGold;
            GameInfo.PlayerPoint = serverdata.PlayerPoint;
            GameInfo.inst.CharacterIdx = serverdata.CharacterIdx;
            GameInfo.inst.CharacterActive = serverdata.CharacterActive;
            GameInfo.inst.PlayerCardIdxs = serverdata.PlayerCardIdxs;
            GameInfo.inst.PlayerCards = serverdata.PlayerCards;
            GameInfo.inst.PlayerMap = serverdata.PlayerMap;
            GameInfo.inst.Language = serverdata.Language;
            GameInfo.inst.AdGoldFreeMax = serverdata.AdGoldFreeMax;


            








        }
        GameInfo.inst.PlayerXpMax = csvData.PlayerExpMax[GameInfo.inst.PlayerLevel];
       // GameInfo.inst.PlayerEnergyMax = 20;
        SaveData();
        IsSave = true;
        SceneManager.LoadScene("01_Loby_Main");
    }

    void OnDestroy()
    {
        if (IsSave)
        {
        SaveData();

        }
    }
}

[System.Serializable]
public class ServerData
{
    public int PlayerLevel; // 플레이어 레벨
    public int PlayerXp; // 플레이어 경험치
    public int PlayerEnergy; // 플레이어 에너지
    public int PlayerGold; // 플레이어 골드
    public int PlayerPoint; // 플레이어 보석
    public int CharacterIdx;
    public List<int> CharacterActive;
    public List<int> PlayerCardIdxs;
    public List<int> PlayerCards;
    public List<int> PlayerMap;
    public string Language;
    public int AdGoldFreeMax;

}

