using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerInfo playerinfo;
    public Text KillText;
    public Text GoldText;
    public Text XpText;
    
    public void KillUp()
    {
        playerinfo.Kill++;
        KillText.text ="Kill : "+playerinfo.Kill;
    }
    public void GoldUp(int gold)
    {
        playerinfo.Gold+=gold;
        GoldText.text = "Gold : " + playerinfo.Kill;
    }
    public void XpSet()
    {
        XpText.text = "Xp : " + playerinfo.Xp + " / " + playerinfo.MaxXp;
    }
}
