using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public string dataPath_Characters;
    public string dataPath_Enemy;
    public string dataPath_Skill;
    public string dataPath_item;
    public string dataPath_String;
    [SerializeField]
    public List<Dictionary<string, object>> data;


    private void Awake()
    {
        Characters_Read();
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
}
