using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxScritps : MonoBehaviour
{
    public GameObject BoxUiOb1;

    public GameObject BoxUiOb2;

    public List<GameObject> Slot;
    public GameObject OpenOb;
    public GameObject ExitOb;
    public Image BoxImage;

    public Sprite[] icon;
    public Image[] SlotImage;
    public Sprite[] SlotImage2;

    public List<GameObject> CheckList;

    public int Gold = 0;
    public Text GoldText;

    public GameObject goldeff;
    public GameObject cardeff;

    public int Cnt;
    public Animator boxani;



    // »Ì±â
    public UIManager uimanager;
    public GameObject ob;
    public Image[] ComBoxImage;
    public Image[] ComImage;
    public GameObject[] ComButton;
    public GameObject ComLoading;
    public int Comint;
    public Animator[] ComBoxani;
    public bool ComAd;
    public bool ComNo=false;
    public void BoxFunc1(int idx)
    {
        if (idx==0)
        {
            Cnt = 1;
        }
        else
        {

        float random = Random.Range(0.01f, 100f);
        float RandomCnt2 = 40;
        float RandomCnt3 = 20;
        float RandomCnt4 = 10;
        float RandomCnt5 = 3;
        if (random <= RandomCnt5)
        {
            Cnt = 5;
        }
        else if (random <= RandomCnt4)
        {
            Cnt = 4;
        }
        else if (random <= RandomCnt3)
        {
            Cnt = 3;
        }
        else if (random <= RandomCnt2)
        {
            Cnt = 2;
        }
        else
        {
            Cnt = 1;
        }
        }
        CheckList.Clear();
        Time.timeScale = 0f;
        BoxImage.sprite = icon[1];
        BoxUiOb1.SetActive(true);
        BoxUiOb2.SetActive(false);
        OpenOb.SetActive(true);
        ExitOb.SetActive(false);
        GoldText.text = "";
        for (int i = 0; i < Slot.Count; i++)
        {
            Slot[i].SetActive(false);
        }
    }
    public void OpenFunc()
    {
        OpenOb.SetActive(false);
        StartCoroutine(IBoxFunc(Cnt));
    }
    IEnumerator IBoxFunc(int cnt)
    {
        boxani.Play("Box1");
        yield return new WaitForSecondsRealtime(1);
        BoxImage.gameObject.transform.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i < cnt; i++)
        {
            yield return(RandomUp(i));

                yield return null;
        }
        BoxUiOb2.SetActive(true);
        
        //yield return new WaitForSecondsRealtime(0.1f);
        yield return Effect();
        ExitOb.SetActive(true);
        BoxImage.sprite = icon[0];
        GoldText.text = Gold.ToString();
        for (int i = 0; i < cnt; i++)
        {
            Slot[i].SetActive(true);
        }
        BoxUiOb2.SetActive(false);
    }
    IEnumerator Effect()
    {
        float a = 1f;
        for (int i = 0; i < 50; i++)
        {
            a += 0.6f;
            BoxUiOb2.GetComponent<RectTransform>().localScale = new Vector3(a, a, a);
            //yield return new WaitForSeconds(0.1f);
            yield return null;
        }
    }
    IEnumerator Effect2()
    {
        ComLoading.SetActive(true);
        float a = 1f;
        for (int i = 0; i < 50; i++)
        {
            a += 0.6f;
            ComLoading.GetComponent<RectTransform>().localScale = new Vector3(a, a, a);
            //yield return new WaitForSeconds(0.1f);
            yield return null;
        }
        ComLoading.SetActive(false);
    }
    IEnumerator RandomUp(int Idx)
    {
        CheckList.Clear();
        for (int i = 0; i < Slot.Count; i++)
        {
            Slot[i].SetActive(false);
        }
        int ImageNum = 0;
        int RandomGold = Random.Range(0, 100);
        int idx = 0;
        Gold += RandomGold;
        for (int i = 0; i < MainSingleton.instance.skillmanager.Skill_All_Active.Count; i++)
        {
            int Lv = 0;
            int LvMax = 0;
            if (MainSingleton.instance.skillmanager.Skill_All_Active[i].GetComponent<Skill_item_Check>().Skill)
            {
                Lv= MainSingleton.instance.skillmanager.Skill_All_Active[i].GetComponent<Skill_Info>().Lv;
                LvMax = MainSingleton.instance.skillmanager.Skill_All_Active[i].GetComponent<Skill_Info>().LvMax;
                idx = MainSingleton.instance.skillmanager.Skill_All_Active[i].GetComponent<Skill_Info>().Index;
            }
            else
            {
                Lv = MainSingleton.instance.skillmanager.Skill_All_Active[i].GetComponent<Skill_ItemInfo>().Lv;
                LvMax = MainSingleton.instance.skillmanager.Skill_All_Active[i].GetComponent<Skill_ItemInfo>().LvMax;
                idx = MainSingleton.instance.skillmanager.Skill_All_Active[i].GetComponent<Skill_ItemInfo>().Index;
            }
            if (Lv >= LvMax)
            {
                
            }
            else
            {
                CheckList.Add(MainSingleton.instance.skillmanager.Skill_All_Active[i]);
            }
        }
        if (CheckList.Count > 0)
        {
            int random = Random.Range(0, CheckList.Count);
            GameObject ob = MainSingleton.instance.skillmanager.Skill_All_Active[random];
            int Lv = 0;
            int LvMax = 0;
            if (ob.GetComponent<Skill_item_Check>().Skill)
            {
                Lv = ob.GetComponent<Skill_Info>().Lv;
                LvMax = ob.GetComponent<Skill_Info>().LvMax;
            }
            else
            {
                Lv = ob.GetComponent<Skill_ItemInfo>().Lv;
                LvMax = ob.GetComponent<Skill_ItemInfo>().LvMax;
            }
            if (Lv >= LvMax)
            {
                int RandomGoldAdd = Random.Range(30, 50);
                Gold += RandomGoldAdd;
                ImageNum = 143;
            }
            else
            {
                if (ob.GetComponent<Skill_item_Check>().Skill)
                {
                    ob.GetComponent<Skill_Ori>().LevelUp();
                    ImageNum = ob.GetComponent<Skill_Info>().Skill_Icon;
                }
                else
                {
                    ob.GetComponent<Skill_Item_Ori>().LevelUp();
                    ImageNum = ob.GetComponent<Skill_ItemInfo>().Skill_Icon;
                }
            }

            
        }
        else
        {
            int RandomGoldAdd = Random.Range(30, 50);
            Gold += RandomGoldAdd;
            ImageNum = 143;
            
        }
        //Debug.Log(ImageNum);
        SlotImage[Idx].sprite = IconManager.inst.Icons[ImageNum];
        yield return new WaitForSecondsRealtime(0.1f);

        //return 0;
    }
    public void ExitFunc()
    {
        Time.timeScale = 1f;
       // MainSingleton.instance.playerinfo.Gold += Gold;
        MainSingleton.instance.uimanager.GoldUp(Gold);
        BoxUiOb1.SetActive(false);
    }

    public void BoxFunc2()
    {
        float random = Random.Range(0.01f, 100f);
        float RandomCnt2 = 50; 
        if(random >= RandomCnt2)
        {
            Instantiate(goldeff);
        }
        else
        {
            Instantiate(cardeff);            
        }
        
    }

    public void ComStart()
    {
        ob.SetActive(true);
        for (int i = 0; i < ComBoxImage.Length; i++)
        {
            ComBoxImage[i].sprite = icon[1];
            ComImage[i].transform.parent.gameObject.SetActive(false);
        }
        ComButton[0].SetActive(false);
        ComButton[1].SetActive(false);
        Comint = 999;
        ComAd = false;
        ComNo = false;
    }
    public void ComOpen(int idx)
    {
        if (ComNo)
        {
            return;
        }
        if (Comint!=idx)
        {
            Comint = idx;
            ComButton[0].SetActive(false);
            ComButton[1].SetActive(false);
            ComNo = true;
            StartCoroutine(ComOpenFunc(Comint));
        }
    }

    IEnumerator ComOpenFunc(int idx)
    {
        
        ComBoxani[idx].Play("Box1");
        yield return new WaitForSecondsRealtime(1);
        ComBoxImage[idx].gameObject.transform.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        
        //¿­¾î



        //yield return new WaitForSecondsRealtime(0.1f);
        yield return Effect2();
        ComSlotOpen(idx);
        ExitOb.SetActive(true);

        if (!ComAd)
        {

            ComButton[0].SetActive(true);
        }
        ComButton[1].SetActive(true);

        ComBoxImage[idx].sprite = icon[0];

    }

    void ComSlotOpen(int Idx)
    {
        int Lv = 0;
        int cardidx = 0;
        float random = Random.Range(0.01f, 100f);
        float RandomCnt1 = 30;
        float RandomCnt2 = 30;
        float RandomCnt3 = 5;
        float RandomCnt4 = 1;
        float RandomCnt5 = 0.1f;
        int Imageicon = 0;
        if (random <= RandomCnt5)
        {
            Lv = 5;
            cardidx = GameInfo.inst.RandomCard(Lv);
            Imageicon = GameInfo.inst.CardsInfo[cardidx].CardIconNum;
            if (ComAd)
            {
            MainSingleton.instance.playerstat.playingCard_Bonus.Add(cardidx);
            }
            else
            {
            MainSingleton.instance.playerstat.playingCard.Add(cardidx);
            }
        }
        else if (random <= RandomCnt4)
        {
            Lv = 4;
            cardidx = GameInfo.inst.RandomCard(Lv);
            Imageicon = GameInfo.inst.CardsInfo[cardidx].CardIconNum;
            if (ComAd)
            {
                MainSingleton.instance.playerstat.playingCard_Bonus.Add(cardidx);
            }
            else
            {
                MainSingleton.instance.playerstat.playingCard.Add(cardidx);
            }
        }
        else if (random <= RandomCnt3)
        {
            Lv = 3;
            cardidx = GameInfo.inst.RandomCard(Lv);
            Imageicon = GameInfo.inst.CardsInfo[cardidx].CardIconNum;
            if (ComAd)
            {
                MainSingleton.instance.playerstat.playingCard_Bonus.Add(cardidx);
            }
            else
            {
                MainSingleton.instance.playerstat.playingCard.Add(cardidx);
            }
        }
        else if (random <= RandomCnt2)
        {
            Lv = 2;
            cardidx = GameInfo.inst.RandomCard(Lv);
            Imageicon = GameInfo.inst.CardsInfo[cardidx].CardIconNum;
            if (ComAd)
            {
                MainSingleton.instance.playerstat.playingCard_Bonus.Add(cardidx);
            }
            else
            {
                MainSingleton.instance.playerstat.playingCard.Add(cardidx);
            }
        }
        else if (random <= RandomCnt1)
        {
            Lv = 1;
            cardidx = GameInfo.inst.RandomCard(Lv);
            Imageicon = GameInfo.inst.CardsInfo[cardidx].CardIconNum;
            if (ComAd)
            {
                MainSingleton.instance.playerstat.playingCard_Bonus.Add(cardidx);
            }
            else
            {
                MainSingleton.instance.playerstat.playingCard.Add(cardidx);
            }
        }
        else
        {
            Lv = 0;
            Imageicon = 143;
            MainSingleton.instance.playerstat.GoldPlus(300);
        }


        ComImage[Idx].sprite=IconManager.inst.Icons[Imageicon];
        ComImage[Idx].transform.parent.gameObject.SetActive(true);

    }
    public void ComAdButton()
    {
        ComNo = false;
        ComAd = true;
        ComButton[0].SetActive(false);
        ComButton[1].SetActive(false);
    }
    public void ComEndButton()
    {
        ob.SetActive(false);
        uimanager.EndGame();
    }
}
