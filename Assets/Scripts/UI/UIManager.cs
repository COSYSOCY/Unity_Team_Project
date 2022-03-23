using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerInfo playerinfo;
    public Text KillText;
    public Text GoldText;    
    public Text XpText;
    public Text TimeText;
    public Text BgmVolumetext;
    public Text SeVolumetext;
    public Slider BgmVolume;
    public Slider SeVolume;
    public AudioSource BgmAudio;
    public AudioSource SeAudio;
    public GameObject OptionAc;
    public GameObject PlayerHpbar;       
    public bool OptionPanelCheck;
    
       

    public void KillUp()
    {
        playerinfo.Kill++;
        KillText.text ="Kill : "+playerinfo.Kill;
    }
    public void GoldUp(int gold)
    {
        playerinfo.Gold+=gold;
        GoldText.text = "Gold : " + playerinfo.Gold;        
    }
    public void XpSet()
    {
        XpText.text = "Xp : " + playerinfo.Xp + " / " + playerinfo.MaxXp;
    }
    public void TimeCheck()
    {
        TimeText.text = playerinfo.timeM.ToString() + " : " + playerinfo.timeS.ToString("00");
    }    

    public void OptionActive() // ���� ����
    {
        OptionAc.SetActive(true);
        OptionPanelCheck = true;
        if (OptionPanelCheck == true)
        {
            Time.timeScale = 0f;
            PlayerHpbar.SetActive(false);
        }        
    }

    public void OptionXbtn() // ���� �ݱ�
    {
        OptionAc.SetActive(false);
        OptionPanelCheck = false;
        if(OptionPanelCheck == false)
        {
            Time.timeScale = 1f;
            PlayerHpbar.SetActive(true);
        }

    }

    public void SoundVolume() // ���� �����̵� ����
    {
        BgmAudio.volume = BgmVolume.value;
        SeAudio.volume = SeVolume.value;
    }

    public void SoundText() //���� �ؽ�Ʈ
    {
        BgmVolumetext.text = "" + ((int)BgmVolume.value);
        SeVolumetext.text = "" + ((int)SeVolume.value);
    }

    public void DamageTextAc() // ������ǥ�� on off
    {
               
    }    

    public void VFXAc() // ���������Ʈ on Off
    {

    }

    public void GameExit()  //��������
    {
        Application.Quit();
    }

    public void Title() // Ÿ��Ʋ
    {
        SceneManager.LoadScene(0);
    }
}
