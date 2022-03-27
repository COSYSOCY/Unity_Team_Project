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
    public Sprite[] icons;
    public Text KillText;
    public Text HpText;
    private void Start()
    {
        if (GameInfo.inst.PlayerSE)
        {
            Soundimage.sprite = icons[1];
        }
    }
    public void KillUp()
    {
        playerinfo.Kill++;
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
        SceneManager.LoadScene("01_Loby");
    }
    public void SoundCheck()
    {
        if (GameInfo.inst.PlayerSE)
        {
            Soundimage.sprite = icons[0];
            GameInfo.inst.PlayerSE = false;
        }
        else
        {
            Soundimage.sprite = icons[1];
            GameInfo.inst.PlayerSE = true;
        }
    }

    public void SettingOn()
    {
        int hp = (int)playerinfo.Hp;
        int Maxhp = (int)playerinfo.MaxHp;
        HpText.text = hp + " / " + Maxhp;
        KillText.text = playerinfo.Kill.ToString();
    }
}
