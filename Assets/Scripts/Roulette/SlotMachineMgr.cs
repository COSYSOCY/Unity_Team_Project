using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineMgr : MonoBehaviour
{
    public GameObject[] SlotSkillObject;
    public Button[] SlotBtn;

    public Sprite[] SkillSprite;

    [System.Serializable]
    public class DisplayItemSlot
    {
        public List<Image> SlotSprite = new List<Image>();
    }
    public DisplayItemSlot[] DisplayItemSlots;

    public Image DisplayResultImage;

    public List<int> StartList = new List<int>();
    public List<int> ResultIndexList = new List<int>();
    int ItemCnt = 3;

    private void Start()
    {
        for (int i = 0; i < ItemCnt * SlotBtn.Length; i++)
        {
            StartList.Add(i);
        }

        for (int i = 0; i < SlotBtn.Length; i++)
        {
            for (int j = 0; j < ItemCnt; j++)
            {
                SlotBtn[i].interactable = false;

                int randomIndex = Random.Range(0, StartList.Count);
                if(i == 0 && j ==1 || i ==1 && j ==0 || i ==2 && j ==2)
                {
                    ResultIndexList.Add(StartList[randomIndex]);
                }
                DisplayItemSlots[i].SlotSprite[j].sprite = SkillSprite[StartList[randomIndex]];

                if( j== 0)
                {
                    DisplayItemSlots[i].SlotSprite[ItemCnt].sprite = SkillSprite[StartList[randomIndex]];
                }
                StartList.RemoveAt(randomIndex);
            }
        }
        //StartCoroutine(StartSlot1());
        //StartCoroutine(StartSlot2());
        //StartCoroutine(StartSlot3());
        for (int i = 0; i < SlotBtn.Length; i++)
        {
            StartCoroutine(StartSlot(i));
        }

    }

    int[] answer = { 2, 3, 1 };
    IEnumerator StartSlot(int SlotBtnIndex)
    {       
        for (int i = 0; i < (ItemCnt * (6 +SlotBtnIndex * 4)+ answer[SlotBtnIndex]) *2 ; i++)
        {
            SlotSkillObject[SlotBtnIndex].transform.localPosition -= new Vector3(0, 50f, 0);
            if(SlotSkillObject[SlotBtnIndex].transform.localPosition.y < 50f)
            {
                SlotSkillObject[SlotBtnIndex].transform.localPosition += new Vector3(0, 300f, 0);
            }
            yield return null;
        }
        for (int i = 0; i < ItemCnt; i++)
        {
            SlotBtn[i].interactable = true;
        }
    }

    IEnumerator StartSlot2()
    {       
        for (int i = 0; i < (ItemCnt * 10 + 0) * 2; i++)
        {
            SlotSkillObject[1].transform.localPosition -= new Vector3(0, 50f, 0);
            if (SlotSkillObject[1].transform.localPosition.y < 50f)
            {
                SlotSkillObject[1].transform.localPosition += new Vector3(0, 300f, 0);
            }
            yield return null;
        }
        for (int i = 0; i < ItemCnt; i++)
        {
            SlotBtn[i].interactable = true;
        }
    }

    IEnumerator StartSlot3()
    {        
        for (int i = 0; i < (ItemCnt * 14 + 1) * 2; i++)
        {
            SlotSkillObject[2].transform.localPosition -= new Vector3(0, 50f, 0);
            if (SlotSkillObject[2].transform.localPosition.y < 50f)
            {
                SlotSkillObject[2].transform.localPosition += new Vector3(0, 300f, 0);
            }
            yield return null;
        }
        for (int i = 0; i < ItemCnt; i++)
        {
            SlotBtn[i].interactable = true;
        }
    }

    public void ClickBtn (int Index)
    {
        DisplayResultImage.sprite = SkillSprite[ResultIndexList[Index]];
    }
}
