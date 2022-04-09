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
        float f = MainSingleton.instance.skillmanager.GoldPlus() + CardStat.inst.CardStat_GoldPlus() + PowerUpInfo.instance._GoldPlus();
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
                int IconNum = GameInfo.inst.CardsInfo[MainSingleton.instance.playerstat.playingCard_Bonus[i]].CardIconNum;
                int Lv = GameInfo.inst.CardsInfo[MainSingleton.instance.playerstat.playingCard_Bonus[i]].CardLv;
                GameObject bt = Instantiate(bootyPrefab, bootyParent);
                bt.GetComponent<bootyInfo>().myCnt.text = "Lv."+ Lv;
                bt.GetComponent<bootyInfo>().myicon.sprite = IconManager.inst.Icons[IconNum];
                bt.GetComponent<bootyInfo>().bonus.SetActive(true);
                GameInfo.inst.PlayerCards.Add(MainSingleton.instance.playerstat.playingCard_Bonus[i]);
                if (GameInfo.inst.CardsInfo[MainSingleton.instance.playerstat.playingCard_Bonus[i]].CardFocus == 1)
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
                int IconNum = GameInfo.inst.CardsInfo[MainSingleton.instance.playerstat.playingCard[i]].CardIconNum;
                int Lv = GameInfo.inst.CardsInfo[MainSingleton.instance.playerstat.playingCard_Bonus[i]].CardLv;
                GameObject bt = Instantiate(bootyPrefab, bootyParent);

                bt.GetComponent<bootyInfo>().myCnt.text = "Lv." + Lv;
                bt.GetComponent<bootyInfo>().myicon.sprite = IconManager.inst.Icons[IconNum];

                GameInfo.inst.PlayerCards.Add(MainSingleton.instance.playerstat.playingCard[i]);
                if (GameInfo.inst.CardsInfo[MainSingleton.instance.playerstat.playingCard[i]].CardFocus == 1)
                {
                    bt.GetComponent<bootyInfo>().Focus.SetActive(true);
                }
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
        IsEnd = true;
        tabOb.SetActive(true);

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
