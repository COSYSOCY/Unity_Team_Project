using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelstatus : MonoBehaviour
{

    //테스트용

    public Text curLv;
    public Slider Exp;
    public int curlv;
    public float curExp;
    public float maxExp;

    public void Update()
    {
        Expcc();
    }

    public void Expcc()
    {
        curLv.text = "LV : " + curlv;
        Exp.value = (float)curExp/maxExp;
        if (Exp.value == 1)
        {
            curlv++;
            curExp = 0;            
        }
    }

}
