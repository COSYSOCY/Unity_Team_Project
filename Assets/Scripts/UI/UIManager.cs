using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerInfo playerinfo;
    public Text KillText;
    public Text GoldText;
    //public Text XpText;
    public Slider Xpbar;
    public Text TimeText;
    
    public void KillUp()
    {
        playerinfo.Kill++;
        KillText.text =""+playerinfo.Kill;
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
}
