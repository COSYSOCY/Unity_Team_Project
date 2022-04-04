using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class LevelUp : MonoBehaviour
{
    public bool testcheck=false;
    public GameObject LevelUiObject;
    public SkillManager skillManager;
    public List<GameObject> num; // 실질적으로 뽑아야하는 랜덤
    public List<GameObject> num2; // 랜덤 1~4개 나와야하는것들
    public PlayerInfo playerInfo;
    public GameObject[] Skill_name;
    public GameObject[] Skill_Lv;
    public GameObject[] Skill_Text;
    public GameObject[] Skill_Image;
    public List<GameObject> LevelupUiOb;
    public PlayerMoving moving;
    public GameObject Money;
    public GameObject Heal;
    public PlayerStatus status;
    public bool IsShow = false;
    public GameObject ShowText;
    public GameObject ShowImage;
    public GameObject Adicon;


    private void Start()
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
        //LoadRewardAd();
    }
    //private void Update()
    //{
    //    FrontAdsBtn.interactable = frontAd.IsLoaded();
    //    RewardAdsBtn.interactable = rewardAd.IsLoaded();
    //}
    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }
    // Start is called before the first frame update

    void LevelupFunc()
    {
        int cnt = 0;

        if (playerInfo.Lv==2)
        {
            for (int i = 0; i < skillManager.Skills.Count; i++)
            {
                num.Add(skillManager.Skills[i]);
            }
            //num = skillManager.Skills;
            int ran;
            for (int i = 0; i < 4; i++)
            {
                ran = Random.Range(0, num.Count);
                num2.Add(num[ran]);
                num.RemoveAt(ran);
            }
        }
        else
        {
            if (playerInfo.SkillCnt >= playerInfo.SkillMax)
            {
                for (int i = 0; i < skillManager.Skill_Active.Count; i++)
                {
                    if (skillManager.Skill_Active[i].GetComponent<Skill_Info>().Lv < skillManager.Skill_Active[i].GetComponent<Skill_Info>().LvMax)
                    {
                        num.Add(skillManager.Skill_Active[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < skillManager.Skills.Count; i++)
                {

                    if (skillManager.Skills[i].GetComponent<Skill_Info>().Lv < skillManager.Skills[i].GetComponent<Skill_Info>().LvMax)
                    {
                        num.Add(skillManager.Skills[i]);
                    }
                }

            }

            if (playerInfo.SkillItemCnt >= playerInfo.SkillItemMax)
            {
                for (int i = 0; i < skillManager.Skill_Item_Active.Count; i++)
                {
                    if (skillManager.Skill_Item_Active[i].GetComponent<Skill_ItemInfo>().Lv < skillManager.Skill_Item_Active[i].GetComponent<Skill_ItemInfo>().LvMax)
                    {
                        num.Add(skillManager.Skill_Item_Active[i]);
                    }
                }

            }
            else
            {
                for (int i = 0; i < skillManager.Skill_Items.Count; i++)
                {
                    if (skillManager.Skill_Items[i].GetComponent<Skill_ItemInfo>().Lv < skillManager.Skill_Items[i].GetComponent<Skill_ItemInfo>().LvMax)
                    {
                        num.Add(skillManager.Skill_Items[i]);
                    }
                }
            }






            cnt =num.Count;
            if (cnt == 0)
            {
                num2.Add(Money);
                num2.Add(Heal);
                LevelupUiOb[2].SetActive(false);
                LevelupUiOb[3].SetActive(false);
            }
            else if(cnt == 1)
            {
                num2.Add(num[0]);
                LevelupUiOb[1].SetActive(false);
                LevelupUiOb[2].SetActive(false);
                LevelupUiOb[3].SetActive(false);
            }
            else if (cnt == 2)
            {
                num2.Add(num[0]);
                num2.Add(num[1]);
                LevelupUiOb[2].SetActive(false);
                LevelupUiOb[3].SetActive(false);
            }
            else if (cnt == 3)
            {
                num2.Add(num[0]);
                num2.Add(num[1]);
                num2.Add(num[2]);
                //LevelupUiOb[2].SetActive(false);
                LevelupUiOb[3].SetActive(false);
            }
            else
            {
                int ran;
                for (int i = 0; i < 4; i++)
                {
                    ran = Random.Range(0, num.Count);
                    num2.Add(num[ran]);
                    num.RemoveAt(ran);
                }


               


            }






        }
        if (num2[0]== Money)
        {
            Skill_name[0].GetComponent<Text>().text = csvData.GameText(462);
            Skill_Lv[0].GetComponent<Text>().text = "";
            Skill_Image[0].GetComponent<Image>().sprite = IconManager.inst.Icons[75];
            Skill_Text[0].GetComponent<Text>().text = csvData.GameText(464);

            Skill_name[1].GetComponent<Text>().text = csvData.GameText(463);
            Skill_Lv[1].GetComponent<Text>().text = "";
            Skill_Image[1].GetComponent<Image>().sprite = IconManager.inst.Icons[74];
            Skill_Text[1].GetComponent<Text>().text = csvData.GameText(465);
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                string name = "";
                int Lv = 0;
                int image = 0;
                string text = "";
                if (num2[i].GetComponent<Skill_item_Check>().Skill)
                {
                    name = num2[i].GetComponent<Skill_Info>().Skill_Name;
                    Lv = num2[i].GetComponent<Skill_Info>().Lv;
                    image = num2[i].GetComponent<Skill_Info>().Skill_Icon;
                    text = num2[i].GetComponent<Skill_Info>().Lv_Text[Lv];


                    Skill_name[i].GetComponent<Text>().text = name;
                    if (Lv == 0)
                    {
                        Skill_Lv[i].GetComponent<Text>().text = csvData.GameText(460) + "!";
                    }
                    else
                    {
                        Skill_Lv[i].GetComponent<Text>().text = csvData.GameText(461) + ": " + (Lv + 1);
                    }

                    Skill_Image[i].GetComponent<Image>().sprite = IconManager.inst.Icons[image];
                    Skill_Text[i].GetComponent<Text>().text = text;
                }
                else
                {
                    name = num2[i].GetComponent<Skill_ItemInfo>().Skill_Item_Name;
                    Lv = num2[i].GetComponent<Skill_ItemInfo>().Lv;
                    image = num2[i].GetComponent<Skill_ItemInfo>().Skill_Icon;
                    text = num2[i].GetComponent<Skill_ItemInfo>().Lv_Text[Lv];


                    Skill_name[i].GetComponent<Text>().text = name;
                    if (Lv == 0)
                    {
                        Skill_Lv[i].GetComponent<Text>().text = csvData.GameText(460) + "!";
                    }
                    else
                    {
                        Skill_Lv[i].GetComponent<Text>().text = csvData.GameText(461) + ": " + (Lv + 1);
                    }

                    Skill_Image[i].GetComponent<Image>().sprite = IconManager.inst.Icons[image];
                    Skill_Text[i].GetComponent<Text>().text = text;
                }
                

                
            }

        }






        //for (int i = 0; i < 3; i++)
        //{
        //    int a = Random.Range(0, num2.Count);
        //    num.Add(num2[a]);
        //    num2.RemoveAt(a);
        //}


        //for (int i = 0; i < 3; i++)
        //{


        //    //var a = GetComponent<Skill_1>();
        //    //var a = Skill_1;
        //    GameObject gameObject;

        //    gameObject = skillManager.Skills[num[i]];

        //    string name = "";
        //    int Lv = 0;
        //    int image = 0;
        //    string text = "";

        //    name = gameObject.GetComponent<Skill_Info>().Skill_Name;
        //    Lv = gameObject.GetComponent<Skill_Info>().Lv;
        //    image = gameObject.GetComponent<Skill_Info>().Skill_Icon;
        //    text = gameObject.GetComponent<Skill_Info>().Lv_Text[Lv];



        //    Skill_name[i].GetComponent<Text>().text = name;
        //    if (Lv == 0)
        //    {
        //        Skill_Lv[i].GetComponent<Text>().text = "신규!";
        //    }
        //    else
        //    {
        //        Skill_Lv[i].GetComponent<Text>().text = "레벨: " + (Lv + 1);
        //    }

        //    Skill_Image[i].GetComponent<Image>().sprite = skillManager.Skill_icon[image];
        //    Skill_Text[i].GetComponent<Text>().text = text;

        //}
    }
    public void LevelFunc()
    {

        moving.stick.localPosition = Vector2.zero;
        moving.pad.gameObject.SetActive(false);
        moving.StopAllCoroutines();
        moving.move = Vector3.zero;
        IsShow = false;
        ShowImage.SetActive(true);
        ShowText.SetActive(true);

        testcheck = true;

        num.Clear();
        num2.Clear();
        Time.timeScale = 0f;
        LevelUiObject.SetActive(true);
        LevelupUiOb[0].SetActive(true);
        LevelupUiOb[1].SetActive(true);
        LevelupUiOb[2].SetActive(true);
        LevelupUiOb[3].SetActive(true);
        Adicon.SetActive(true);
        LevelupFunc();
    }


    void ButonClick(GameObject Ob)
    {
        int Lv = 0;
        Time.timeScale = 1f;
        LevelUiObject.SetActive(false);
        testcheck = false;
        Lv = Ob.GetComponent<Skill_Info>().Lv;
        if (Lv == 0)
        {
            Ob.SetActive(true);

        }
        else
        {
            // gameObject.GetComponent<Skill_Info>().LevelUpCheck();
            Ob.GetComponent<Skill_Ori>().LevelUp();
        }
        //skillManager.Skill_All_Active.Add(Ob);


    }
    void ButonClick_Item(GameObject Ob)
    {
        int Lv = 0;
        Time.timeScale = 1f;
        LevelUiObject.SetActive(false);
        testcheck = false;
        Lv = Ob.GetComponent<Skill_ItemInfo>().Lv;
        if (Lv == 0)
        {
            Ob.SetActive(true);

        }
        else
        {
            // gameObject.GetComponent<Skill_Info>().LevelUpCheck();
            Ob.GetComponent<Skill_Item_Ori>().LevelUp();
        }
        //skillManager.Skill_All_Active.Add(Ob);


    }


    public void ButtonClick_1()
    {
        GameObject ob = num2[0];
        if (ob == Money)
        {
            status.GoldPlus(25);
            Time.timeScale = 1f;
            LevelUiObject.SetActive(false);
            testcheck = false;
        }
        else
        {
            if (ob.GetComponent<Skill_item_Check>().Skill)
            {
            ButonClick(ob);

            }
            else
            {
            ButonClick_Item(ob);

            }
        }             
    }
    public void ButtonClick_2()
    {
        GameObject ob = num2[1];
        if (ob == Heal)
        {
            status.HpPlus(30);
            Time.timeScale = 1f;
            LevelUiObject.SetActive(false);
            testcheck = false;
        }
        else
        {
            if (ob.GetComponent<Skill_item_Check>().Skill)
            {
                ButonClick(ob);

            }
            else
            {
                ButonClick_Item(ob);

            }
        }
    }
    public void ButtonClick_3()
    {
        GameObject ob = num2[2];
        if (ob.GetComponent<Skill_item_Check>().Skill)
        {
            ButonClick(ob);

        }
        else
        {
            ButonClick_Item(ob);
        }
    }
    public void ButtonClick_4()
    {
        if (!IsShow)
        {
            ShowFunc();
            return;
        }
        GameObject ob = num2[3];
        if (ob.GetComponent<Skill_item_Check>().Skill)
        {
            ButonClick(ob);

        }
        else
        {
            ButonClick_Item(ob);

        }
    }
    public void ShowFunc()
    {
        LoadRewardAd(0);
        rewardAd.Show();  
        //ShowRewardAd();
    }

    #region 전면 광고
    const string frontTestID = "ca-app-pub-3940256099942544/8691691433";
    const string frontID = "ca-app-pub-9521969151385232/7036931465";
    InterstitialAd frontAd;


    void LoadFrontAd()
    {
        frontAd = new InterstitialAd(GameInfo.inst.isTestMode ? frontTestID : frontID);
        frontAd.LoadAd(GetAdRequest());
        frontAd.OnAdClosed += (sender, e) =>
        {
            //Debug.Log("전면광고 성공");
        };
    }

    public void ShowFrontAd()
    {
        frontAd.Show();
        LoadFrontAd();
    }
    #endregion



    #region 리워드 광고
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "ca-app-pub-9521969151385232/8252088014";
    RewardedAd rewardAd;


    void LoadRewardAd(int i)
    {
        rewardAd = new RewardedAd(GameInfo.inst.isTestMode ? rewardTestID : rewardID);
        rewardAd.LoadAd(GetAdRequest());
        if (i == 0)
        {
                rewardAd.OnUserEarnedReward += (sender, e) =>
                {
                    //Debug.Log("리워드 성공");
                    IsShow = true;
                    ShowImage.SetActive(false);
                    ShowText.SetActive(false);
                    Adicon.SetActive(false);

                    Time.timeScale = 0f;
                };
        }
        else if (i==1)
        {
            rewardAd.OnUserEarnedReward += (sender, e) =>
            {
                Time.timeScale = 1f;
                StartCoroutine(MainSingleton.instance.playerstat.AdIn());
            };
        }

    }
    public void ADRFunc()
    {
        LoadRewardAd(1);
        rewardAd.Show();
    }
    //public void ShowRewardAd(int i)
    //{
    //    rewardAd.Show();
    //    LoadRewardAd(i);
    //}
    #endregion

}
