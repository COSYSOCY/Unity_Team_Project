using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public GameObject ClickOb;
    public GameObject SubOb;
    public Image SubImage;
    public Text SubNameText;
    public Text SubInfoText;
    public Text SubLvText;
    public Text SubGoldText;
    public GameObject UpOb;
    public Color setcolor;
    public Color setcolor2;
    public LobyUIMgr uimgr;

    public void Start()
    {
        PowerUpInfo.instance.ResetFunc();
    }
    public void ClickFunc(int i,GameObject g)
    {
        SubOb.SetActive(true);
        SubImage.sprite = g.GetComponent<Loby_PowerUpInfo>().MainImage.sprite;
        ClickOb = g;
        setFunc();


    }
    void setFunc()
    {
        int Lv = ClickOb.GetComponent<Loby_PowerUpInfo>().Level;
        int LvMax = ClickOb.GetComponent<Loby_PowerUpInfo>().MaxLv;
        int cost;
        
        SubNameText.text = csvData.GameText(ClickOb.GetComponent<Loby_PowerUpInfo>().NameNum);
        SubInfoText.text = csvData.GameText(ClickOb.GetComponent<Loby_PowerUpInfo>().InfoNum);
        if (Lv >= LvMax)
        {
            cost = 0;
            UpOb.SetActive(false);
            SubGoldText.text = "";
            SubLvText.text = csvData.GameText(1022);
        }
        else
        {
            cost = ClickOb.GetComponent<Loby_PowerUpInfo>().GoldCost[Lv];
            UpOb.SetActive(true);
            SubGoldText.text = cost.ToString();
            SubLvText.text = Lv + " / " + LvMax;
        }

        if (GameInfo.PlayerGold < cost)
        {
            UpOb.GetComponent<Image>().color = setcolor;
        }
        else
        {
            UpOb.GetComponent<Image>().color = setcolor2;

        }
        PowerUpInfo.instance.ResetFunc();
    }
    public void UpFunc()
    {
        int Lv = ClickOb.GetComponent<Loby_PowerUpInfo>().Level;
        int LvMax = ClickOb.GetComponent<Loby_PowerUpInfo>().MaxLv;
        int cost = ClickOb.GetComponent<Loby_PowerUpInfo>().GoldCost[Lv];

        if (GameInfo.PlayerGold < cost)
        {
            return;
        }
        GameInfo.PlayerGold -= cost;
        uimgr.LobyGoldAc();
        ClickOb.GetComponent<Loby_PowerUpInfo>().Level++;
        GameInfo.inst.Player_PowerUp[ClickOb.GetComponent<Loby_PowerUpInfo>().Idx]++;
        setFunc();

        if (ClickOb.GetComponent<Loby_PowerUpInfo>().Level >= ClickOb.GetComponent<Loby_PowerUpInfo>().MaxLv)
        {
            ClickOb.GetComponent<Loby_PowerUpInfo>().MainLvText.text = csvData.GameText(1022);
        }
        else
        {
            ClickOb.GetComponent<Loby_PowerUpInfo>().MainLvText.text = ClickOb.GetComponent<Loby_PowerUpInfo>().Level + " / " + ClickOb.GetComponent<Loby_PowerUpInfo>().MaxLv;
        }
        if (GameInfo.inst.PcTestMode)
        {
            ServerDataSystem.inst.SaveData2asdasdasd();
        }
        else
        {
            ServerDataSystem.inst.SaveData2asdasdasd();
            //ServerDataSystem.inst.ServerSave();
        }
    }
}
