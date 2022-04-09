using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loby_PowerUpInfo : MonoBehaviour
{
    public int Idx;
    public int MaxLv;
    public int Level;
    public int NameNum;
    public int InfoNum;
    public List<int> GoldCost;
    public Text MainLvText;
    public Image MainImage;
    public PowerUpManager manager;


    private void Start()
    {
        MaxLv = csvData.Pu_LevelMax[Idx];
        Level = GameInfo.inst.Player_PowerUp[Idx];
        NameNum = csvData.Pu_NameNum[Idx];
        InfoNum = csvData.Pu_InfoNum[Idx];
        GoldCost[0] = csvData.Pu_Cost1[Idx];
        GoldCost[1] = csvData.Pu_Cost2[Idx];
        GoldCost[2] = csvData.Pu_Cost3[Idx];
        GoldCost[3] = csvData.Pu_Cost4[Idx];
        GoldCost[4] = csvData.Pu_Cost5[Idx];
        GoldCost[5] = csvData.Pu_Cost6[Idx];
        GoldCost[6] = csvData.Pu_Cost7[Idx];
        GoldCost[7] = csvData.Pu_Cost8[Idx];
        GoldCost[8] = csvData.Pu_Cost9[Idx];
        GoldCost[9] = csvData.Pu_Cost10[Idx];
        if (Level >= MaxLv)
        {
            MainLvText.text= csvData.GameText(1022);
        }
        else
        {
            MainLvText.text = Level + " / " + MaxLv;
        }
        
    }

    public void ClickFunc()
    {
        manager.ClickFunc(Idx,gameObject);
    }
}
