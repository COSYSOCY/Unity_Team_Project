using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTimeSystem : MonoBehaviour
{

    public Image Filled;
    public Image SkillImage;
    public Text CoolText;

    public float CoolTime;
    public float CurTime;
    public void NextFunc(float t)
    {
        if (GameInfo.inst.PlayerCoolUi)
        {
            return;
        }
        CoolTime = t;
        CurTime = 0;
        Filled.fillAmount = 0;
        float CText = CoolTime - CurTime;
        CoolText.text = CText.ToString("F1");
        StartCoroutine(Func());
    }
    public void startFUnc(int i, bool b = false)
    {
        if (GameInfo.inst.PlayerCoolUi)
        {
            return;
        }
        if (b)
        {
        //gameObject.SetActive(false);

        }
        else
        {

        Filled.sprite = IconManager.inst.Icons[i];
        SkillImage.sprite = IconManager.inst.Icons[i];
        CurTime = 0;
        Filled.fillAmount = 1;
        CoolText.text = "";

        gameObject.SetActive(true);
        }
    }
    public void NoCool()
    {
        if (GameInfo.inst.PlayerCoolUi)
        {
            return;
        }
        //gameObject.SetActive(false);
        //return;
        CoolText.text = "";
        Filled.fillAmount = 1;
    }
    public void SetCoolint(int i,int Max)
    {
        if (GameInfo.inst.PlayerCoolUi)
        {
            return;
        }
        float CText = Max - i;
        if (i==0)
        {
            Filled.fillAmount = 0;
        }
        else
        {
        float a = i / Max;
        Filled.fillAmount = a;

        }
        CoolText.text = CText.ToString("F0");
    }
    IEnumerator Func()
    {
        if (GameInfo.inst.PlayerCoolUi)
        {
            yield break;
        }
        while (CurTime < CoolTime)
        {
            CurTime +=Time.deltaTime;
            float a = CurTime / CoolTime;
            Filled.fillAmount = a;
            float CText = CoolTime - CurTime;
            CoolText.text = CText.ToString("F1");
            yield return null;
        }
        CoolText.text = "";
    }
}
