using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSingleton : MonoBehaviour
{
    public static MainSingleton instance = null;
    public PlayerInfo playerinfo;
    public GameObject Player;
    public Transform ItemCreateTranform;
    public ItemSystem dropSystem;
    public UIManager uimanager;
    public PlayerStatus playerstat;
    private void Awake()
    {
            instance = this;
    }
}
