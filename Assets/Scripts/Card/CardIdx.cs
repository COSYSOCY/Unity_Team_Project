using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardIdx : MonoBehaviour
{
    public int Idx;
    public Image image;
    public GameObject Focus;
    public CardManager cardManager;
    public int num;
    public bool IsPlayerCard;

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

}
