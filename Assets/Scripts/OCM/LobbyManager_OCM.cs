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

    public Button StartBtn; // ���⼱ MapTest - Scroll View�� GameStart1�� �̾�����.
    public Button MapTest2Btn; // ���⼱ MapTest - Scroll View�� MapTest2Btn���� �̾�����
    public Button MapTest3Btn; // ���⼱ MapTest - Scroll View�� MapTest3Btn���� �̾�����


    public PlayerInfo playerinfo;
    public Text LobyGoldText;
    public Text BgmVolumetext;
    public Text SeVolumetext;
    public Slider BgmVolume;
    public Slider SeVolume;
    public AudioSource BgmAudio;
    public AudioSource SeAudio;


    public void gamestart() // ���⼱ MapTest - Scroll View�� GameStart1�� �̾�����.
    {
        Debug.Log("zx");
        SceneManager.LoadScene("Main");
    }

    public void MapTest2() // ���⼱ MapTest - Scroll View�� MapTest2Btn���� �̾�����
    {
        Debug.Log("ab");
        SceneManager.LoadScene("MapTest2");
    }

    public void MapTest3() // ���⼱ MapTest - Scroll View�� MapTest3Btn���� �̾�����
    {
        Debug.Log("cd");
        SceneManager.LoadScene("MapTest3");
    }






    public void Title() // Ÿ��Ʋ
    {
        SceneManager.LoadScene(0);
    }

    public void GameExit()  //��������
    {
        Application.Quit();
    }

    public void OptionActive() // ���� ����
    {
        OptionAc.SetActive(true);
        ScrollPanelCheck = true;
        ExitBtn.interactable = false;
        StartBtn.interactable = false;
    }

    public void OptionXbtn() // �����ݱ�
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

}
