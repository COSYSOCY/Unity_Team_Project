using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LobyUIMgr : MonoBehaviour
{
    
    public TextMeshProUGUI UserLevel;
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

    public GameObject Coolbuton;

    public GameObject[] langob;




    private void Start()
    {

        

        TextReset();
        LobyGoldAc();
        check();
        Time.timeScale = 1f;
        SoundManager.inst.BGMPlay(1);
        LangFunc();
       ServerDataSystem.inst.SaveData2();
    }



    public void LangFunc()
    {
        for (int i = 0; i < langob.Length; i++)
        {
            langob[i].SetActive(false);
        }

        if (GameInfo.inst.Language == "English")
        {
            langob[1].SetActive(true);
        }
        else if (GameInfo.inst.Language == "Japan")
        {
            langob[2].SetActive(true);

        }
        else if (GameInfo.inst.Language == "China")
        {
            langob[3].SetActive(true);
        }
        else if (GameInfo.inst.Language == "Germany")
        {
            langob[4].SetActive(true);
        }
        else if (GameInfo.inst.Language == "Spain")
        {
            langob[5].SetActive(true);
        }

        else if (GameInfo.inst.Language == "Portugal")
        {
            langob[6].SetActive(true);
        }
        else if (GameInfo.inst.Language == "Sweden")
        {
            langob[7].SetActive(true);
        }
        else if (GameInfo.inst.Language == "Italy")
        {
            langob[8].SetActive(true);
        }
        else if (GameInfo.inst.Language == "ind")
        {
            langob[9].SetActive(true);
        }
        else if (GameInfo.inst.Language == "ukr")
        {
            langob[10].SetActive(true);
        }
        else if (GameInfo.inst.Language == "rus")
        {
            langob[11].SetActive(true);
        }
        else if (GameInfo.inst.Language == "tha")
        {
            langob[12].SetActive(true);
        }
        else if (GameInfo.inst.Language == "pol")
        {
            langob[13].SetActive(true);
        }
        else if (GameInfo.inst.Language == "fra")
        {
            langob[14].SetActive(true);
        }
        else if (GameInfo.inst.Language == "tur")
        {
            langob[15].SetActive(true);
        }
        else
        {
            langob[0].SetActive(true);
        }
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

    public void CoolCheckButton()
    {
        if (!GameInfo.inst.PlayerCoolUi)
        {
            //GameInfo.inst.audioSo.Pause();
            GameInfo.inst.PlayerCoolUi = true;
            Coolbuton.GetComponent<Image>().color = colors[1];
            Coolbuton.GetComponentInChildren<TextIdx>().Idx = 528;
            Coolbuton.GetComponentInChildren<Text>().text = csvData.GameText(528);
        }
        else
        {
            //GameInfo.inst.audioSo.Play();
            GameInfo.inst.PlayerCoolUi = false;
            Coolbuton.GetComponent<Image>().color = colors[0];
            Coolbuton.GetComponentInChildren<TextIdx>().Idx = 527;
            Coolbuton.GetComponentInChildren<Text>().text = csvData.GameText(527);
        }
    }

    public void LobyGoldAc()
    {
        //UserLevel.text = GameInfo.inst.PlayerLevel.ToString();
        //UserXp.text = GameInfo.inst.PlayerXp.ToString()+"/"+GameInfo.inst.PlayerXpMax.ToString();
        //if (GameInfo.inst.PlayerXp == 0)
        //{
        //    UserXpSlider.value = 0;
        //}
        //else
        //{
        //UserXpSlider.value = GameInfo.inst.PlayerXp / GameInfo.inst.PlayerXpMax;
            
        //}
        LobyGoldText.text = GameInfo.PlayerGold.ToString("");
        //LobyPointText.text = GameInfo.PlayerPoint.ToString("");
       // LobyEnergyText.text = GameInfo.inst.PlayerEnergy + "/" + GameInfo.inst.PlayerEnergyMax;
        //LobyUserLevelText.text = GameInfo.inst.PlayerLevel.ToString();
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
        LangFunc();
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
        if (GameInfo.inst.PlayerCoolUi)
        {

            Coolbuton.GetComponent<Image>().color = colors[1];
            Coolbuton.GetComponentInChildren<TextIdx>().Idx = 528;
            Coolbuton.GetComponentInChildren<Text>().text = csvData.GameText(528);
        }
        else
        {

            Coolbuton.GetComponent<Image>().color = colors[0];
            Coolbuton.GetComponentInChildren<TextIdx>().Idx = 527;
            Coolbuton.GetComponentInChildren<Text>().text = csvData.GameText(527);
        }


    }

}
