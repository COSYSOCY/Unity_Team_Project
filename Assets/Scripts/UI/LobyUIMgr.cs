using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobyUIMgr : MonoBehaviour
{
    public Slider BgmSlider;
    public Slider SeSlider;
    public Toggle DmgToggle;

    public Text LobyGoldText;
    public Text LobyPointText;
    public List<Text> TestList;

    public GameObject SettingObject;
    public CharacterManager charmanager;



    private void Start()
    {
        TextReset();
        LobyGoldAc();
    }



    public void PlayBtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void SettingButton()
    {
        SettingObject.SetActive(true);
    }
    public void DmgCheckButton()
    {
        GameInfo.PlayerDmg = DmgToggle.isOn;
    }

    public void LobyGoldAc()
    {
        LobyGoldText.text = GameInfo.PlayerGold.ToString();
        LobyPointText.text = GameInfo.PlayerPoint.ToString();
    }

    public void BgmVolume()
    {
        GameInfo.PlayerBGM = BgmSlider.value;
        GameInfo.inst.audioSo.volume = BgmSlider.value;
    }

    public void SeVolume()
    {
        GameInfo.PlayerSE = SeSlider.value;
        //SE.volume = SeSlider.value;
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Language(string s)
    {
        GameInfo.inst.Language = s;

        TextReset();
    }
    public void TextReset()
    {

            for (int i = 0; i < TestList.Count; i++)
            {
               int s= TestList[i].GetComponent<TextIdx>().Idx;

            if (s == 99999)
            {
                TestList[i].text = "";

            }
            else
            {
                TestList[i].text = csvData.GameText(s);

            }
            }

        charmanager.CharSetString();


    }


}
