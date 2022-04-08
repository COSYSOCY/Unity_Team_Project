using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerInfo playerinfo;
    //public Text KillText;
    public Text GoldText;
    //public Text XpText;
    public Slider Xpbar;
    public Text TimeText;
    public Image Soundimage;
    public Image Soundimage2;
    public Sprite[] icons;
    public Text KillText;
    public Text HpText;
    public Text LevelText;
    public GameObject EndGameOb;
    private void Start()
    {
        //if (GameInfo.inst.PlayerSE)
        //{
        //    Soundimage.sprite = icons[1];
        //}
        if (GameInfo.inst.PlayerBGM)
        {
            Soundimage.sprite = icons[1];
            
        }
        if (GameInfo.inst.PlayerSE)
        {
            Soundimage2.sprite = icons[3];

        }
        
    }
    public void KillUp()
    {
        playerinfo.Kill++;
        if (MainSingleton.instance.playerstat.SkillItemactive[16] >= 1)
        {
            MainSingleton.instance.item16.Func();
        }
        if (MainSingleton.instance.playerstat.SkillItemactive[31] >= 1)
        {
            MainSingleton.instance.item31.Func();
        }
        //KillText.text =""+playerinfo.Kill;
    }
    public void GoldUp(int gold)
    {
        playerinfo.Gold+=gold;
        GoldText.text = "" + playerinfo.Gold;
    }
    public void XpSet()
    {
        //Xpbar.minValue = playerinfo.Xp;
        Xpbar.value = playerinfo.Xp;
        Xpbar.maxValue = playerinfo.MaxXp;
        //XpText.text = "Xp : " + playerinfo.Xp + " / " + playerinfo.MaxXp;
    }
    public void TimeCheck()
    {
        TimeText.text = playerinfo.timeM.ToString() + " : " + playerinfo.timeS.ToString("00");
    }
    public void OptionButton(float f)
    {
        Time.timeScale = f;
    }
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("01_Loby_Main");
    }
    public void SoundCheck()
    {
        //if (GameInfo.inst.PlayerSE)
        //{
        //    Soundimage.sprite = icons[0];
        //    GameInfo.inst.PlayerSE = false;
        //}
        //else
        //{
        //    Soundimage.sprite = icons[1];
        //    GameInfo.inst.PlayerSE = true;
        //}
        if (GameInfo.inst.PlayerBGM)
        {
            Soundimage.sprite = icons[0];
            GameInfo.inst.PlayerBGM = false;
            GameInfo.inst.audioSo.mute = false;
        }
        else
        {
            Soundimage.sprite = icons[1];
            GameInfo.inst.PlayerBGM = true;
            GameInfo.inst.audioSo.mute = true;
            GameInfo.inst.audioSo.Stop();
        }

    }
    public void SoundCheck2()
    {
        if (GameInfo.inst.PlayerSE)
        {
            Soundimage2.sprite = icons[2];
            GameInfo.inst.PlayerSE = false;

        }
        else
        {
            Soundimage2.sprite = icons[3];
            GameInfo.inst.PlayerSE = true;
        }
    }
    public void Leveltext()
    {
        LevelText.text = "Lv." + playerinfo.Lv;
    }
    public void SettingOn()
    {
        int hp = (int)playerinfo.Hp;
        int Maxhp = (int)playerinfo.MaxHp;
        HpText.text = hp + " / " + Maxhp;
        KillText.text = playerinfo.Kill.ToString();
    }
    public void ReYes()
    {

            //GameInfo.PlayerPoint -= 5;
            StartCoroutine(MainSingleton.instance.playerstat.AdIn());

    }
    public void ReYes2()
    {

        //GameInfo.PlayerPoint -= 5;
        StartCoroutine(MainSingleton.instance.playerstat.AdIn());

    }
    public void EndGame()
    {
        EndGameOb.SetActive(true);
    }
}
