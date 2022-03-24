using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LobbyManager_OCM : MonoBehaviour
{
    public GameObject OptionAc;
    public bool ScrollPanelCheck; // OptionPanelCheck
    public Button ExitBtn;

    public Button StartBtn; // 여기선 MapTest - Scroll View의 GameStart1로 이어진다.
    public Button MapTest2Btn; // 여기선 MapTest - Scroll View의 MapTest2Btn으로 이어진다
    public Button MapTest3Btn; // 여기선 MapTest - Scroll View의 MapTest3Btn으로 이어진다


    public PlayerInfo playerinfo;
    public Text LobyGoldText;
    public Text BgmVolumetext;
    public Text SeVolumetext;
    public Slider BgmVolume;
    public Slider SeVolume;
    public AudioSource BgmAudio;
    public AudioSource SeAudio;


    public void gamestart() // 여기선 MapTest - Scroll View의 GameStart1로 이어진다.
    {
        Debug.Log("zx");
        SceneManager.LoadScene("Main");
    }

    public void MapTest2() // 여기선 MapTest - Scroll View의 MapTest2Btn으로 이어진다
    {
        Debug.Log("ab");
        SceneManager.LoadScene("MapTest2");
    }

    public void MapTest3() // 여기선 MapTest - Scroll View의 MapTest3Btn으로 이어진다
    {
        Debug.Log("cd");
        SceneManager.LoadScene("MapTest3");
    }






    public void Title() // 타이틀
    {
        SceneManager.LoadScene(0);
    }

    public void GameExit()  //게임종료
    {
        Application.Quit();
    }

    public void OptionActive() // 설정 열기
    {
        OptionAc.SetActive(true);
        ScrollPanelCheck = true;
        ExitBtn.interactable = false;
        StartBtn.interactable = false;
    }

    public void OptionXbtn() // 설정닫기
    {
        OptionAc.SetActive(false);
        ScrollPanelCheck = false;
        ExitBtn.interactable = true;
        StartBtn.interactable = true;
    }
    public void GoldUp(int gold)
    {
        playerinfo.Gold += gold;
        LobyGoldText.text = "Gold : " + playerinfo.Gold;
    }

    public void SoundVolume() // 사운드 슬라이드 볼륨
    {
        BgmAudio.volume = BgmVolume.value;
        SeAudio.volume = SeVolume.value;
    }

    public void SoundText() //사운드 텍스트
    {
        BgmVolumetext.text = "" + ((int)BgmVolume.value);
        SeVolumetext.text = "" + ((int)SeVolume.value);
    }

}
