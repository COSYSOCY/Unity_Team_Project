using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobyUIMgr : MonoBehaviour
{
    //public PlayerInfo playerinfo;
    public Slider Bgmvol;
    public Slider Sevol;
    public AudioSource BGM;
    public AudioSource SE;
    public GameObject Opt;
    public bool OptCheck;
    public Text LobyGoldText;
    public Button ExitBtn;
    public Button StartBtn;
    public Button OptBtn;


    public void OptCheckAc()
    {
        Opt.SetActive(true);
        OptCheck = true;
        if(OptCheck == true)
        {
            ExitBtn.interactable = false;
            StartBtn.interactable = false;
            OptBtn.interactable = false;

        }
    }

    public void OptCheckXbtnAc()
    {
        Opt.SetActive(false);
        OptCheck = false;
        if (OptCheck == false)
        {
            ExitBtn.interactable = true;
            StartBtn.interactable = true;
            OptBtn.interactable = true;
        }
    }        

    public void DmgMarkAc()
    {

    }

    public void LobyGoldAc()
    {
        LobyGoldText.text = "Gold : " + GameInfo.PlayerGold;
    }

    public void BgmVolume()
    {
        BGM.volume = Bgmvol.value;
    }

    public void SeVolume()
    {
        SE.volume = Sevol.value;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
