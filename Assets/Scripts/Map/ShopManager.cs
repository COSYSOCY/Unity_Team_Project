using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class ShopManager : MonoBehaviour
{
    public LobyUIMgr Loby;
    public Text ADFreeCnt;
    // Start is called before the first frame update
    void Start()
    {
        AdFreeSet();
        adstart();
    }
    void AdFreeSet()
    {
        ADFreeCnt.text="("+GameInfo.inst.AdGoldFreeMax+")";
    }

    public void AdFreeButton()
    {
        if (GameInfo.inst.AdGoldFreeMax >0)
        {
            LoadRewardAd();
            rewardAd.Show();
        }
    }

    public void CheatGold()
    {
        GameInfo.PlayerGold += 1000;
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
    RewardedAd rewardAd;


    void LoadRewardAd()
    {
        rewardAd = new RewardedAd(GameInfo.inst.isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        rewardAd.OnUserEarnedReward += (sender, e) =>
        {
            GameInfo.inst.AdGoldFreeMax--;
            GameInfo.PlayerGold += 240;
            AdFreeSet();
            Loby.LobyGoldAc();
        };
    }

    public void ShowRewardAd()
    {
        rewardAd.Show();
        LoadRewardAd();
    }
    #endregion
}
