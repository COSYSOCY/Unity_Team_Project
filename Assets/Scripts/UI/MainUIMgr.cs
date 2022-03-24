using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIMgr : MonoBehaviour
{
    
    public Slider Bgmvol;
    public Slider Sevol;
    public AudioSource BGM;
    public AudioSource SE;
    public GameObject Opt;
    public bool OptCheck;    
    public Button ExitBtn;
    public Button StartBtn;
    public Button OptBtn;
    public GameObject hpbar;
    public GameInfo gameInfo;
    public Text LobyGoldText;


    public void Awake()
    {
        gameInfo = GameObject.Find("Singleton").GetComponent<GameInfo>();
    }

    public void OptCheckAc()
    {
        Opt.SetActive(true);
        OptCheck = true;
        if(OptCheck == true)
        {
            hpbar.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void OptCheckXbtnAc()
    {
        Opt.SetActive(false);
        OptCheck = false;    
        if(OptCheck == false)
        {
            hpbar.SetActive(true);
            Time.timeScale = 1;
        }
    }        

    public void LobyGoldAc()
    {
        LobyGoldText.text = "Gold : " + GameInfo.PlayerGold;
    }


    public void DmgMarkAc()
    {
        GameInfo.PlayerVFX = false;
    }    

    public void BgmVolume()
    {
        GameInfo.PlayerBGM = BGM.volume;
        BGM.volume = Bgmvol.value;        
    }

    public void SeVolume()
    {
        GameInfo.PlayerSE = SE.volume;
        SE.volume = Sevol.value;        
    }

    public void LobyAc()
    {
        SceneManager.LoadScene(0);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
