using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Player1, Player2,Player3
}
public class DataMGR : MonoBehaviour//∞£¥‹«— ΩÃ±€≈Ê ∆–≈œ
{

    public static DataMGR instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }
    public Character currentChara;
}
