using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Sprite[] ButtonSprite;
    public List<GameObject> CationOb;
    //public List<Sprite> icons;
    public List<Image> CardImages;
    public GameObject CardPrefab;
    public Transform parent;
    public RectTransform rectTrans;
    public int ClickIdx = 0; //Ŭ���Ѱ�.
    public List<GameObject> cardlist;
    public Text CardName;
    public Text MainCardName;
    public Text CardInfo;
    public GameObject CardStatusPopup;
    public GameObject CombinationPopup;
    public Image cardselectimage;

    public List<GameObject> PlayerCard;
    public List<GameObject> MixCard;

    public List<GameObject> MixCardE;

    public bool IsMix = false;

    //public Color ClickColor;
    //public Color BasicColor;
    public LobyUIMgr lobyui;

    public GameObject ClickObject;
    public GameObject WarningTextOb;

    public Color[] CardColor;

    public int CaIdx = 0;

    public GameObject MixButtonOb;

    public GameObject MixLoading;
    public GameObject MixEnd;

    public Text MixEndR;
    public Text MixEndName;
    public Text MixEndLvText;
    public Text MixEndInfo;
    public Image MixEndIcon;
    //public GameObject GoldObject;
    //public Text GoldText;



    void SizeSet()
    {
        float f = 0;
        int num = 0;
        if (CaIdx==0)
        {
             num = GameInfo.inst.PlayerCards.Count;
        }
        else
        {

        for (int i = 0; i < GameInfo.inst.PlayerCards.Count; i++)
        {
            if (GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCards[i]].CardLv==CaIdx)
            {
                num++;
            }
        }
        }
        if (num > 4)
        {
            f = (num / 4) * 280f;
            f += 2000f;
        }
        else
        {
            f = 2000;
        }

        rectTrans.sizeDelta = new Vector2(rectTrans.sizeDelta.x, f + 0f); //ũ�⼳��
    }
    // Start is called before the first frame update
    void Start()
    {             

        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {
            if (GameInfo.inst.PlayerCardIdxs[i] == 0)
            {
                CardImages[i].sprite = IconManager.inst.Icons[19];
                PlayerCard[i].GetComponent<CardIdx>().Lv_Text.text = "";
            }
            else
            {
                int a = GameInfo.inst.PlayerCardIdxs[i];
                
                if (a > GameInfo.inst.CardMax)
                {
                    Debug.Log("����");
                    GameInfo.inst.PlayerCardIdxs[i] = 0;
                    a = GameInfo.inst.PlayerCardIdxs[i];
                    CardImages[i].sprite = IconManager.inst.Icons[19];
                    PlayerCard[i].GetComponent<CardIdx>().Lv_Text.text = "";
                }
                else
                {
                    CardImages[i].sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[a].CardIconNum];                    

                    CardImages[i].GetComponentInParent<CardIdx>().Idx = GameInfo.inst.PlayerCardIdxs[i];

                    int CardLv = GameInfo.inst.CardsInfo[GameInfo.inst.PlayerCardIdxs[i]].CardLv;
                    PlayerCard[i].GetComponent<CardIdx>().Lv = CardLv;

                    PlayerCard[i].GetComponent<CardIdx>().Lv_Text.text = "��"+ CardLv;
                }

            }
        }

        // �׽�Ʈ


        // �׽�Ʈ


        if (GameInfo.inst.PlayerCards.Count > 0)
        {
            for (int i = 0; i < GameInfo.inst.PlayerCards.Count; i++)
            {
                if (GameInfo.inst.PlayerCards[i] >= GameInfo.inst.CardMax)
                {
                    // ����ó��
                    GameInfo.inst.PlayerCards.RemoveAt(i);
                    if (i== GameInfo.inst.PlayerCards.Count )
                    {
                      
                       // ����ó�� �������̶�� �������ʿ����.
                    }
                    else
                    {
                        GameObject card = Instantiate(CardPrefab, parent);

                        cardlist.Add(card);
                        int a = GameInfo.inst.PlayerCards[i];
                        int CardLv = GameInfo.inst.CardsInfo[a].CardLv;
                        card.GetComponent<CardIdx>().Lv = CardLv;
                        card.GetComponent<CardIdx>().Lv_Text.text = "��" + CardLv;
                        card.GetComponent<CardIdx>().Idx = a;
                        card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[a].CardIconNum];
                        //card.name = "Card : " + a;
                    }

                }
                else
                {
                    GameObject card = Instantiate(CardPrefab, parent);
                    cardlist.Add(card);
                    int a = GameInfo.inst.PlayerCards[i];
                    int CardLv = GameInfo.inst.CardsInfo[a].CardLv;
                    card.GetComponent<CardIdx>().Lv = CardLv;
                    card.GetComponent<CardIdx>().Lv_Text.text = "��" + CardLv;
                    card.GetComponent<CardIdx>().Idx = a;
                    card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[a].CardIconNum];
                    //card.name = "Card : " + a;
                }

            }
        }
        CardNumReset();
        SizeSet();
        CardCheck();
    }
    public void CardCheck()
    {
        for (int i = 0; i < GameInfo.inst.PlayerCardCheck.Count; i++)
        {
            GameInfo.inst.PlayerCardCheck[i] = 0;            
        }
        for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
        {

            GameInfo.inst.PlayerCardCheck[GameInfo.inst.PlayerCardIdxs[i]]++;
        }
    }
    public void InfoReset()
    {
        if (ClickObject != null)
        {
            //ClickObject.GetComponent<Image>().color = BasicColor;
            ClickObject.GetComponent<CardIdx>().Focus.SetActive(false);            

        }
        CardName.text = "";
        CardName.gameObject.GetComponent<TextIdx>().Idx = 99999; // ��ĭ����
        MainCardName.text = "";
        MainCardName.gameObject.GetComponent<TextIdx>().Idx = 99999; // ��ĭ����
        CardInfo.text = "";
        CardInfo.gameObject.GetComponent<TextIdx>().Idx = 99999; //��ĭ����
        ClickObject = null;
        //cardselectimage.sprite = ClickObject.GetComponent<CardIdx>().image.sprite;
        cardselectimage.sprite = null;

        //GoldObject.SetActive(false);
    }
    public void PlayerCardButton(GameObject g) // �÷��̾��� ī�� ��ư ������
    {
        if (ClickObject==g)
        {
            //�Ȱ����� �������� ����
            UnEquipFunc();
            
            return;
        }
        if (g.GetComponent<CardIdx>().Idx==0)
        {
            if (ClickObject == null)
            {
                //�ƹ��͵� ���� ���¿��� Ŭ���Ѱ�
                

                return;
            }
            else//����̵�
            {
                if (ClickObject.GetComponent<CardIdx>().IsPlayerCard) // ���ĭ���� ���ĭ
                {
                    int checknum = g.GetComponent<CardIdx>().num;
                    int idx = ClickObject.GetComponent<CardIdx>().Idx;
                    int num = ClickObject.GetComponent<CardIdx>().num;
                    int iconNum = GameInfo.inst.CardsInfo[idx].CardIconNum;
                    GameInfo.inst.PlayerCardIdxs[checknum] = idx;
                    GameInfo.inst.PlayerCardIdxs[num] = 0;
                    CardImages[checknum].GetComponentInParent<CardIdx>().Idx = idx;
                    CardImages[num].GetComponentInParent<CardIdx>().Idx = 0;
                    CardImages[checknum].sprite = IconManager.inst.Icons[iconNum];
                    CardImages[num].sprite = IconManager.inst.Icons[19];                    

                    InfoReset();
                    return;
                }
                
                else //�κ�â���� �����ĭ Ŭ��
                {
                    
                    //�̵��׼�
                    //Debug.Log("üũ");
                    int checknum = g.GetComponent<CardIdx>().num;
                    int idx = ClickObject.GetComponent<CardIdx>().Idx;
                    int num = ClickObject.GetComponent<CardIdx>().num;
                    int iconNum = GameInfo.inst.CardsInfo[idx].CardIconNum;
                    //ClickObject.GetComponent<Image>().color = BasicColor; //�� �ʱ�ȭ

                    GameInfo.inst.PlayerCardIdxs[checknum] = idx; //�ε�������
                    CardImages[checknum].GetComponentInParent<CardIdx>().Idx = idx; //�ε�������
                    CardImages[checknum].sprite = IconManager.inst.Icons[iconNum];                    
                    cardlist.RemoveAt(num);
                    GameInfo.inst.PlayerCards.RemoveAt(num);
                    Destroy(ClickObject);
                    InfoReset();
                    //����
                    CardNumReset();
                    CardCheck();
                    return;
                }
            }

        }
        if (ClickObject!=null)
        {
            //ClickObject.GetComponent<Image>().color = BasicColor;
            ClickObject.GetComponent<CardIdx>().Focus.SetActive(false);            

        }
        //g.GetComponent<Image>().color = ClickColor;
        g.GetComponent<CardIdx>().Focus.SetActive(true);        
        ClickObject = g;
        Info(g);

    }
    public void Info(GameObject g)
    {
        int a = g.GetComponent<CardIdx>().Idx;
        int s = GameInfo.inst.CardsInfo[a].CardNameNum;
        
        if (a==0)
        {
            InfoReset();
        }
        else
        {
            //int gold = GameInfo.inst.CardsInfo[a].CardPrice;
           // GoldObject.SetActive(true);
           // GoldText.text = gold.ToString();

        CardName.text = csvData.GameText(s);
        CardName.gameObject.GetComponent<TextIdx>().Idx = s;
            MainCardName.text = csvData.GameText(s);
            MainCardName.gameObject.GetComponent<TextIdx>().Idx = s;
            s = GameInfo.inst.CardsInfo[a].CardInfoNum;
        CardInfo.text = csvData.GameText(s);
        CardInfo.gameObject.GetComponent<TextIdx>().Idx = s;
        cardselectimage.sprite = ClickObject.GetComponent<CardIdx>().image.sprite;
        }
    }
    public void InvenCardButton(GameObject g) // �κ��丮�� ī�� ��ư ������
    {
        if (IsMix)
        {
            Mix_InvenCardButton(g);
            return;
        }
        if (ClickObject == g)
        {
            for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
            {
                if (CardImages[i].GetComponentInParent<CardIdx>().Idx == 0)
                {
                    //����
                    EquipFunc(i);                    
                    return;
                }
            }
            return;
        }
        if (ClickObject != null)
        {
            //ClickObject.GetComponent<Image>().color = BasicColor;
            ClickObject.GetComponent<CardIdx>().Focus.SetActive(false);            
        }
        else
        {

        }        
        //g.GetComponent<Image>().color = ClickColor;
        g.GetComponent<CardIdx>().Focus.SetActive(true);
        ClickObject = g;
        int a = g.GetComponent<CardIdx>().Idx;
        int s = GameInfo.inst.CardsInfo[a].CardNameNum;
       // int gold = GameInfo.inst.CardsInfo[a].CardPrice;
       // GoldObject.SetActive(true);
       // GoldText.text = gold.ToString();
        CardName.text = csvData.GameText(s);
        CardName.gameObject.GetComponent<TextIdx>().Idx = s;
        MainCardName.text = csvData.GameText(s);
        MainCardName.gameObject.GetComponent<TextIdx>().Idx = s;
        s = GameInfo.inst.CardsInfo[a].CardInfoNum;
        CardInfo.text = csvData.GameText(s);
        CardInfo.gameObject.GetComponent<TextIdx>().Idx = s;
        cardselectimage.sprite = ClickObject.GetComponent<CardIdx>().image.sprite;

    }

    public void MixCardButton(GameObject g)
    {
        if (ClickObject != null)
        {
            //ClickObject.GetComponent<Image>().color = BasicColor;
            ClickObject.GetComponent<CardIdx>().Focus.SetActive(false);
        }
        if (ClickObject == g)
        {
            //�Ȱ����� �������� ����
            UnEquipFunc2(ClickObject.GetComponent<CardIdx>().num);

            return;
        }
        if (g.GetComponent<CardIdx>().Idx == 0)
        {
            if (ClickObject == null)
            {
                //�ƹ��͵� ���� ���¿��� Ŭ���Ѱ�


                return;
            }
            else//����̵�
            {
                if (ClickObject.GetComponent<CardIdx>().IsMixCard) // ����ĭ���� ����ĭ����
                {

                        int checknum = g.GetComponent<CardIdx>().num; // �� �ѹ�
                        int idx = ClickObject.GetComponent<CardIdx>().Idx;
                        int num = ClickObject.GetComponent<CardIdx>().num; // �� �ѹ�
                        int Lv = ClickObject.GetComponent<CardIdx>().Lv; // �� �ѹ�
                        int iconNum = GameInfo.inst.CardsInfo[idx].CardIconNum;

                    MixCard[checknum].GetComponent<CardIdx>().image.sprite = MixCard[num].GetComponent<CardIdx>().image.sprite;
                        MixCard[checknum].GetComponent<CardIdx>().Idx = idx;
                        MixCard[checknum].GetComponent<CardIdx>().Lv_Text.text = "��"+Lv;
                        MixCard[checknum].GetComponent<CardIdx>().Lv =Lv;

                    MixCard[num].GetComponent<CardIdx>().Idx = 0;
                    MixCard[num].GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[133];
                    MixCard[num].GetComponent<CardIdx>().Focus.SetActive(false);
                    MixCard[num].GetComponent<CardIdx>().Lv_Text.text = "";



                    MixCardE[checknum] = MixCardE[num];
                        MixCardE[num] = null;

                        InfoReset();
                    
                    
                    return;
                }

                else //�κ�â���� ���ռ�ĭ Ŭ��
                {
                    
                        if (MixCard[g.GetComponent<CardIdx>().num].GetComponent<CardIdx>().Idx == 0)
                        {
                            EquipFunc2(g.GetComponent<CardIdx>().num);
                            return;
                        }
                    


                }
            }

        }


        g.GetComponent<CardIdx>().Focus.SetActive(true);
        ClickObject = g;
        int a = g.GetComponent<CardIdx>().Idx;
        int s = GameInfo.inst.CardsInfo[a].CardNameNum;
        CardName.text = csvData.GameText(s);
        CardName.gameObject.GetComponent<TextIdx>().Idx = s;
        MainCardName.text = csvData.GameText(s);
        MainCardName.gameObject.GetComponent<TextIdx>().Idx = s;
        s = GameInfo.inst.CardsInfo[a].CardInfoNum;
        CardInfo.text = csvData.GameText(s);
        CardInfo.gameObject.GetComponent<TextIdx>().Idx = s;
        cardselectimage.sprite = ClickObject.GetComponent<CardIdx>().image.sprite;
    }
    public void UnEquipFunc() // ����
    {
        int idx = ClickObject.GetComponent<CardIdx>().Idx;
        //ClickObject.GetComponent<Image>().color = BasicColor;
        ClickObject.GetComponent<CardIdx>().Focus.SetActive(false);
        ClickObject.GetComponent<CardIdx>().Idx = 0;
        GameInfo.inst.PlayerCardIdxs[ClickObject.GetComponent<CardIdx>().num] = 0;
        ClickObject.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[19];
        ClickObject.GetComponent<CardIdx>().Lv_Text.text = "";
        GameObject card = Instantiate(CardPrefab, parent);
        cardlist.Add(card);
        card.GetComponent<CardIdx>().Idx = idx;

        int CardLv = GameInfo.inst.CardsInfo[idx].CardLv;
        card.GetComponent<CardIdx>().Lv = CardLv;
        card.GetComponent<CardIdx>().Lv_Text.text = "��" + CardLv;

        card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[idx].CardIconNum];
        GameInfo.inst.PlayerCards.Add(idx);  
        

        InfoReset();
        CardNumReset();
        SizeSet();
        CardCheck();
        CardCation(CaIdx);
    }
    public void EquipFunc(int i) // ����
    {
        int idx = ClickObject.GetComponent<CardIdx>().Idx;
        int num = ClickObject.GetComponent<CardIdx>().num;
        int iconNum = GameInfo.inst.CardsInfo[idx].CardIconNum;
        //ClickObject.GetComponent<Image>().color = BasicColor; //�� �ʱ�ȭ

        GameInfo.inst.PlayerCardIdxs[i] = idx; //�ε�������
        CardImages[i].GetComponentInParent<CardIdx>().Idx = idx; //�ε�������
        CardImages[i].sprite = IconManager.inst.Icons[iconNum];

        int CardLv = GameInfo.inst.CardsInfo[idx].CardLv;
        PlayerCard[i].GetComponent<CardIdx>().Lv = CardLv;
        PlayerCard[i].GetComponent<CardIdx>().Lv_Text.text = "��" + CardLv;


        cardlist.RemoveAt(num);
        GameInfo.inst.PlayerCards.RemoveAt(num);
        Destroy(ClickObject);
        InfoReset();

        CardNumReset();
        CardCheck();
    }
    public void EquipFunc2(int i) // �ռ�����
    {
        if (ClickObject.GetComponent<CardIdx>().MixSelect.activeSelf)
        {
            return;
        }
        int idx = ClickObject.GetComponent<CardIdx>().Idx;
        int CardLv = ClickObject.GetComponent<CardIdx>().Lv;
        int num = ClickObject.GetComponent<CardIdx>().num;
        int iconNum = GameInfo.inst.CardsInfo[idx].CardIconNum;

        MixCard[i].GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[iconNum];
        MixCard[i].GetComponent<CardIdx>().Lv = CardLv;
        MixCard[i].GetComponent<CardIdx>().Lv_Text.text = "��" + CardLv;
        MixCard[i].GetComponent<CardIdx>().Idx = idx;
        ClickObject.GetComponent<CardIdx>().MixSelect.SetActive(true);

        if (MixCardE[0] ==null && MixCardE[1]==null)
        {
            MixOk(CardLv);
        }
        
        MixCardE[i] = ClickObject;
        if (MixCardE[0] != null && MixCardE[1] != null)
        {
            MixButtonOb.SetActive(true);
        }
        InfoReset();
    }
    public void UnEquipFunc2(int i) // �ռ�����
    {
        int idx = ClickObject.GetComponent<CardIdx>().Idx;

        //ClickObject.GetComponent<Image>().color = BasicColor;
        ClickObject.GetComponent<CardIdx>().Focus.SetActive(false);
        ClickObject.GetComponent<CardIdx>().MixSelect.SetActive(false);
        MixCardE[i].GetComponent<CardIdx>().Focus.SetActive(false);
        MixCardE[i].GetComponent<CardIdx>().MixSelect.SetActive(false);
        MixCard[i].GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[133];
        MixCard[i].GetComponent<CardIdx>().Idx = 0;
        MixCard[i].GetComponent<CardIdx>().Lv_Text.text = "";
        MixCard[i].GetComponent<CardIdx>().Lv = 0;

        MixCardE[i] = null;
        if (MixCardE[0]==null && MixCardE[1]==null)
        {
            MixOk(0);
        }
        if (MixCardE[0] != null && MixCardE[1] != null)
        {
            MixButtonOb.SetActive(true);
        }
        else
        {
            MixButtonOb.SetActive(false);
        }
        InfoReset();

    }

    public void Mix_InvenCardButton(GameObject g)
    {
       
        if (g.GetComponent<CardIdx>().MixOk==false)
        {
            return;
        }

        if (ClickObject == g)
        {
            if (ClickObject.GetComponent<CardIdx>().MixSelect.activeSelf)
            {
                for (int i = 0; i < MixCard.Count; i++)
                {
                    if (ClickObject== MixCardE[i])
                    {
                        UnEquipFunc2(i);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < MixCard.Count; i++)
                {
                    if (MixCard[i].GetComponentInParent<CardIdx>().Idx == 0)
                    {
                        EquipFunc2(i);
                        return;
                    }
                }
            }
            
            return;
        }
        if (ClickObject != null)
        {
            //ClickObject.GetComponent<Image>().color = BasicColor;
            ClickObject.GetComponent<CardIdx>().Focus.SetActive(false);
        }
        g.GetComponent<CardIdx>().Focus.SetActive(true);
        ClickObject = g;
        int a = g.GetComponent<CardIdx>().Idx;
        int s = GameInfo.inst.CardsInfo[a].CardNameNum;
        CardName.text = csvData.GameText(s);
        CardName.gameObject.GetComponent<TextIdx>().Idx = s;
        MainCardName.text = csvData.GameText(s);
        MainCardName.gameObject.GetComponent<TextIdx>().Idx = s;
        s = GameInfo.inst.CardsInfo[a].CardInfoNum;
        CardInfo.text = csvData.GameText(s);
        CardInfo.gameObject.GetComponent<TextIdx>().Idx = s;
        cardselectimage.sprite = ClickObject.GetComponent<CardIdx>().image.sprite;
    }
    public void EquipButton()
    {
        if (IsMix)
        {
            MixEquipButton();
            return;
        }
        
        if (ClickObject == null)
        {
            //�ƹ��͵�����            
            return;
        }
        
        if (ClickObject.GetComponent<CardIdx>().IsPlayerCard)
        {
            //  ����
            UnEquipFunc();
            return;


        }
        else
        {
            //  ���뽺ũ��Ʈ
            for (int i = 0; i < GameInfo.inst.PlayerCardMax; i++)
            {
                if (CardImages[i].GetComponentInParent<CardIdx>().Idx==0)
                {
                    //����
                    EquipFunc(i); // i�����ٰ� ����                   

                    return;
                }
            }

            //���ĭ�� ��������
            //WarningTextOb.SetActive(true);
            InfoReset();
            return;
        }
    }

    public void MixEquipButton()
    {

        if (ClickObject == null)
        {
            //�ƹ��͵�����            
            return;
        }


        if (ClickObject.GetComponent<CardIdx>().IsMixCard)
        {
            //  ����
            UnEquipFunc2(ClickObject.GetComponent<CardIdx>().num);
            return;


        }
        else
        {
            if (ClickObject.GetComponent<CardIdx>().MixSelect.activeSelf)
            {
                for (int i = 0; i < MixCard.Count; i++)
                {
                    if (ClickObject==MixCardE[i])
                    {
                        UnEquipFunc2(i);
                        return;
                    }
                }
                
            }
            //  ���뽺ũ��Ʈ
            for (int i = 0; i < MixCard.Count; i++)
            {
                if (MixCard[i].GetComponent<CardIdx>().Idx == 0)
                {
                    //����
                    EquipFunc2(i); // i�����ٰ� ����                   

                    return;
                }
            }
            InfoReset();
            return;
        }
    }
    public void SellButton()
    {
        if (ClickObject == null)
        {
            //�ƹ��͵�����
            return;
        }
        int idx = ClickObject.GetComponent<CardIdx>().Idx;
        int gold = GameInfo.inst.CardsInfo[idx].CardPrice;
        
        GameInfo.PlayerGold += gold;
        lobyui.LobyGoldAc();
        if (ClickObject.GetComponent<CardIdx>().IsPlayerCard) //���ĭ���� �Ǹ�
        {
            int num = ClickObject.GetComponent<CardIdx>().num;
            CardImages[num].GetComponentInParent<CardIdx>().Idx = 0;
            GameInfo.inst.PlayerCardIdxs[num] = 0;
            CardImages[num].sprite = IconManager.inst.Icons[19];            

            CardCheck();
        }
        else//�κ�ĭ���� �Ǹ�
        {
            int num = ClickObject.GetComponent<CardIdx>().num;
            cardlist.RemoveAt(num);
            GameInfo.inst.PlayerCards.RemoveAt(num);
            Destroy(ClickObject);
            InfoReset();
            CardNumReset();
            SizeSet();
        }
        InfoReset();

    }
    public void CardNumReset()
    {
        if (cardlist.Count>0)
        {
            for (int i = 0; i < cardlist.Count; i++)
            {
                cardlist[i].GetComponent<CardIdx>().num = i;
            }

        }

    }

    public void ItemAdd(int i)
    {

        if (i >= GameInfo.inst.CardMax)
        {
            Debug.Log("����");
            return;
        }
        GameInfo.inst.PlayerCards.Add(i);
        GameObject card = Instantiate(CardPrefab, parent);

        cardlist.Add(card);
        int a = GameInfo.inst.PlayerCards[GameInfo.inst.PlayerCards.Count-1];
        int CardLv = GameInfo.inst.CardsInfo[a].CardLv;
        card.GetComponent<CardIdx>().Lv = CardLv;
        card.GetComponent<CardIdx>().Lv_Text.text = "��" + CardLv;
        card.GetComponent<CardIdx>().Idx = a;
        card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[a].CardIconNum];
        CardNumReset();
        SizeSet();
        CardCation(CaIdx);
        card.name = "Card : " + a;
    }

    public void itemcheat()
    {
        ItemAdd(Random.Range(1, 98));
    }

    public void CardStatusPopupAct()
    {
        if (ClickObject!=null)
        {

        CardStatusPopup.SetActive(true);
        }
    }

    public void CombinationPopupAct()
    {
        CombinationPopup.SetActive(true);
    }

    public void CardStatusPopupUnAct()
    {
        CardStatusPopup.SetActive(false);
    }

    public void CombinationPopupUnAct()
    {
        CombinationPopup.SetActive(false);
    }
    public void MixButton()
    {
        //InfoReset();
        ResetInvenALL();
        IsMix = true;
        for (int i = 0; i < MixCard.Count; i++)
        {
            MixCard[i].GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[133];
            MixCard[i].GetComponent<CardIdx>().Focus.SetActive(false);
            MixCard[i].GetComponent<CardIdx>().MixSelect.SetActive(false);
            MixCard[i].GetComponent<CardIdx>().Lv_Text.text = "";
            MixCard[i].GetComponent<CardIdx>().Idx = 0;
            MixCardE[i] = null;
        }
        MixButtonOb.SetActive(false);
        MixOk(0);
        ClickObject = null;
    }

    public void MixExitButton()
    {
        ResetInvenALL();


        IsMix = false;
    }
    public void ResetInvenALL()
    {
        ClickObject = null;
        MainCardName.text = "";
        MainCardName.gameObject.GetComponent<TextIdx>().Idx = 99999; // ��ĭ����
        
        for (int i = 0; i < cardlist.Count; i++)
        {
            cardlist[i].GetComponent<CardIdx>().Focus.SetActive(false);
            cardlist[i].GetComponent<CardIdx>().MixSelect.SetActive(false);
            cardlist[i].GetComponent<CardIdx>().image.color = CardColor[0];
            cardlist[i].GetComponent<CardIdx>().MixOk = true;
        }

    }

    public void MixOk(int MixLv)
    {
        for (int i = 0; i < cardlist.Count; i++)
        {
            cardlist[i].GetComponent<CardIdx>().image.color = CardColor[1];
            cardlist[i].GetComponent<CardIdx>().MixOk = false;
        }
        if (MixLv == 0)
        {

            for (int i = 0; i < cardlist.Count; i++)
            {
                    cardlist[i].GetComponent<CardIdx>().image.color = CardColor[0];
                    cardlist[i].GetComponent<CardIdx>().MixOk = true;

            }


        }
        else
        {
            for (int i = 0; i < cardlist.Count; i++)
            {
                if (cardlist[i].GetComponent<CardIdx>().Lv==MixLv)
                {
                    cardlist[i].GetComponent<CardIdx>().image.color = CardColor[0];
                    cardlist[i].GetComponent<CardIdx>().MixOk = true ;
                }
                
            }
        }
    }

    public void CardCation(int LvIdx)
    {
        CaIdx = LvIdx;
        for (int i = 0; i < cardlist.Count; i++)
        {
            cardlist[i].SetActive(false);
        }
        for (int i = 0; i < CationOb.Count; i++)
        {
            CationOb[i].GetComponent<Image>().sprite = ButtonSprite[1];
        }
        if (LvIdx == 0)
        {
            for (int i = 0; i < cardlist.Count; i++)
            {
                cardlist[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < cardlist.Count; i++)
            {
                //int idx = cardlist[i].GetComponent<CardIdx>().Idx;
                int lv = cardlist[i].GetComponent<CardIdx>().Lv;
                if (lv == LvIdx)
                {

                    cardlist[i].SetActive(true);
                }
            }
        }
        SizeSet();
        CationOb[LvIdx].GetComponent<Image>().sprite = ButtonSprite[0];
    }


    public void MixStart()
    {
        if (MixCardE[0] == null || MixCardE[1] == null)
        {
            return;
        }
        if (MixCardE[0].GetComponent<CardIdx>().Idx == 0 || MixCardE[1].GetComponent<CardIdx>().Idx == 0)
        {
            return;
        }
        StartCoroutine(IMixStart());
    }

    IEnumerator IMixStart()
    {
        int Lv = MixCardE[0].GetComponent<CardIdx>().Lv;
        float ran = Random.Range(0.01f, 100f);

        int CardLv = Lv;
        int CardIdx = 0;
        //Debug.Log("Ȯ��:::"+ ran);
        //Debug.Log("�װ� Ȯ��:::"+ csvData.MixPer[Lv]);
        if (ran <= csvData.MixPer[Lv])
        {
            CardLv++;
            MixEndR.text = csvData.GameText(1055);
        }
        else
        {
            MixEndR.text = csvData.GameText(1056);
        }
        if (CardLv >=5)
        {
            CardLv = 5;
        }
        int CardRan = Random.Range(0, GameInfo.inst.Cards_Lv(CardLv).Count);
        CardIdx = GameInfo.inst.Cards_Lv(CardLv)[CardRan];
        //Debug.Log("������ȣ:::" + CardRan);
        ///Debug.Log("�� ī�巹��:::" + Lv);
        //Debug.Log("�� ī�巹��:::" + CardLv);
        //Debug.Log("�ε���:::" + CardIdx);
        for (int i = 0; i < MixCardE.Count; i++)
        {

        int num = MixCardE[i].GetComponent<CardIdx>().num;
            Debug.Log("��ȣ:::" + num);
            cardlist.Remove(MixCardE[i]);
            //cardlist.RemoveAt(num);
        GameInfo.inst.PlayerCards.RemoveAt(num);
        Destroy(MixCardE[i]);
            MixCardE[i] = null;
            MixCard[i].GetComponent<CardIdx>().Lv = 0;
            MixCard[i].GetComponent<CardIdx>().Lv_Text.text = "";
            MixCard[i].GetComponent<CardIdx>().image.sprite= IconManager.inst.Icons[133];
            MixCard[i].GetComponent<CardIdx>().Idx = 0;
            MixCard[i].GetComponent<CardIdx>().Focus.SetActive(false);
        }

        
        MixLoading.SetActive(true);
        //GameObject card = Instantiate(CardPrefab, parent);
        //cardlist.Add(card);
        //card.GetComponent<CardIdx>().Idx = CardIdx;
        //card.GetComponent<CardIdx>().Lv = CardLv;
        //card.GetComponent<CardIdx>().Lv_Text.text = "��" + CardLv;

        //card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[CardIdx].CardIconNum];
        //GameInfo.inst.PlayerCards.Add(CardIdx);
        ItemAdd(CardIdx);

        MixEndName.text = csvData.GameText(GameInfo.inst.CardsInfo[CardIdx].CardNameNum);
        MixEndInfo.text = csvData.GameText(GameInfo.inst.CardsInfo[CardIdx].CardInfoNum);
        MixEndIcon.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[CardIdx].CardIconNum];
        MixEndLvText.text = "��" + Lv + " -> ��" + CardLv;
        yield return new WaitForSeconds(1);
        MixLoading.SetActive(false);
        MixEnd.SetActive(true);


        



        //CardCation(CaIdx);
        MixOk(0);
        //InfoReset();
        //SizeSet();
        //CardNumReset();
        //CardCheck();
    }
}
