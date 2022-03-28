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

    public GameObject BuyObject;
    public Text BuyGoldText;

    public GameObject CharObject;
    public LobyUIMgr lobyui;
    public GameObject warningOb;
    public Color newcolor;
    public Color newcolor2;



    private void Start()
    {
        GameInfo.inst.CharsInfo.Clear();
        for (int i = 0; i < GameInfo.inst.CharacterMax; i++)
        {
            GameObject c = Instantiate(CharacterPrefab, parents);
            var come= c.GetComponent<CharacterBtn>();
            come.State = GameInfo.inst.CharacterActive[i];
            come.CharacterIdx =i;
            come.CharactersNameNum = csvData.CharactersNameNum[i];
            come.CharactersInfoNum = csvData.CharactersInfoNum[i];
            come.CharactersIconNum = csvData.CharactersIconNum[i];
            come.CharactersSkillIconNum = csvData.CharactersSkillIconNum[i];
            come.CharactersBSNum = csvData.CharactersBSNum[i];
            come.CharactersPrice = csvData.CharactersPrice[i];
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
            come.MainImage.sprite = icons[come.CharactersIconNum];
            GameInfo.inst.CharsInfo.Add(come);
            if (come.State == 0)
            {
                c.SetActive(false);
            }
            else if (come.State==1)
            {
                come.MainImage.color = newcolor;
                come.LockImage.SetActive(true);
            }

        }
        int cnt=GameInfo.inst.CharacterIdx;
        //Debug.Log(cnt);
        CharImage.sprite = icons[csvData.CharactersIconNum[cnt]];
        SkillImage.sprite = icons[csvData.CharactersSkillIconNum[cnt]];

        GameInfo.HpPlus = GameInfo.inst.CharsInfo[cnt].CharactersHpMax;
        GameInfo.HpRegenPlus = GameInfo.inst.CharsInfo[cnt].CharactersHpRegen;
        GameInfo.DefencePlus = GameInfo.inst.CharsInfo[cnt].CharactersDefece;
        GameInfo.inst.MoveSpeedPlus = GameInfo.inst.CharsInfo[cnt].CharactersSpeed;
        GameInfo.DamagePlus = GameInfo.inst.CharsInfo[cnt].CharactersAtPlus;
        GameInfo.Attack_RangePlus = GameInfo.inst.CharsInfo[cnt].CharactersAtRange;
        GameInfo.BulletSpeedPlus = GameInfo.inst.CharsInfo[cnt].CharactersBtSpeed;
        GameInfo.BulletTimePlus = GameInfo.inst.CharsInfo[cnt].CharactersBtTime;
        GameInfo.BulletCntPlus = GameInfo.inst.CharsInfo[cnt].CharactersBtCnt;
        GameInfo.SkillCoolPlus = GameInfo.inst.CharsInfo[cnt].CharactersBtCool;
        GameInfo.Range = GameInfo.inst.CharsInfo[cnt].CharactersRange;
        GameInfo.XpPlus = GameInfo.inst.CharsInfo[cnt].CharactersXpPlus;


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
        if (g.GetComponent<CharacterBtn>().State==1)
        {
            BuyObject.SetActive(true);
            BuyGoldText.text = g.GetComponent<CharacterBtn>().CharactersPrice.ToString();
            CharObject = g;
        }
        else
        {

        int cnt= g.GetComponent<CharacterBtn>().CharacterIdx;
        GameInfo.inst.CharacterIdx = cnt;
        GameInfo.inst.SkillIdx = csvData.CharactersBSNum[cnt];
        //Debug.Log(cnt);
        CharImage.sprite = icons[csvData.CharactersIconNum[cnt]];
        SkillImage.sprite = icons[csvData.CharactersSkillIconNum[cnt]];
        CharName.text = csvData.GameText(csvData.CharactersNameNum[cnt]);
        CharInfo.text = csvData.GameText(csvData.CharactersInfoNum[cnt]);

        GameInfo.HpPlus= g.GetComponent<CharacterBtn>().CharactersHpMax;
        GameInfo.HpRegenPlus= g.GetComponent<CharacterBtn>().CharactersHpRegen;
        GameInfo.DefencePlus= g.GetComponent<CharacterBtn>().CharactersDefece;
        GameInfo.inst.MoveSpeedPlus= g.GetComponent<CharacterBtn>().CharactersSpeed;
        GameInfo.DamagePlus= g.GetComponent<CharacterBtn>().CharactersAtPlus;
        GameInfo.Attack_RangePlus= g.GetComponent<CharacterBtn>().CharactersAtRange;
        GameInfo.BulletSpeedPlus= g.GetComponent<CharacterBtn>().CharactersBtSpeed;
        GameInfo.BulletTimePlus= g.GetComponent<CharacterBtn>().CharactersBtTime;
        GameInfo.BulletCntPlus = g.GetComponent<CharacterBtn>().CharactersBtCnt;
        GameInfo.SkillCoolPlus = g.GetComponent<CharacterBtn>().CharactersBtCool;
        GameInfo.Range = g.GetComponent<CharacterBtn>().CharactersRange;
        GameInfo.XpPlus = g.GetComponent<CharacterBtn>().CharactersXpPlus;


        }
    }

    public void BuyButton()
    {
        if (GameInfo.PlayerGold >= CharObject.GetComponent<CharacterBtn>().CharactersPrice )
        {
            GameInfo.PlayerGold -= CharObject.GetComponent<CharacterBtn>().CharactersPrice;
            lobyui.LobyGoldAc();
            CharObject.GetComponent<CharacterBtn>().MainImage.color = newcolor2;
            CharObject.GetComponent<CharacterBtn>().LockImage.SetActive(false);
            CharObject.GetComponent<CharacterBtn>().State = 2;
            GameInfo.inst.CharacterActive[CharObject.GetComponent<CharacterBtn>().CharacterIdx] = 2;
        }
        else
        {
            warningOb.SetActive(true);
        }
        BuyObject.SetActive(false);
    }

}
