using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;
using Newtonsoft.Json;


public class ServerDataSystem : MonoBehaviour
{
    public ServerData serverdata=new ServerData();

    public static ServerDataSystem inst;

    void Awake()
    {
        inst = this;
    }
    public void SaveData()
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
    }

    public IEnumerator LoadData()
    {
        FileStream streamload = new FileStream(Application.dataPath + "/Save/Save.json", FileMode.Open);
        byte[] data = new byte[streamload.Length];
        streamload.Read(data, 0, data.Length);
        streamload.Close();
        string jsonData = Encoding.UTF8.GetString(data);

        yield return serverdata = JsonConvert.DeserializeObject<ServerData>(jsonData);


    }
}

[System.Serializable]
public class ServerData
{
    public int Level;
}