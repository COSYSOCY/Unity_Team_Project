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
                int RandomGoldAdd = Random.Range(100, 201);
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
       // MainSingleton.instance.playerinfo.Gold += Gold;
        MainSingleton.instance.uimanager.GoldUp(Gold);
        BoxUiOb1.SetActive(false);
    }
}
