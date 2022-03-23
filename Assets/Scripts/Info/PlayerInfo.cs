using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int Xp;
    public int Lv;
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
    public int SkillCnt;
    public int SkillItemCnt;
    public int SkillMax;
    public int SkillItemMax;

    private void Start()
    {
        //Hp = 200f;
        //MaxHp = 200f;
        //MaxXp = 1;
        //item_range = 2.5f;
        Hp = MaxHp;
        StartCoroutine(timecheck());
    }

    IEnumerator timecheck()
    {
        
        while (true)
        {
        yield return new WaitForSeconds(1f);
            timeplus++;
            timeS++;
            if (timeS >= 60)
            {
                timeM++;
                timeS = timeS - 60;
            }
            ui.TimeCheck();
            status.tiemtrigger(timeplus);
        }
    }
}
