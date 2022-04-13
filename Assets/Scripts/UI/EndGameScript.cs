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
            //xp�����ֱ�
            yield return new WaitForSecondsRealtime(0.7f);
        }
        if (MainSingleton.instance.playerstat.playingCard_Bonus.Count > 0) // ���ʽ� ����ǰ ī�� �߰�
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
        if (MainSingleton.instance.playerstat.playingCard.Count >0) // ����ǰ ī�� �߰�
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
        GameInfo.inst.PlayerKill += MainSingleton.instance.playerinfo.Kill;
        IsEnd = true;
        tabOb.SetActive(true);
        EndMissionFUnc();
    }

    void EndMissionFUnc()
    {
        // ù �÷��� 0
        if (GameInfo.inst.Player_Mission[0] == 0)
        {
            GameInfo.inst.Player_Mission[0] = 1;
        }
        // 100ų 2
        if (GameInfo.inst.Player_Mission[2]==0 && GameInfo.inst.PlayerKill >=100)
        {
            GameInfo.inst.Player_Mission[2] = 1;
        }
        //1000ų 3
        if (GameInfo.inst.Player_Mission[3] == 0 && GameInfo.inst.PlayerKill >= 1000)
        {
            GameInfo.inst.Player_Mission[3] = 1;
        }
        //1000ų 3
        if (GameInfo.inst.Player_Mission[3] == 0 && GameInfo.inst.PlayerKill >= 1000)
        {
            GameInfo.inst.Player_Mission[3] = 1;
        }
        //100���� �޼� 4
        if (GameInfo.inst.Player_Mission[4] == 0 && MainSingleton.instance.playerinfo.Lv>=100)
        {
            GameInfo.inst.Player_Mission[4] = 1;
        }
        //10000ų 5
        if (GameInfo.inst.Player_Mission[5] == 0 && GameInfo.inst.PlayerKill >= 10000)
        {
            GameInfo.inst.Player_Mission[5] = 1;
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
