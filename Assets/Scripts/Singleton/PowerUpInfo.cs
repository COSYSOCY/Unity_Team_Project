using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInfo : MonoBehaviour
{
    public static PowerUpInfo instance = null;
    private void Awake()
    {
        instance = this;
    }
    public int PowerUp_Hp;
    public int PowerUp_HpRegen;
    public int PowerUp_Defence;
    public int PowerUp_Speed;
    public int PowerUp_Dmg;
    public int PowerUp_Cri;
    public int PowerUp_Cool;
    public int PowerUp_XpPlus;
    public int PowerUp_GoldPlus;
    public int PowerUp_AtRange;
    public int PowerUp_BtSpeed;
    public int PowerUp_BtTime;
    public int PowerUp_Range;
    public int PowerUp_Re;
    public int PowerUp_BtCnt;

    public float _Hp()
    {
        int i = PowerUp_Hp;
        
        float Up = 3;

        return Up*i;
    }
    public float _HpRegen()
    {
        int i = PowerUp_HpRegen;

        float Up = 0.05f;

        return Up * i;
    }
    public float _Defence()
    {
        int i = PowerUp_Defence;

        float Up = 0.3f;

        return Up * i;
    }
    public float _Speed()
    {
        int i = PowerUp_Speed;

        float Up = 2;

        return Up * i;
    }
    public float _Dmg()
    {
        int i = PowerUp_Dmg;

        float Up = 2;

        return Up * i;
    }
    public float _Cri()
    {
        int i = PowerUp_Cri;

        float Up = 1;

        return Up * i;
    }
    public float _Cool()
    {
        int i = PowerUp_Cool;

        float Up = 1;

        return Up * i;
    }
    public float _XpPlus()
    {
        int i = PowerUp_XpPlus;

        float Up = 1.5f;

        return Up * i;
    }
    public float _GoldPlus()
    {
        int i = PowerUp_GoldPlus;

        float Up = 0.5f;

        return Up * i;
    }
    public float _AtRange()
    {
        int i = PowerUp_AtRange;

        float Up = 1;

        return Up * i;
    }
    public float _BtSpeed()
    {
        int i = PowerUp_BtSpeed;

        float Up = 1;

        return Up * i;
    }
    public float _BtTime()
    {
        int i = PowerUp_BtTime;

        float Up = 1;

        return Up * i;
    }
    public float _Range()
    {
        int i = PowerUp_Range;

        float Up = 0.5f;

        return Up * i;
    }

    public int _Re()
    {
        int i = 0;
        if (PowerUp_Re >=1)
        {
            i = 1;
        }
        return i;
    }
    public int _BtCnt()
    {
        int i = PowerUp_BtCnt;


        return i;
    }

}
