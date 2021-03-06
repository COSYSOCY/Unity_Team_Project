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
    public Text[] SkillLvText;
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
        if (playerinfo.Kill%200==0)
        {
            Kill200Func();
        }

        // 100ų 2
        if (GameInfo.inst.Player_Mission[2] == 0 && GameInfo.inst.PlayerKill >= 100)
        {

            GameInfo.inst.MissionGo(2);
        }
        //1000ų 3
        if (GameInfo.inst.Player_Mission[3] == 0 && GameInfo.inst.PlayerKill >= 1000)
        {

            GameInfo.inst.MissionGo(3);
        }


        //10000ų 5
        if (GameInfo.inst.Player_Mission[5] == 0 && GameInfo.inst.PlayerKill >= 10000)
        {

            GameInfo.inst.MissionGo(5);
        }
        //100000ų 32
        if (GameInfo.inst.Player_Mission[32] == 0 && GameInfo.inst.PlayerKill >= 100000)
        {

            GameInfo.inst.MissionGo(32);
        }
        //KillText.text =""+playerinfo.Kill;
    }
    void Kill200Func()
    {
        playerinfo.Bonus_Dmg += (GameInfo.inst.PlayerCardCheck[14] * GameInfo.inst.CardsInfo[14].CardStat_Real1);
        playerinfo.Bonus_HpC += (GameInfo.inst.PlayerCardCheck[15] * GameInfo.inst.CardsInfo[15].CardStat_Real1);

        playerinfo.Bonus_Dmg += (GameInfo.inst.PlayerCardCheck[34] * GameInfo.inst.CardsInfo[34].CardStat_Real1);
        playerinfo.Bonus_Cri += (GameInfo.inst.PlayerCardCheck[35] * GameInfo.inst.CardsInfo[35].CardStat_Real1);

        playerinfo.Bonus_Dmg += (GameInfo.inst.PlayerCardCheck[54] * GameInfo.inst.CardsInfo[54].CardStat_Real1);

        playerinfo.Bonus_HpC += (GameInfo.inst.PlayerCardCheck[55] * GameInfo.inst.CardsInfo[55].CardStat_Real1);

        playerinfo.Bonus_Dmg += (GameInfo.inst.PlayerCardCheck[73] * GameInfo.inst.CardsInfo[73].CardStat_Real1);
        playerinfo.Bonus_SpeedP += (GameInfo.inst.PlayerCardCheck[74] * GameInfo.inst.CardsInfo[74].CardStat_Real1);

        playerinfo.Bonus_Dmg += (GameInfo.inst.PlayerCardCheck[93] * GameInfo.inst.CardsInfo[93].CardStat_Real1);
        playerinfo.Bonus_Cool += (GameInfo.inst.PlayerCardCheck[94] * GameInfo.inst.CardsInfo[94].CardStat_Real1);
        MainSingleton.instance.playerstat.PlayerHpMax();

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

        for (int i = 0; i < MainSingleton.instance.skillmanager.Skill_Active.Count; i++)
        {
            int Lv = MainSingleton.instance.skillmanager.Skill_Active[i].GetComponent<Skill_Info>().Lv;
            int LvMax = MainSingleton.instance.skillmanager.Skill_Active[i].GetComponent<Skill_Info>().LvMax;
            if (Lv>= LvMax)
            {
                SkillLvText[i].text = csvData.GameText(1022);

            }
            else
            {
            SkillLvText[i].text =Lv+"/"+ LvMax;

            }
        }
        for (int i = 0; i < MainSingleton.instance.skillmanager.Skill_Item_Active.Count; i++)
        {
            int Lv = MainSingleton.instance.skillmanager.Skill_Item_Active[i].GetComponent<Skill_ItemInfo>().Lv;
            int LvMax = MainSingleton.instance.skillmanager.Skill_Item_Active[i].GetComponent<Skill_ItemInfo>().LvMax;
            if (Lv >= LvMax)
            {
                SkillLvText[i+6].text = csvData.GameText(1022);

            }
            else
            {
                SkillLvText[i+6].text = Lv + "/" + LvMax;

            }
        }
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
