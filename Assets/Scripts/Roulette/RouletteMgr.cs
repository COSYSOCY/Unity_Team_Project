using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteMgr : MonoBehaviour
{
    public GameObject RoulettePlate;
    public GameObject Roulette_Content;
    public Transform Arrow;

    public Sprite[] SkillSprite;
    public Image[] DisplayItemSlot;

    List<int> StartList = new List<int>();
    List<int> ResultIndexList = new List<int>();
    int ItemCnt = 8;

    private void Start()
    {
        for (int i = 0; i < ItemCnt; i++)
        {
            StartList.Add(i);
        }

        for (int i = 0; i < ItemCnt; i++)
        {
            int randomIndex = Random.Range(0, StartList.Count);
            ResultIndexList.Add(StartList[randomIndex]);
            DisplayItemSlot[i].sprite = SkillSprite[StartList[randomIndex]];
            StartList.RemoveAt(randomIndex);
        }
    }


    public void SpinFreeBtn()
    {       
        StartCoroutine(StartRoulette());
    }

    IEnumerator StartRoulette()
    {
        yield return new WaitForSeconds(0.5f);

        float randomSpd = Random.Range(1.0f, 5.0f);
        float rotateSpeed = 100f * randomSpd;


        while(true)
        {
            yield return null;
            if (rotateSpeed <= 0.01f) break;

            rotateSpeed = Mathf.Lerp(rotateSpeed, 0, Time.deltaTime * 2f);
            RoulettePlate.transform.Rotate(0, 0, rotateSpeed);
        }
        yield return new WaitForSeconds(1f);
        Result();
    }

    void Result()
    {
        int closetIndex = -1;
        float closetDis = 500f;
        float currentDis = 0f;

        for (int i = 0; i < ItemCnt; i++)
        {
            currentDis = Vector2.Distance(DisplayItemSlot[i].transform.position, Arrow.position);
            if(closetDis > currentDis)
            {
                closetDis = currentDis;
                closetIndex = i;
            }
        }

        if( closetIndex == -1)
        {
            Debug.Log("Something is Wrong!");
        }
        DisplayItemSlot[ItemCnt].sprite = DisplayItemSlot[closetIndex].sprite;

        Debug.Log(" LV UP Index : " + ResultIndexList[closetIndex]);
    }
}
