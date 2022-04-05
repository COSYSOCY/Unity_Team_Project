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

    public void LoadData()
    {
        FileStream streamload = new FileStream(Application.dataPath + "/Save/Save.json", FileMode.Open);
        byte[] data = new byte[streamload.Length];
        streamload.Read(data, 0, data.Length);
        streamload.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        serverdata = JsonConvert.DeserializeObject<ServerData>(jsonData);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveData();
            Debug.Log("세이브요");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadData();
            Debug.Log("로드요");
        }
    }
}

[System.Serializable]
public class ServerData
{
    public int Level;
}