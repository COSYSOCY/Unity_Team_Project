using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PullRange : MonoBehaviour
{
    public float Range;  //������ũ���� ���� ���� �����ؼ� ������ �ٲٸ�ɵ�       
    public SphereCollider radius;
    public PlayerInfo playerinfo;

    private void Start()
    {
        //radius = GameObject.FindGameObjectWithTag("Pull").GetComponent<SphereCollider>();       
        radius = GetComponent<SphereCollider>();       

    }

    private void Update()
    {
        radius.radius = playerinfo.item_range;
    }
}
