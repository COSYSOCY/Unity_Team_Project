using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int Xp;
    public int Lv;
    public float Speed;
    public float Hp;
    public float MaxHp;
    public int MaxXp;
    public int Kill;
    public int Gold;
    public float item_range;
    public int timeM;
    public int timeS;
    public int timeplus;
    public UIManager ui;
    public PlayerStatus status;
    public SkillManager manager;
    public int SkillCnt;
    public int SkillItemCnt;
    public int SkillMax;
    public int SkillItemMax;
    public int ADRe = 0;





    public int Bonus_BtCnt = 0;
    public float Bonus_Range = 0;
    public float Bonus_XpPuls = 0;
    public float Bonus_Cri = 0;
    public float Bonus_Dmg = 0f;
    public float Bonus_AtRange = 0f;
    public float Bonus_BtSpeed = 0f;
    public float Bonus_BtTime = 0f;
    public float Bonus_Defence = 0f;

    private void Start()
    {
        //Hp = 200f;
        //MaxHp = 200f;
        //MaxXp = 1;
        //item_range = 2.5f;
        
        //StartCoroutine(timecheck());
    }

    public void PowerUp()
    {
        status.ReCnt += PowerUpInfo.instance._Re();
    }
    //IEnumerator timecheck()
    //{
    //    while (true)
    //    {
    //    yield return new WaitForSeconds(1f);
    //        timeplus++;
    //        timeS++;
    //        if (timeS >= 60)
    //        {
    //            timeM++;
    //            timeS = timeS - 60;
    //        }
    //        ui.TimeCheck();
    //        status.tiemtrigger(timeplus);
    //    }
    //}

    public float _Speed()
    {
        float s = GameInfo.inst.MoveSpeedPlus+Speed;
        float d = manager.Speed() + CardStat.inst.CardStat_Speed()+ PowerUpInfo.instance._Speed();
        s = s + ((d * 0.01f) * s);
        return s;
    }
}
