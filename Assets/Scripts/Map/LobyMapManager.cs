using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobyMapManager : MonoBehaviour
{
    public Text MapName;
    public Text MapInfo;
    public Image MapIcon;
    //public List<Sprite> icons;

    public Image LobyMapIcon;
    public Text LobyMapName;
   // public Text LobyMapInfo;

    public Text LockInfo;

    public int SelectNum;

    public GameObject Loby;
    public GameObject select;
    public GameObject Lock;
    public GameObject selectBtn;

    public Color color1;
    public Color color2;

    void Start()
    {


        int MapIdx = GameInfo.inst.MapIdx;
        SelectNum = MapIdx;
        startmapsetting();
        MapSetting(MapIdx);
    }

    IEnumerator Save30()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
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
    public void MapStart()
    {
        SelectNum = GameInfo.inst.MapIdx;
        MapSetting(GameInfo.inst.MapIdx);
        Lock.SetActive(false);
        selectBtn.SetActive(true);

    }
    public void startmapsetting()
    {
        int MapIdx = GameInfo.inst.MapIdx;
        int NameNum = GameInfo.inst.MapsInfo[MapIdx].MapNameNum;
        int InfoNum = GameInfo.inst.MapsInfo[MapIdx].MapInfoNum;
        int IconNum = GameInfo.inst.MapsInfo[MapIdx].MapIconNum;
        LobyMapIcon.sprite = IconManager.inst.Icons[IconNum];
        LobyMapName.text = csvData.GameText(NameNum);
       // LobyMapInfo.text = csvData.GameText(InfoNum);
        LobyMapName.GetComponent<TextIdx>().Idx = NameNum;
       // LobyMapInfo.GetComponent<TextIdx>().Idx = InfoNum;
    }

    void MapSetting(int i)
    {
        int NameNum = GameInfo.inst.MapsInfo[i].MapNameNum;
        int InfoNum = GameInfo.inst.MapsInfo[i].MapInfoNum;
        int IconNum = GameInfo.inst.MapsInfo[i].MapIconNum;
        int LockInfoNum = GameInfo.inst.MapsInfo[i].MapLockInfoNum;
        MapIcon.sprite= IconManager.inst.Icons[IconNum];
        MapName.text= csvData.GameText(NameNum);
        MapInfo.text= csvData.GameText(InfoNum);
        MapName.GetComponent<TextIdx>().Idx = NameNum;
        MapInfo.GetComponent<TextIdx>().Idx = InfoNum;
        //GameInfo.inst.MapIdx = i;
        if (GameInfo.inst.PlayerMap[SelectNum] == 0)
        {
            Lock.SetActive(true);
            MapIcon.color = color1;
            selectBtn.SetActive(false);
            LockInfo.GetComponent<TextIdx>().Idx = LockInfoNum;
            LockInfo.text=csvData.GameText(LockInfoNum);
        }
        else
        {
            MapIcon.color = color2;
            Lock.SetActive(false);
            selectBtn.SetActive(true);
        }
    }

    public void PlayBtn()
    {
        //SceneManager.LoadScene("Main");
        if (GameInfo.inst.PcTestMode)
        {
            ServerDataSystem.inst.SaveData2asdasdasd();
        }
        else
        {
            ServerDataSystem.inst.SaveData2asdasdasd();
            //ServerDataSystem.inst.ServerSave();
        }
        Loading.LoadScene("Main");
    }
    public void moveButton(int i)
    {
        if (i==0)
        {
            //øﬁ¬ ¿Ãµø
            //GameInfo.inst.MapIdx--;
            SelectNum--;
            if (SelectNum < 0)
            {
                SelectNum = GameInfo.inst.MapsInfo.Count - 1;
            }
        }
        else
        {
            SelectNum++;

            if (SelectNum >= GameInfo.inst.MapsInfo.Count)
            {
                SelectNum = 0;
            }
        }



        int MapIdx = SelectNum;
        MapSetting(MapIdx);
    }
    public void ExitButton()
    {
        //Debug.Log("zz");
    }

    public void SelectBtn()
    {
        if (GameInfo.inst.PlayerMap[SelectNum] != 0)
        {

        GameInfo.inst.MapIdx = SelectNum;
        Loby.SetActive(true);
        select.SetActive(false);
        startmapsetting();
        }
    }

}
