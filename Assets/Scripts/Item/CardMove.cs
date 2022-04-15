using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardMove : MonoBehaviour
{
    public float cardtime;
    public GameObject popaobj;
    void Start()
    {
        transform.DOMove(new Vector3(0, 25, 0), cardtime);
        if(cardtime > 1f)
        {
            Instantiate(popaobj);
        }

    }
}
