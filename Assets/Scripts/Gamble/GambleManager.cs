using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GambleManager : MonoBehaviour
{

    public Image BoxImage;
    public GameObject[] GambleSlot;
    public Image[] GambleSlotImage;
    public Text[] GambleSlotLv;
    public Text[] GambleSlotName;

    public ShopManager ShopManager;
    public GameObject PickOb1;
    public GameObject PickOb2;
    public GameObject PickLoading;
    public RectTransform PickLoading2;
    public CardManager CardManager;
    public LobyUIMgr lobyManager;

    public Animator BoxAni;

    public GameObject gambleob;
    //GameInfo.inst.PlayerCards.Add(i);
    public void ResetFunc()
    {
        BoxImage.sprite = IconManager.inst.Icons[144];
        PickOb1.SetActive(true);
        PickOb2.SetActive(false);
        for (int i = 0; i < GambleSlot.Length; i++)
        {
            GambleSlot[i].SetActive(false);
        }
    }
    public void ItemAd()
    {
        
         if (GameInfo.inst.AdCardFreeMax() > 0)
        {
            if (GameInfo.inst.PcTestMode)
            {
                //GameInfo.inst.AdCardFreeMax--;
                ShopManager.AdCardFunc();
                ShopManager.AdFreeSet();
                ItemPick(1);
            }
            else
            {

            ShopManager.LoadRewardAd2();
            ShopManager.rewardAd.Show();
            }
        }
        
        //
    }
    public void ItemPickButton(int i)
    {
        int GoldCost1 = 300;
        int GoldCost5 = 1400;
        if (i ==1)
        {
            if (GameInfo.PlayerGold >= GoldCost1)
            {
                GameInfo.PlayerGold -= GoldCost1;
                ItemPick(i);
            }
        }
        else if (i == 5)
        {
            if (GameInfo.PlayerGold >= GoldCost5)
            {
                GameInfo.PlayerGold -= GoldCost5;
                ItemPick(5);
            }
        }
        lobyManager.LobyGoldAc();
    }
    public void StartFunc()
    {
        ResetFunc();
    }
    public void DayFunc()
    {
        gambleob.SetActive(true);
        BoxImage.sprite = IconManager.inst.Icons[144];
        PickOb1.SetActive(true);
        PickOb2.SetActive(false);
        for (int i = 0; i < GambleSlot.Length; i++)
        {
            GambleSlot[i].SetActive(false);
        }
        PickOb1.SetActive(false);
        PickOb2.SetActive(false);
        StartCoroutine(IitemPick(1,1));
    }
    public void ItemPick(int i)
    {
        StartCoroutine(IitemPick(i));   
    }
    
    public void CheckButton()
    {
        ResetFunc();
    }

    IEnumerator IitemPick(int Cnt,int Check=0)
    {
        BoxAni.Play("Box1");
        PickOb1.SetActive(false);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Cnt; i++)
        {
            if (Check==1)
            {
            RandomItem2(i);

            }
            else
            {

            RandomItem(i);
            }
        }
        PickLoading.SetActive(true);
        BoxImage.gameObject.transform.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        yield return Effect();
        for (int i = 0; i < Cnt; i++)
        {
            GambleSlot[i].SetActive(true);
        }
        BoxImage.sprite = IconManager.inst.Icons[145];
        PickOb1.SetActive(false);
        PickOb2.SetActive(true);
        PickLoading.SetActive(false);

        if (GameInfo.inst.PcTestMode)
        {
            ServerDataSystem.inst.SaveData2asdasdasd();
        }
        else
        {
            ServerDataSystem.inst.SaveData2asdasdasd();
            //ServerDataSystem.inst.ServerSave();
        }
        //if (Check==1)
        //{
        //    gambleob.SetActive(false);
        //}

        GameInfo.inst.PlayerCardPickCnt++;
        if (GameInfo.inst.Player_Mission[40] == 0 && GameInfo.inst.PlayerCardPickCnt >= 5)
        {
            GameInfo.inst.MissionGo(40);
        }
        else if (GameInfo.inst.Player_Mission[41] == 0 && GameInfo.inst.PlayerCardPickCnt >= 100)
        {
            GameInfo.inst.MissionGo(41);
        }
    }

    IEnumerator Effect()
    {
        float a = 1f;
        for (int i = 0; i < 50; i++)
        {
            a += 0.6f;
            PickLoading2.localScale=new Vector3(a, a, a);
            //yield return new WaitForSeconds(0.1f);
            yield return null;
        }
    }
    void RandomItem2(int idx)
    {
        float Pick2 = 10;
        float Pick3 = 2f;
        float Pick4 = 1f;
        float Pick5 = 0.1f;
        int IconNum = 0;
        int NameNum = 0;
        int CardLv = 0;
        int RandomIdx = 0;
        int Lv = 1;
        float Ran = Random.Range(0.01f, 100f);
        if (Ran <= Pick5)
        {
            Lv = 5;
        }
        else if (Ran <= Pick4)
        {
            Lv = 4;

        }
        else if (Ran <= Pick3)
        {
            Lv = 3;
        }
        else if (Ran <= Pick2)
        {
            Lv = 2;
        }
        else
        {
            Lv = 1;
        }


        int ranList = Random.Range(0, GameInfo.inst.Cards_Lv(Lv).Count);
        RandomIdx = GameInfo.inst.Cards_Lv(Lv)[ranList];


        IconNum = GameInfo.inst.CardsInfo[RandomIdx].CardIconNum;
        NameNum = GameInfo.inst.CardsInfo[RandomIdx].CardNameNum;
        CardLv = GameInfo.inst.CardsInfo[RandomIdx].CardLv;

        GambleSlotImage[idx].sprite = IconManager.inst.Icons[IconNum];
        GambleSlotLv[idx].text = "¡Ú" + CardLv;
        GambleSlotName[idx].text = csvData.GameText(NameNum);
        CardManager.ItemAdd(RandomIdx);
    }
    void RandomItem(int idx)
    {
        //float Pick1 = 0f;
        float Pick2 = 20f;
        float Pick3 = 5f;
        float Pick4 = 1f;
        float Pick5 = 0.1f;
        int IconNum = 0;
        int NameNum = 0;
        int CardLv = 0;
        int RandomIdx = 0;
        int Lv = 1;
        float Ran = Random.Range(0.01f, 100f);
        if (Ran <= Pick5)
        {
            Lv = 5;
        }
        else if (Ran <= Pick4)
        {
            Lv = 4;

        }
        else if (Ran <= Pick3)
        {
            Lv = 3;
        }
        else if (Ran <= Pick2)
        {
            Lv = 2;
        }
        else
        {
            Lv = 1;
        }

        int ranList = Random.Range(0, GameInfo.inst.Cards_Lv(Lv).Count);
        RandomIdx = GameInfo.inst.Cards_Lv(Lv)[ranList];
 

        IconNum = GameInfo.inst.CardsInfo[RandomIdx].CardIconNum;
        NameNum = GameInfo.inst.CardsInfo[RandomIdx].CardNameNum;
        CardLv = GameInfo.inst.CardsInfo[RandomIdx].CardLv;

        GambleSlotImage[idx].sprite = IconManager.inst.Icons[IconNum];
        GambleSlotLv[idx].text = "¡Ú"+CardLv;
        GambleSlotName[idx].text = csvData.GameText(NameNum);
        CardManager.ItemAdd(RandomIdx);
    }
}
