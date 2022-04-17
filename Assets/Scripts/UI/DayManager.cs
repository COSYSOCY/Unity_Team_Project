using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public bool[] IsButtonDay7=new bool[7];
    public GameObject[] Day7Focus;
    public GameObject[] Day7Check;
    public Text Day7Text;
    public LobyUIMgr loby;
    public int[] Day7GoldCost;


    public bool[] IsButtonDay30 = new bool[30];
    public GameObject[] Day30Ob;
    public Text Day30Text;

    public int[] Day30GoldCost;

    void Start()
    {
        Start7();
        Start30();

    }
    #region 7µ¥ÀÌ
    
    void Start7()
    {
        if (GameInfo.inst.DayCom2Int == 0)
        {
            Day7Reset();
            //Day7Check[0].SetActive(true);
        }
        else if (GameInfo.inst.DayCom2Int >= 7)
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - GameInfo.inst.Daycom2;
            if (dt.Day >= 1)
            {
                GameInfo.inst.DayCom2Int = 0;
                Day7Reset();
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    Day7Check[i].SetActive(false);
                    Day7Focus[i].SetActive(false);
                }
                StartCoroutine(TimeFunc());
            }
        }
        else
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - GameInfo.inst.Daycom2;
            if (dt.Day == GameInfo.inst.Daycom2.Day && ts.Days == 0)
            {
                Day7Ok(GameInfo.inst.DayCom2Int);

            }
            else if (ts.Days >= 2)
            {
                Day7Reset();
            }
            else
            {









                for (int i = 0; i < GameInfo.inst.DayCom2Int; i++)
                {
                    Day7Check[i].SetActive(true);
                }
                StartCoroutine(TimeFunc());
            }

        }
    }
    void Day7Reset()
    {
        for (int i = 0; i < Day7Check.Length; i++)
        {
            Day7Check[i].SetActive(false);
            Day7Focus[i].SetActive(false);

        }
        IsButtonDay7[0] = true;
        Day7Focus[0].SetActive(true);
        Day7Text.text = csvData.GameText(1141);
        Day7Text.GetComponent<TextIdx>().Idx = 1141;
    }
    void Day7Ok(int Idx)
    {
        if (GameInfo.inst.DayCom2Int >= 7)
        {
            GameInfo.inst.DayCom2Int = 0;
            Day7Reset();
        }
        else
        {

        Day7Func1(Idx);
        IsButtonDay7[Idx] = true;
        Day7Text.text = csvData.GameText(1141);
            Day7Text.GetComponent<TextIdx>().Idx = 1141;
        }
    }

    IEnumerator TimeFunc()
    {
        while (true)
        {
        yield return new WaitForSeconds(1);
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - GameInfo.inst.Daycom2;
            if (dt.Day == GameInfo.inst.Daycom2.Day && ts.Days==0)
            {
                Day7Ok(GameInfo.inst.DayCom2Int);
                break;
                
            }

        DateTime dt2 = DateTime.Now;
        TimeSpan ts2 = GameInfo.inst.Daycom2 - dt2;
        string H = ts2.Hours.ToString();
        string M = ts2.Minutes.ToString();
        //Day7Text.text = csvData.GameText(1142) + H + csvData.GameText(1139) + M + csvData.GameText(1140);
        Day7Text.text = csvData.GameText(1143);
            Day7Text.GetComponent<TextIdx>().Idx = 1143;
        }
    }


    void Day7Func1(int idx)
    {
        for (int i = 0; i < GameInfo.inst.DayCom2Int; i++)
        {
            Day7Check[i].SetActive(true);
        }
        IsButtonDay7[idx] = true;
            Day7Check[idx].SetActive(false);
        Day7Focus[idx].SetActive(true);
    }

    public void Day7Button(int idx)
    {
        if (GameInfo.inst.DayCom2Int>=7)
        {
            return;
        }
        if (IsButtonDay7[idx])
        {
            Day7Good(GameInfo.inst.DayCom2Int);
            IsButtonDay7[idx] = false;
            Day7Check[idx].SetActive(true);
            Day7Focus[idx].SetActive(false);
            //GameInfo.inst.Daycom2 = DateTime.Now;
            GameInfo.inst.Daycom2 = DateTime.Now.AddDays(1);

            GameInfo.inst.DayCom2Int++;

            StartCoroutine(TimeFunc());
            if (GameInfo.inst.PcTestMode)
            {
                ServerDataSystem.inst.SaveData2asdasdasd();
            }
            else
            {
                ServerDataSystem.inst.SaveData2asdasdasd();
                //ServerDataSystem.inst.ServerSave();
            }
        }
    }

    public void Day7Good(int idx)
    {
        GameInfo.PlayerGold += Day7GoldCost[idx];
        loby.LobyGoldAc();
        
    }
    #endregion

    void Start30()
    {
        for (int i = 0; i < Day30GoldCost.Length; i++)
        {
            Day30Ob[i].transform.GetChild(4).transform.GetComponent<TextMeshProUGUI>().text = Day30GoldCost[i].ToString();
            Day30Ob[i].transform.GetChild(3).transform.GetComponent<TextMeshProUGUI>().text = (i+1).ToString();
        }
        if (GameInfo.inst.DayCom3Int == 0)
        {
            Day30Reset();
            //Day7Check[0].SetActive(true);
        }
        else if (GameInfo.inst.DayCom3Int >= 30)
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - GameInfo.inst.Daycom2;
            if (dt.Day >= 1)
            {
                GameInfo.inst.DayCom3Int = 0;
                Day30Reset();
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    Day30Ob[i].transform.GetChild(0).gameObject.SetActive(false);
                    Day30Ob[i].transform.GetChild(2).gameObject.SetActive(false);
                }
                StartCoroutine(TimeFunc30());
            }
        }
        else
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - GameInfo.inst.Daycom3;

            if (ts.TotalSeconds>0)
            {

                Day30Ok(GameInfo.inst.DayCom3Int);

            }
            else
            {
                for (int i = 0; i < GameInfo.inst.DayCom3Int; i++)
                {
                  Day30Ob[i].transform.GetChild(2).gameObject.SetActive(true);
                    //Debug.Log("³Ê¶ß´Ï?");
                }
                StartCoroutine(TimeFunc30());
            }

        }
    }
    void Day30Reset()
    {
        for (int i = 0; i < 30; i++)
        {
            Day30Ob[i].transform.GetChild(0).gameObject.SetActive(false);
            Day30Ob[i].transform.GetChild(2).gameObject.SetActive(false);


        }
        IsButtonDay30[0] = true;
        Day30Ob[0].transform.GetChild(0).gameObject.SetActive(true);
        Day30Text.text = csvData.GameText(1141);
        Day30Text.GetComponent<TextIdx>().Idx = 1141;
    }
    void Day30Ok(int Idx)
    {
        if (GameInfo.inst.DayCom3Int >= 30)
        {
            GameInfo.inst.DayCom3Int = 0;
            Day30Reset();
        }
        else
        {

        Day30Func1(Idx);
        IsButtonDay30[Idx] = true;
        Day30Text.text = csvData.GameText(1141);
            Day30Text.GetComponent<TextIdx>().Idx = 1141;
        }
    }

    IEnumerator TimeFunc30()
    {
        while (true)
        {
        yield return new WaitForSeconds(1);
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - GameInfo.inst.Daycom3;
            if (ts.TotalSeconds > 0)
            {
                Day30Ok(GameInfo.inst.DayCom3Int);
                break;
                
            }

        DateTime dt2 = DateTime.Now;
        TimeSpan ts2 = GameInfo.inst.Daycom3 - dt2;
        string H = ts2.Hours.ToString();
        string M = ts2.Minutes.ToString();
        Day30Text.text = csvData.GameText(1142) + H + csvData.GameText(1139) + M + csvData.GameText(1140);
        
        }
    }


    void Day30Func1(int idx)
    {
        for (int i = 0; i < GameInfo.inst.DayCom3Int; i++)
        {
            Day30Ob[i].transform.GetChild(2).gameObject.SetActive(true);
        }
        IsButtonDay7[idx] = true;
        Day30Ob[idx].transform.GetChild(2).gameObject.SetActive(false);
        Day30Ob[idx].transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Day30Button(int idx)
    {
        if (GameInfo.inst.DayCom3Int>=30)
        {
            return;
        }
        if (IsButtonDay30[idx])
        {
            Day30Good(GameInfo.inst.DayCom3Int);
            IsButtonDay30[idx] = false;
            Day30Ob[idx].transform.GetChild(2).gameObject.SetActive(true);
            Day30Ob[idx].transform.GetChild(0).gameObject.SetActive(false);
            //GameInfo.inst.Daycom2 = DateTime.Now;
            GameInfo.inst.Daycom3 = DateTime.Now.AddDays(1);
  
            GameInfo.inst.DayCom3Int++;

            StartCoroutine(TimeFunc30());
            if (GameInfo.inst.PcTestMode)
            {
                ServerDataSystem.inst.SaveData2asdasdasd();
            }
            else
            {
                ServerDataSystem.inst.SaveData2asdasdasd();
                //ServerDataSystem.inst.ServerSave();
            }
        }
    }

    public void Day30Good(int idx)
    {
        GameInfo.PlayerGold += Day30GoldCost[idx];
        loby.LobyGoldAc();

    }
}
