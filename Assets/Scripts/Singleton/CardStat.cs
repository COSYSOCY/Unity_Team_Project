using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStat : MonoBehaviour
{
	public static CardStat inst;

	public float CardStat_HpC()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_HpC;
        }
        return stat;
    }
    public float CardStat_HpP()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_HpP;
        }
        return stat;
    }
    public float CardStat_HpRegen()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_HpRegen;
        }
        return stat;
    }
    public float CardStat_Defence()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_Defence;
        }
        return stat;
    }
    public float CardStat_Speed()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_Speed;
        }
        return stat;
    }
    public float CardStat_DamageP()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_DamageP;
        }
        return stat;
    }
    public int CardStat_BtCnt()
    {
        int stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_BtCnt;
        }
        return stat;
    }
    public float CardStat_Cool()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_Cool;
        }
        return stat;
    }
    public float CardStat_XpPlus()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_XpPlus;
        }
        return stat;
    }

    public float CardStat_GoldPlus()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_GoldPlus;
        }
        return stat;
    }
    public float CardStat_AttackRange()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_AttackRange;
        }
        return stat;
    }
    public float CardStat_Range()
    {
        float stat = 0;
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            stat += GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardStat_Range;
        }
        return stat;
    }



    void Awake()
	{
		inst = this;

	}

}
