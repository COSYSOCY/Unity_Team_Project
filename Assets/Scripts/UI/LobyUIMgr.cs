using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LobyUIMgr : MonoBehaviour
{
    public Text UserLevel;
    public Text UserXp;
    public Slider UserXpSlider;

    public Text LobyGoldText;
    public Text LobyPointText;
    public Text LobyEnergyText;
    public Text LobyUserLevelText;
    public List<Text> TestList;

    public Image BGMIcon;
    public Image SEIcon;

    public GameObject SettingObject;
    public CharacterManager charmanager;

    public Color[] colors;

    public GameObject Bgmbuton;
    public GameObject Sebuton;
    public GameObject Dmgbuton;



    private void Start()
    {
        TextReset();
        LobyGoldAc();
        check();
        Time.timeScale = 1f;
        SoundManager.inst.BGMPlay(1);
     }





    public void SettingButton()
    {
        SettingObject.SetActive(true);
    }
    public void DmgCheckButton()
    {
        if (!GameInfo.inst.PlayerDmg)
        {
            //GameInfo.inst.audioSo.Pause();
            GameInfo.inst.PlayerDmg = true;
            Dmgbuton.GetComponent<Image>().color = colors[1];
            Dmgbuton.GetComponentInChildren<TextIdx>().Idx = 528;
            Dmgbuton.GetComponentInChildren<Text>().text = csvData.GameText(528);
        }
        else
        {
            //GameInfo.inst.audioSo.Play();
            GameInfo.inst.PlayerDmg = false;
            Dmgbuton.GetComponent<Image>().color = colors[0];
            Dmgbuton.GetComponentInChildren<TextIdx>().Idx = 527;
            Dmgbuton.GetComponentInChildren<Text>().text = csvData.GameText(527);
        }
    }

    public void LobyGoldAc()
    {
        UserLevel.text = GameInfo.inst.PlayerLevel.ToString();
        UserXp.text = GameInfo.inst.PlayerXp.ToString()+"/"+GameInfo.inst.PlayerXpMax.ToString();
        if (GameInfo.inst.PlayerXp == 0)
        {
            UserXpSlider.value = 0;
        }
        else
        {
        UserXpSlider.value = GameInfo.inst.PlayerXp / GameInfo.inst.PlayerXpMax;
            
        }
        LobyGoldText.text = GameInfo.PlayerGold.ToString("");
        LobyPointText.text = GameInfo.PlayerPoint.ToString("");
        LobyEnergyText.text = GameInfo.inst.PlayerEnergy + "/" + GameInfo.inst.PlayerEnergyMax;
        LobyUserLevelText.text = GameInfo.inst.PlayerLevel.ToString();
    }

    public void BgmButtn()
    {
        if (!GameInfo.inst.PlayerBGM)
        {
            GameInfo.inst.audioSo.Pause();
            GameInfo.inst.PlayerBGM = true;
            GameInfo.inst.audioSo.mute = true;
            BGMIcon.sprite = IconManager.inst.Icons[15];
            Bgmbuton.GetComponent<Image>().color = colors[1];
            Bgmbuton.GetComponentInChildren<TextIdx>().Idx = 528;
            Bgmbuton.GetComponentInChildren<Text>().text = csvData.GameText(528);
        }
        else
        {
            GameInfo.inst.audioSo.Play();
            GameInfo.inst.PlayerBGM = false;
            GameInfo.inst.audioSo.mute = false;
            BGMIcon.sprite = IconManager.inst.Icons[14];
            Bgmbuton.GetComponent<Image>().color = colors[0];
            Bgmbuton.GetComponentInChildren<TextIdx>().Idx = 527;
            Bgmbuton.GetComponentInChildren<Text>().text = csvData.GameText(527);
        }
    }

    public void SeVButtn()
    {
        if (!GameInfo.inst.PlayerSE)
        {
            //GameInfo.inst.audioSo.Pause();
            GameInfo.inst.PlayerSE = true;
            SEIcon.sprite = IconManager.inst.Icons[17];
            Sebuton.GetComponent<Image>().color = colors[1];
            Sebuton.GetComponentInChildren<TextIdx>().Idx = 528;
            Sebuton.GetComponentInChildren<Text>().text = csvData.GameText(528);
        }
        else
        {
            //GameInfo.inst.audioSo.Play();
            GameInfo.inst.PlayerSE = false;
            SEIcon.sprite = IconManager.inst.Icons[16];
            Sebuton.GetComponent<Image>().color = colors[0];
            Sebuton.GetComponentInChildren<TextIdx>().Idx = 527;
            Sebuton.GetComponentInChildren<Text>().text = csvData.GameText(527);
        }
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

    public void check()
    {

        if (GameInfo.inst.PlayerDmg)
        {
            Dmgbuton.GetComponent<Image>().color = colors[1];
            Dmgbuton.GetComponentInChildren<TextIdx>().Idx = 528;
            Dmgbuton.GetComponentInChildren<Text>().text = csvData.GameText(528);
        }
        else
        {

            Dmgbuton.GetComponent<Image>().color = colors[0];
            Dmgbuton.GetComponentInChildren<TextIdx>().Idx = 527;
            Dmgbuton.GetComponentInChildren<Text>().text = csvData.GameText(527);
        }

        if (GameInfo.inst.PlayerBGM)
        {
            BGMIcon.sprite = IconManager.inst.Icons[15];
            Bgmbuton.GetComponent<Image>().color = colors[1];
            Bgmbuton.GetComponentInChildren<TextIdx>().Idx = 528;
            GameInfo.inst.audioSo.mute = true;
            Bgmbuton.GetComponentInChildren<Text>().text = csvData.GameText(528);
        }
        else
        {
            BGMIcon.sprite = IconManager.inst.Icons[14];
            Bgmbuton.GetComponent<Image>().color = colors[0];
            Bgmbuton.GetComponentInChildren<TextIdx>().Idx = 527;
            GameInfo.inst.audioSo.mute = false;
            Bgmbuton.GetComponentInChildren<Text>().text = csvData.GameText(527);
        }

        if (GameInfo.inst.PlayerSE)
        {
            SEIcon.sprite = IconManager.inst.Icons[17];
            Sebuton.GetComponent<Image>().color = colors[1];
            Sebuton.GetComponentInChildren<TextIdx>().Idx = 528;
            Sebuton.GetComponentInChildren<Text>().text = csvData.GameText(528);
        }
        else
        {
            SEIcon.sprite = IconManager.inst.Icons[16];
            Sebuton.GetComponent<Image>().color = colors[0];
            Sebuton.GetComponentInChildren<TextIdx>().Idx = 527;
            Sebuton.GetComponentInChildren<Text>().text = csvData.GameText(527);
        }



    }

}
