using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;

public class ShopManager : MonoBehaviour
{
    public LobyUIMgr Loby;
    public Text ADFreeCnt_Gold;
    public Text ADFreeCnt_Card;
    public GambleManager Gamble;
    public RouletteMgr Roulette;
    // Start is called before the first frame update

    public Text savetext;

    public Text OneDaytext;

   public void savetest()
    {
        //ServerDataSystem.inst.SaveData();
        savetext.text=ServerDataSystem.inst.SaveData2();
    }
    void Start()
    {
        AdFreeSet();
        adstart();
        dayfunc();
    }

    public void dayfunc()
    {
        DateTime nowTime = DateTime.Now;
        TimeSpan timeDif = nowTime - GameInfo.inst.Daycom1;
        if (timeDif.TotalSeconds > 0)
        {
            OneDaytext.text = csvData.GameText(1138);
            OneDaytext.GetComponent<TextIdx>().Idx = 1138;
        }
        else
        {
            StartCoroutine(TimeUpdate());
        }

    }
    public void DayFunc1()
    {
        DateTime nowTime = DateTime.Now;
        TimeSpan timeDif = nowTime -GameInfo.inst.Daycom1 ;
        if (timeDif.TotalSeconds > 0)
        {
            Gamble.DayFunc();
            GameInfo.inst.Daycom1 = nowTime.AddDays(1);
            StartCoroutine(TimeUpdate());
        }
    }
    IEnumerator TimeUpdate()
    {
            yield return new WaitForSeconds(1f);
        string H;
        string M;
        DateTime nowTime;
        TimeSpan timeDif;
        while (true)
        {
            nowTime = DateTime.Now;
            timeDif =  GameInfo.inst.Daycom1 - nowTime;
            if (timeDif.TotalSeconds < 0)
            {
                OneDaytext.text = csvData.GameText(1138);
                OneDaytext.GetComponent<TextIdx>().Idx = 1138;
                break;
            }
            else
            {
                H = timeDif.Hours.ToString();
                M = timeDif.Minutes.ToString();
                OneDaytext.text = H + csvData.GameText(1139) + M + csvData.GameText(1140);
            }
            yield return new WaitForSeconds(1f);
            //TimeSpan timeDif= GameInfo.inst.Daycom1

            //H = nowTime.Hour-;
        }
    }
    public void AdFreeSet()
    {
        DateTime dateTime = DateTime.Now;
        for (int i = 0; i < GameInfo.inst.IsAdGold.Length; i++)
        {
            if (GameInfo.inst.IsAdGold[i])
            {
                TimeSpan timeDif = dateTime - GameInfo.inst.AdGoldTime[i];
                if (timeDif.Days >0)
                {
                    GameInfo.inst.IsAdGold[i] = false;
                }
            }
        }
        for (int i = 0; i < GameInfo.inst.IsAdCard.Length; i++)
        {
            if (GameInfo.inst.IsAdCard[i])
            {
                TimeSpan timeDif = dateTime - GameInfo.inst.AdCardTime[i];
                if (timeDif.Days > 0)
                {
                    GameInfo.inst.IsAdCard[i] = false;
                }
            }
        }




        ADFreeCnt_Gold.text="("+GameInfo.inst.AdGoldFreeMax()+")";
        ADFreeCnt_Card.text="("+GameInfo.inst.AdCardFreeMax()+")";
    }
    public void RouletteFunc()
    {
        if (GameInfo.inst.PcTestMode)
        {
            Roulette.SpinFreeBtn();
        }
        else if (!Roulette.IsGo)
        {
            LoadRewardAd3();
            rewardAd.Show();
        }
    }
    public void AdGoldFunc()
    {
        if (GameInfo.inst.AdGoldFreeMax() == 0)
        {
            return;
        }
        for (int i = 0; i < GameInfo.inst.IsAdGold.Length; i++)
        {
            if (!GameInfo.inst.IsAdGold[i])
            {
                GameInfo.inst.IsAdGold[i] = true;
                GameInfo.inst.AdGoldTime[i] = DateTime.Now.AddHours(8);
                return;
            }
        }
    }
    public void AdCardFunc()
    {
        if (GameInfo.inst.AdCardFreeMax() == 0)
        {
            return;
        }
        for (int i = 0; i < GameInfo.inst.IsAdCard.Length; i++)
        {
            if (!GameInfo.inst.IsAdCard[i])
            {
                GameInfo.inst.IsAdCard[i] = true;
                GameInfo.inst.AdCardTime[i] = DateTime.Now.AddHours(8);
                return;
            }
        }
    }

    public void AdFreeButton()
    {
        if (GameInfo.inst.AdGoldFreeMax() > 0)
        {
            if (GameInfo.inst.PcTestMode)
            {
                AdGoldFunc();
                GameInfo.PlayerGold += 250;
                AdFreeSet();
                Loby.LobyGoldAc();
            }
            else
            {

            LoadRewardAd();
            rewardAd.Show();
            }
        }
    }

    public void CheatGold()
    {
        GameInfo.PlayerGold += 5000;
        Loby.LobyGoldAc();
    }
    public void CheatPoint()
    {
        //GameInfo.PlayerPoint += 100;
        //Loby.LobyGoldAc();
    }
    public void shopGoldButton1()
    {
        //if (GameInfo.PlayerPoint >= 50)
        //{
        //    GameInfo.PlayerPoint -= 50;
        //    GameInfo.PlayerGold += 650;
        //    Loby.LobyGoldAc();
        //}
    }
    public void shopGoldButton2()
    {
        //if (GameInfo.PlayerPoint >= 100)
        //{
        //    GameInfo.PlayerPoint -= 100;
        //    GameInfo.PlayerGold += 1500;
        //    Loby.LobyGoldAc();
        //}
    }
    public void shopGoldButton3()
    {
        //if (GameInfo.PlayerPoint >= 150)
        //{
        //    GameInfo.PlayerPoint -= 150;
        //    GameInfo.PlayerGold += 3000;
        //    Loby.LobyGoldAc();
        //}
    }
    public void shopGoldButton4()
    {
        //if (GameInfo.PlayerPoint >= 500)
        //{
        //    GameInfo.PlayerPoint -= 500;
        //    GameInfo.PlayerGold += 10000;
        //    Loby.LobyGoldAc();
        //}
    }
    public void shopGoldButton5()
    {
        //if (GameInfo.PlayerPoint >= 650)
        //{
        //    GameInfo.PlayerPoint -= 650;
        //    GameInfo.PlayerGold += 15000;
        //    Loby.LobyGoldAc();
        //}
    }


    void adstart()
    {
        var requestConfiguration = new RequestConfiguration
   .Builder()
   .SetTestDeviceIds(new List<string>()
   {
               "44990154B448482F"
   }) // test Device ID
   .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);

        //LoadFrontAd();
        //
    }
    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }


    #region Àü¸é ±¤°í
    const string frontTestID = "ca-app-pub-3940256099942544/8691691433";
    const string frontID = "ca-app-pub-9521969151385232/7036931465";
    InterstitialAd frontAd;


    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(GameInfo.inst.isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());
        frontAd.OnAdClosed += (sender, e) =>
        {
            //Debug.Log("Àü¸é±¤°í ¼º°ø");
        };
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }
    #endregion



    #region ¸®¿öµå ±¤°í
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "ca-app-pub-9521969151385232/8252088014";
    public RewardedAd rewardAd;


    void LoadRewardAd()
    {
        rewardAd = new RewardedAd(GameInfo.inst.isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            // GameInfo.inst.AdGoldFreeMax--;
            AdGoldFunc();
            GameInfo.PlayerGold += 240;
            AdFreeSet();
            Loby.LobyGoldAc();
        };
    }
    public void LoadRewardAd2()
    {
        rewardAd = new RewardedAd(GameInfo.inst.isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            // GameInfo.inst.AdCardFreeMax--;
            AdCardFunc();
            AdFreeSet();
            Gamble.ItemPick(1);
        };
    }
    public void LoadRewardAd3()
    {
        rewardAd = new RewardedAd(GameInfo.inst.isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            Roulette.SpinFreeBtn();
        };
    }

    public void ShowRewardAd()
    {
        rewardAd.Show();
        LoadRewardAd();
    }
    #endregion
}
