using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextReset : MonoBehaviour
{
    public List<Text> TestList;
    // Start is called before the first frame update
    void Start()
    {
        TextResetFunc();
    }

    public void TextResetFunc()
    {

        for (int i = 0; i < TestList.Count; i++)
        {
            int s = TestList[i].GetComponent<TextIdx>().Idx;

            if (s == 99999)
            {
                TestList[i].text = "";

            }
            else
            {
                TestList[i].text = csvData.GameText(s);

            }
        }



    }
}
