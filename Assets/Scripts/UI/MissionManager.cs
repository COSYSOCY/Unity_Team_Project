using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public GameObject MissionPrefab;
    public Transform parent;
    public List<GameObject> missionOb;
    public LobyUIMgr loby;
    public Sprite[] icons;
    public bool IsShow=true;
    public GameObject[] Buttons;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < csvData.MissionGold.Count; i++)
        {
            int infonum=csvData.MissionInfoNum[i];
            int gold = csvData.MissionGold[i];
            int iconnum = csvData.MissionIconNum[i];
            GameObject mission = Instantiate(MissionPrefab, parent);
            mission.SetActive(true);
            mission.GetComponent<Indx>().Idx = i;
            mission.transform.GetChild(3).transform.GetComponent<TextIdx>().Idx = infonum;
            mission.transform.GetChild(0).transform.GetComponent<Image>().sprite = IconManager.inst.Icons[iconnum];
            mission.transform.GetChild(2).transform.GetComponent<Text>().text = "x"+gold.ToString();
            mission.transform.GetChild(3).transform.GetComponent<Text>().text = csvData.GameText(infonum);
            missionOb.Add(mission);
            loby.TestList.Add(mission.transform.GetChild(3).transform.GetComponent<Text>());
        }
        Order();
        Check();
    }
    public void Order()
    {
        for (int i = 0; i < missionOb.Count; i++)
        {
            missionOb[i].transform.SetSiblingIndex(csvData.MissionOrder[i]+1);
        }
    }
    public void show()
    {
        if (!IsShow)
        {
            Buttons[0].GetComponent<Image>().sprite = icons[0];
            Buttons[1].GetComponent<Image>().sprite = icons[1];
            IsShow = true;
            for (int i = 0; i < missionOb.Count; i++)
            {
                missionOb[i].SetActive(true);
            }
        }

    }
    public void noshow()
    {
        if (IsShow)
        {
            Buttons[0].GetComponent<Image>().sprite = icons[1];
            Buttons[1].GetComponent<Image>().sprite = icons[0];
            IsShow = false;
            for (int i = 0; i < missionOb.Count; i++)
            {
                if (GameInfo.inst.Player_Mission[i]==2)
                {
                    missionOb[i].SetActive(false);
                }
                else
                {

                missionOb[i].SetActive(true);
                }
            }
        }

    }
    public void Check()
    {
        for (int i = 0; i < missionOb.Count; i++)
        {
            if (GameInfo.inst.Player_Mission[i] == 1)
            {
                missionOb[i].transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (GameInfo.inst.Player_Mission[i] == 2)
            {
                missionOb[i].transform.GetChild(4).gameObject.SetActive(true);
            }
        }
    }
    public void Func(int idx)
    {
        if (GameInfo.inst.Player_Mission[idx] == 1)
        {
            missionOb[idx].transform.GetChild(5).gameObject.SetActive(false);
            missionOb[idx].transform.GetChild(4).gameObject.SetActive(true);
            GameInfo.inst.Player_Mission[idx] = 2;
            GameInfo.PlayerGold+= csvData.MissionGold[idx];
            loby.LobyGoldAc();

            if (GameInfo.inst.PcTestMode)
            {
                ServerDataSystem.inst.SaveData2asdasdasd();
            }
            else
            {
                ServerDataSystem.inst.SaveData2asdasdasd();
                //ServerDataSystem.inst.ServerSave();
            }
        }
    }

}
