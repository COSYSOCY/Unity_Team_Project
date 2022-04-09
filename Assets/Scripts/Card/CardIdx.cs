using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardIdx : MonoBehaviour
{
    public int Idx;
    public int Lv;
    public Image image;
    public Text Lv_Text;
    public GameObject Focus;
    public CardManager cardManager;
    public int num;
    public bool IsPlayerCard;
    public bool IsMixCard;
    public GameObject MixSelect;

    public bool MixOk;

    private void Start()
    {
        cardManager = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManager>();
    }
    public void PlayerCard()
    {
        cardManager.PlayerCardButton(gameObject);
    }
    public void InvenCard()
    {
        cardManager.InvenCardButton(gameObject);
    }
    public void MixCard()
    {
        cardManager.MixCardButton(gameObject);
    }

}
