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
        int xp = Random.Range(100,1000);
        int gold = MainSingleton.instance.playerinfo.Gold;

        // 임시
        gold += Random.Range(100, 1000);
        // 
        yield return new WaitForSecondsRealtime(0.5f);
        if (xp > 0)
        {
            GameObject bt = Instantiate(bootyPrefab, bootyParent);
            bt.GetComponentInChildren<Text>().text = "X" + xp;
            bt.GetComponent<Image>().sprite = IconManager.inst.Icons[1];
            //xp더해주기
            yield return new WaitForSecondsRealtime(0.7f);
        }
        if (gold > 0)
        {
            GameObject bt = Instantiate(bootyPrefab, bootyParent);
            bt.GetComponentInChildren<Text>().text = "X" + gold;
            bt.GetComponent<Image>().sprite = IconManager.inst.Icons[3];
            GameInfo.PlayerGold += gold;
            yield return new WaitForSecondsRealtime(0.7f);
        }
        if (MainSingleton.instance.playerstat.playingCard.Count >0) // 전리품 카드 추가
        {
            for (int i = 0; i < MainSingleton.instance.playerstat.playingCard.Count; i++)
            {
                int IconNum = GameInfo.inst.CardsInfo[MainSingleton.instance.playerstat.playingCard[i]].CardIconNum;

                GameObject bt = Instantiate(bootyPrefab, bootyParent);
                bt.GetComponentInChildren<Text>().text = "";
                bt.GetComponent<Image>().sprite = IconManager.inst.Icons[IconNum];

                GameInfo.inst.PlayerCards.Add(MainSingleton.instance.playerstat.playingCard[i]);
                yield return new WaitForSecondsRealtime(0.7f);
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
                SceneManager.LoadScene("01_Loby");
            }
        }
    }
}
