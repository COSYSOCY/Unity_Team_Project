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
            ShowRewardAd();
        }
    }

    public void CheatGold()
    {
        GameInfo.PlayerGold += 100;
        Loby.LobyGoldAc();
    }
    public void CheatPoint()
    {
        GameInfo.PlayerPoint += 100;
        Loby.LobyGoldAc();
    }
    public void shopButton1()
    {
        if (GameInfo.PlayerPoint >= 50)
        {
            GameInfo.PlayerPoint -= 50;
            GameInfo.PlayerGold += 3000;
            Loby.LobyGoldAc();
        }
    }
    public void shopButton2()
    {
        if (GameInfo.PlayerPoint >= 120)
        {
            GameInfo.PlayerPoint -= 120;
            GameInfo.PlayerGold += 9000;
            Loby.LobyGoldAc();
        }
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

        LoadFrontAd();
        LoadRewardAd();
    }
    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }


    #region ���� ����
    const string frontTestID = "ca-app-pub-3940256099942544/8691691433";
    const string frontID = "ca-app-pub-9521969151385232/7036931465";
    InterstitialAd frontAd;


    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(GameInfo.inst.isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());
        frontAd.OnAdClosed += (sender, e) =>
        {
            //Debug.Log("���鱤�� ����");
        };
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }
    #endregion



    #region ������ ����
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
            GameInfo.PlayerGold += 500;
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