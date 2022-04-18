using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    public GameObject tabOb;
    public GameObject bootyPrefab;
    public Transform bootyParent;
    public bool IsEnd;
    void Start()
    {
        StartCoroutine(startFunc1());
    }

    IEnumerator startFunc1()
    {
        //int xp = Random.Range(100,1000);
        int gold = MainSingleton.instance.playerinfo.Gold;
        float AddGold;
        float f = MainSingleton.instance.skillmanager.GoldPlus() + CardStat.inst.CardStat_GoldPlus() + PowerUpInfo.instance._GoldPlus()+MainSingleton.instance.playerinfo.Bonus_GoldPuls;
        


        if (MainSingleton.instance.playerinfo.Clear)
        {
            float Pick2 = 15f;
            float Pick3 = 2f;

            int cardidx = 0;
            int CardLv = 0;
            float Ran = Random.Range(0.01f, 100f);
            if (Ran <= Pick3)
            {
                CardLv = 3;
            }
            else if (Ran <= Pick2)
            {
                CardLv = 2;
            }
            else
            {
                CardLv = 1;
            }
            cardidx = GameInfo.inst.RandomCard(CardLv);
            MainSingleton.instance.playerstat.playingCard.Add(cardidx);
            gold += Random.Range(100, 300);


            if (GameInfo.inst.Player_Mission[28] == 0&&GameInfo.inst.MapIdx==0)
            {
                GameInfo.inst.MissionGo(28);
            }
            else if (GameInfo.inst.Player_Mission[29] == 0 && GameInfo.inst.MapIdx == 1)
            {
                GameInfo.inst.MissionGo(29);
            }
            else if (GameInfo.inst.Player_Mission[30] == 0 && GameInfo.inst.MapIdx == 2)
            {
                GameInfo.inst.MissionGo(30);
            }
            else if (GameInfo.inst.Player_Mission[31] == 0 && GameInfo.inst.MapIdx ==3)
            {
                GameInfo.inst.MissionGo(31);
            }
        }
        AddGold = gold;
        AddGold = AddGold * (f * 0.01f);
        
        // 
        yield return new WaitForSecondsRealtime(0.5f);
        
        if (gold > 0)
        {
            GameObject bt = Instantiate(bootyPrefab, bootyParent);
            bt.GetComponent<bootyInfo>().myCnt.text = "X" + gold;
            bt.GetComponent<bootyInfo>().myicon.sprite = IconManager.inst.Icons[3];
            GameInfo.PlayerGold += gold;
            yield return new WaitForSecondsRealtime(0.7f);
        }
        if (AddGold > 0)
        {
            GameObject bt = Instantiate(bootyPrefab, bootyParent);
            bt.GetComponent<bootyInfo>().myCnt.text = "X" + (int)AddGold;
            bt.GetComponent<bootyInfo>().myicon.sprite = IconManager.inst.Icons[3];
            bt.GetComponent<bootyInfo>().bonus.SetActive(true);
            GameInfo.PlayerGold += (int)AddGold;
            //xp더해주기
            yield return new WaitForSecondsRealtime(0.7f);
        }
        if (MainSingleton.instance.playerstat.playingCard_Bonus.Count > 0) // 보너스 전리품 카드 추가
        {
            for (int i = 0; i < MainSingleton.instance.playerstat.playingCard_Bonus.Count; i++)
            {
                int cardidx = MainSingleton.instance.playerstat.playingCard_Bonus[i];
                int IconNum = GameInfo.inst.CardsInfo[cardidx].CardIconNum;
                int Lv = GameInfo.inst.CardsInfo[cardidx].CardLv;
                GameObject bt = Instantiate(bootyPrefab, bootyParent);
                bt.GetComponent<bootyInfo>().myCnt.text = "Lv."+ Lv;
                bt.GetComponent<bootyInfo>().myicon.sprite = IconManager.inst.Icons[IconNum];
                bt.GetComponent<bootyInfo>().bonus.SetActive(true);
                GameInfo.inst.PlayerCards.Add(cardidx);
                if (GameInfo.inst.CardsInfo[cardidx].CardFocus == 1)
                {
                    bt.GetComponent<bootyInfo>().Focus.SetActive(true);
                }
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
        if (MainSingleton.instance.playerstat.playingCard.Count >0) // 전리품 카드 추가
        {
            for (int i = 0; i < MainSingleton.instance.playerstat.playingCard.Count; i++)
            {
                int cardidx = MainSingleton.instance.playerstat.playingCard[i];
                int IconNum = GameInfo.inst.CardsInfo[cardidx].CardIconNum;
                int Lv = GameInfo.inst.CardsInfo[cardidx].CardLv;
                GameObject bt = Instantiate(bootyPrefab, bootyParent);

                bt.GetComponent<bootyInfo>().myCnt.text = "Lv." + Lv;
                bt.GetComponent<bootyInfo>().myicon.sprite = IconManager.inst.Icons[IconNum];

                GameInfo.inst.PlayerCards.Add(cardidx);
                if (GameInfo.inst.CardsInfo[cardidx].CardFocus == 1)
                {
                    bt.GetComponent<bootyInfo>().Focus.SetActive(true);
                }
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
        GameInfo.inst.PlayerKill += MainSingleton.instance.playerinfo.Kill;
        IsEnd = true;
        tabOb.SetActive(true);
        EndMissionFUnc();
    }

    void EndMissionFUnc()
    {
        // 첫 플레이 0
        if (GameInfo.inst.Player_Mission[0] == 0)
        {
            GameInfo.inst.MissionGo(0);
        }


    }

    private void Update()
    {
        if (IsEnd)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("01_Loby_Main");
            }
        }
    }
}
