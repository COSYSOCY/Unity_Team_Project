using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public GameObject CharacterPrefab;
    public Transform parents;
    //public List<Sprite> icons;
    public RawImage RawCharaImage; //로우이미지
    public Image CharImage;
    public Image SkillImage;
    public Image Skill2Image;
    public Text CharSkillName1;
    public Text CharSkillName2;
    public Text mainName;
    //public Text CharInfo;

    public GameObject CharObject;
    public LobyUIMgr lobyui;
    public GameObject warningOb;
    public Color newcolor;
    public Color newcolor2;
    public GameObject InfoOb;
    public GameObject ClickOb;

    public GameObject EquipBtn;
    public GameObject BuyBtn;
    public Image InfoCharImage;
    public Image InfoSkillImage;
    public Image InfoSkill2Image;
    public Text InfoCharInfo;
    public Text InfoName;
    public Text BuyText;
    public GameObject[] charob;
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

            come.CharactersSkill_ItemIconNum = csvData.CharactersSkill_ItemIconNum[i];

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
            come.MainImage.sprite = IconManager.inst.Icons[come.CharactersIconNum];
            GameInfo.inst.CharsInfo.Add(come);
            if (come.State == 0)
            {
                c.SetActive(false);
            }
            else if (come.State == 1)
            {
                come.MainImage.color = newcolor;
                come.LockImage.SetActive(true);
            }

        }
        int cnt = GameInfo.inst.CharacterIdx;


        mainName.text = csvData.GameText(csvData.CharactersNameNum[cnt]);
        //mainName.GetComponent<TextIdx>().Idx = csvData.CharactersNameNum[cnt];
        CharImage.sprite = IconManager.inst.Icons[csvData.CharactersIconNum[cnt]];
        RawCharaImage.texture = IconManager.inst.CharaIcons[cnt]; //로우이미지
        SkillImage.sprite = IconManager.inst.Icons[csvData.CharactersSkillIconNum[cnt]];
        Skill2Image.sprite = IconManager.inst.Icons[csvData.CharactersSkill_ItemIconNum[cnt]];
        charob[cnt].SetActive(true);

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

        GameInfo.inst.SkillIdx = GameInfo.inst.CharsInfo[cnt].CharactersBSNum;

        CharSetString();

    }

    public void CharSetString()
    {
        int cnt = GameInfo.inst.CharacterIdx;
        mainName.text = csvData.GameText(csvData.CharactersNameNum[cnt]);
        CharSkillName1.text = csvData.GameText(csvData.CharactersSkillName[cnt]);
        CharSkillName2.text = csvData.GameText(csvData.CharactersSkill_ItemName[cnt]);
        ///

        //CharName.text = csvData.GameText(csvData.CharactersNameNum[cnt]);
        //CharInfo.text = csvData.GameText(csvData.CharactersInfoNum[cnt]);

    }

    public void EquipBtnClick()
    {
        InfoOb.SetActive(false);
        charob[GameInfo.inst.CharacterIdx].SetActive(false);
        GameObject g = ClickOb;
        int cnt= g.GetComponent<CharacterBtn>().CharacterIdx;
        GameInfo.inst.CharacterIdx = cnt;
        charob[cnt].SetActive(true);

        GameInfo.inst.SkillIdx = csvData.CharactersBSNum[cnt];
        //Debug.Log(cnt);
        CharImage.sprite = IconManager.inst.Icons[csvData.CharactersIconNum[cnt]];
        RawCharaImage.texture = IconManager.inst.CharaIcons[cnt]; //로우이미지
        SkillImage.sprite = IconManager.inst.Icons[csvData.CharactersSkillIconNum[cnt]];
        Skill2Image.sprite = IconManager.inst.Icons[csvData.CharactersSkill_ItemIconNum[cnt]];

        CharSetString();
        //CharName.text = csvData.GameText(csvData.CharactersNameNum[cnt]);
        //CharInfo.text = csvData.GameText(csvData.CharactersInfoNum[cnt]);

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


    public void BtnClick(GameObject g,int State)
    {
        EquipBtn.SetActive(false);
        BuyBtn.SetActive(false);
        ClickOb = g;
        InfoOb.SetActive(true);
        if (State == 2)
        {
            EquipBtn.SetActive(true);
        }
        else
        {
            BuyBtn.SetActive(true);
            BuyText.text = ClickOb.GetComponent<CharacterBtn>().CharactersPrice.ToString();
            if (true)
            {

            }
        }
        InfoCharImage.sprite = IconManager.inst.Icons[ClickOb.GetComponent<CharacterBtn>().CharactersIconNum];
        InfoName.text = csvData.GameText(ClickOb.GetComponent<CharacterBtn>().CharactersNameNum);
        InfoSkillImage.sprite = IconManager.inst.Icons[ClickOb.GetComponent<CharacterBtn>().CharactersSkillIconNum];
        InfoSkill2Image.sprite = IconManager.inst.Icons[ClickOb.GetComponent<CharacterBtn>().CharactersSkill_ItemIconNum];
        InfoCharInfo.text = csvData.GameText(ClickOb.GetComponent<CharacterBtn>().CharactersInfoNum);
        //이미지변경
        //네임벼녁ㅇ
        //스킬이미지변경
        //캐릭터설명 추가
    }

    public void BuyButton()
    {
        if (GameInfo.PlayerGold >= ClickOb.GetComponent<CharacterBtn>().CharactersPrice )
        {
            GameInfo.PlayerGold -= ClickOb.GetComponent<CharacterBtn>().CharactersPrice;
            lobyui.LobyGoldAc();
            ClickOb.GetComponent<CharacterBtn>().LockImage.SetActive(false);
            ClickOb.GetComponent<CharacterBtn>().State = 2;
            GameInfo.inst.CharacterActive[ClickOb.GetComponent<CharacterBtn>().CharacterIdx] = 2;
            InfoOb.SetActive(false);
            ClickOb.GetComponent<CharacterBtn>().MainImage.color = newcolor2;
        }
    }

}
