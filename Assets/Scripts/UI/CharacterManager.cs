using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public GameObject CharacterPrefab;
    public Transform parents;
    public List<Sprite> icons;
    public Image CharImage;
    public Image SkillImage;
    public Text CharName;
    public Text CharInfo;



    private void Start()
    {
        for (int i = 0; i < GameInfo.inst.CharacterMax; i++)
        {
            GameObject c = Instantiate(CharacterPrefab, parents);
            var come= c.GetComponent<CharacterBtn>();
            come.CharacterIdx =i;
            come.CharactersNameNum = csvData.CharactersNameNum[i];
            come.CharactersInfoNum = csvData.CharactersInfoNum[i];
            come.CharactersIconNum = csvData.CharactersIconNum[i];
            come.CharactersSkillIconNum = csvData.CharactersSkillIconNum[i];
            come.CharactersBSNum = csvData.CharactersBSNum[i];
            come.CharactersHpMax = csvData.CharactersHpMax[i];
            come.CharactersHpRegen = csvData.CharactersHpRegen[i];
            come.CharactersDefece = csvData.CharactersDefece[i];
            come.CharactersSpeed = csvData.CharactersSpeed[i];
            come.CharactersAtPlus = csvData.CharactersAtPlus[i];
            come.CharactersAtRange = csvData.CharactersAtRange[i];
            come.CharactersBtSpeed = csvData.CharactersBtSpeed[i];
            come.CharactersBtTime = csvData.CharactersBtTime[i];
            come.CharactersBtCnt = csvData.CharactersBtCnt[i];
            come.CharactersBtCool = csvData.CharactersBtCool[i];
            come.CharactersRange = csvData.CharactersRange[i];
            come.CharactersXpPlus = csvData.CharactersXpPlus[i];
            c.GetComponent<Image>().sprite = icons[come.CharactersIconNum];

        }
        int cnt=GameInfo.inst.CharacterIdx;
        //Debug.Log(cnt);
        CharImage.sprite = icons[csvData.CharactersIconNum[cnt]];
        SkillImage.sprite = icons[csvData.CharactersSkillIconNum[cnt]];
        //CharImage.sprite = icons[0];
        //SkillImage.sprite = icons[0];
        CharSetString();

    }

    public void CharSetString()
    {
        int cnt = GameInfo.inst.CharacterIdx;
        CharName.text = csvData.GameText(csvData.CharactersNameNum[cnt]);
        CharInfo.text = csvData.GameText(csvData.CharactersInfoNum[cnt]);

    }

    public void CharacterChange(GameObject g)
    {
        //Debug.Log(g.name);
        int cnt= g.GetComponent<CharacterBtn>().CharacterIdx;
        GameInfo.inst.CharacterIdx = cnt;
        //Debug.Log(cnt);
        CharImage.sprite = icons[csvData.CharactersIconNum[cnt]];
        SkillImage.sprite = icons[csvData.CharactersSkillIconNum[cnt]];
        CharName.text = csvData.GameText(csvData.CharactersNameNum[cnt]);
        CharInfo.text = csvData.GameText(csvData.CharactersIconNum[cnt]);
    }
}
