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
        
         if (GameInfo.inst.AdCardFreeMax > 0)
        {
            if (GameInfo.inst.PcTestMode)
            {
                GameInfo.inst.AdCardFreeMax--;
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
        int GoldCost1 = 100;
        int GoldCost5 = 500;
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
    public void ItemPick(int i)
    {
        StartCoroutine(IitemPick(i));   
    }
    
    public void CheckButton()
    {
        ResetFunc();
    }

    IEnumerator IitemPick(int Cnt)
    {
        BoxAni.Play("Box1");
        PickOb1.SetActive(false);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Cnt; i++)
        {
            RandomItem(i);
        }
        PickLoading.SetActive(true);
        yield return Effect();
        for (int i = 0; i < Cnt; i++)
        {
            GambleSlot[i].SetActive(true);
        }
        BoxImage.sprite = IconManager.inst.Icons[145];
        PickOb1.SetActive(false);
        PickOb2.SetActive(true);
        PickLoading.SetActive(false);
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

    void RandomItem(int idx)
    {
        //float Pick1 = 0f;
        float Pick2 = 30f;
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
