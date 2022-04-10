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

    public int Cnt;

    public void BoxFunc1()
    {
        Gold = 0;
        Cnt = Random.Range(1,2);
        CheckList.Clear();
        Time.timeScale = 0f;
        BoxImage.sprite = icon[1];
        BoxUiOb1.SetActive(true);
        BoxUiOb2.SetActive(false);
        OpenOb.SetActive(true);
        ExitOb.SetActive(false);
        GoldText.text = "";
    }
    public void OpenFunc()
    {
        StartCoroutine(IBoxFunc(Cnt));
    }
    IEnumerator IBoxFunc(int cnt)
    {
        for (int i = 0; i < Slot.Count; i++)
        {
            Slot[i].SetActive(false);
        }
        for (int i = 0; i < cnt; i++)
        {
            yield return(RandomUp(i));
            
        }
        BoxUiOb2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);

        OpenOb.SetActive(false);
        ExitOb.SetActive(true);
        BoxImage.sprite = icon[0];
        GoldText.text = Gold.ToString();
        for (int i = 0; i < cnt; i++)
        {
            Slot[i].SetActive(true);
        }
        BoxUiOb2.SetActive(false);
    }

    IEnumerator RandomUp(int Idx)
    {
        CheckList.Clear();
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
            if (Lv < LvMax)
            {
                CheckList.Add(MainSingleton.instance.skillmanager.Skill_All_Active[i]);
            }
        }
        if (CheckList.Count > 0)
        {
            int random = Random.Range(0, CheckList.Count);
            GameObject ob = MainSingleton.instance.skillmanager.Skill_All_Active[random];
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
        else
        {
            int RandomGoldAdd = Random.Range(100, 201);
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
        MainSingleton.instance.playerinfo.Gold += Gold;
        BoxUiOb1.SetActive(false);
    }
}
