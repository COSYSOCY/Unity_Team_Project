using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PullRange : MonoBehaviour
{
    public float Range;  //인포스크립에 따로 범위 설정해서 증가로 바꾸면될듯       
    public SphereCollider radius;
    public PlayerInfo playerinfo;

    private void Start()
    {
        //radius = GameObject.FindGameObjectWithTag("Pull").GetComponent<SphereCollider>();       
        radius = GetComponent<SphereCollider>();       

    }

    public void Check()
    {
        radius.radius = GameInfo.Range+ playerinfo.item_range + MainSingleton.instance.skillmanager._Range();
    }
    /*
    private void Update()
    {
        radius.radius = playerinfo.item_range+MainSingleton.instance.skillmanager._Range();
    }
    */
}
