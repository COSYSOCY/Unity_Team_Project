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
    public List<Sprite> icons;
    void Start()
    {
        int MapIdx = GameInfo.inst.MapIdx;
        MapSetting(MapIdx);
    }

    void MapSetting(int i)
    {
        int NameNum = GameInfo.inst.MapsInfo[i].MapNameNum;
        int InfoNum = GameInfo.inst.MapsInfo[i].MapInfoNum;
        int IconNum = GameInfo.inst.MapsInfo[i].MapIconNum;
        MapIcon.sprite=icons[IconNum];
        MapName.text= csvData.GameText(NameNum);
        MapInfo.text= csvData.GameText(InfoNum);
        MapName.GetComponent<TextIdx>().Idx = NameNum;
        MapInfo.GetComponent<TextIdx>().Idx = InfoNum;
        GameInfo.inst.MapIdx = i;
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void moveButton(int i)
    {
        if (i==0)
        {
            //øﬁ¬ ¿Ãµø
            GameInfo.inst.MapIdx--;
            if (GameInfo.inst.MapIdx <0)
            {
                GameInfo.inst.MapIdx = GameInfo.inst.MapsInfo.Count - 1;
            }
        }
        else
        {
            GameInfo.inst.MapIdx++;
            if (GameInfo.inst.MapIdx >= GameInfo.inst.MapsInfo.Count)
            {
                GameInfo.inst.MapIdx = 0;
            }
        }



        int MapIdx = GameInfo.inst.MapIdx;
        MapSetting(MapIdx);
    }
    public void ExitButton()
    {
        MapSetting(0);
    }

}
