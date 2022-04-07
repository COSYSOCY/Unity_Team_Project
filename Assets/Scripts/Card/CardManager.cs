using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    //public List<Sprite> icons;
    public List<Image> CardImages;
    public GameObject CardPrefab;
    public Transform parent;
    public RectTransform rectTrans;
    public int ClickIdx = 0; //Ŭ���Ѱ�.
    public List<GameObject> cardlist;
    public Text CardName;
    public Text CardInfo;
    public GameObject CardStatusPopup;
    public GameObject CombinationPopup;
    public Image cardselectimage;    
    


    //public Color ClickColor;
    //public Color BasicColor;
    public LobyUIMgr lobyui;

    public GameObject ClickObject;
    public GameObject WarningTextOb;
    //public GameObject GoldObject;
    //public Text GoldText;



    void SizeSet()
    {
        float f = 0;
        if (GameInfo.inst.PlayerCards.Count > 4)
        {
            f = (GameInfo.inst.PlayerCards.Count / 4) * 280f;
            f += 1500f;
        }
        else
        {
            f = 1500;
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
                }
                else
                {
                    CardImages[i].sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[a].CardIconNum];                    

                    CardImages[i].GetComponentInParent<CardIdx>().Idx = GameInfo.inst.PlayerCardIdxs[i];                    
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
                        
                        card.GetComponent<CardIdx>().Idx = a;
                        card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[a].CardIconNum];
                    }

                }
                else
                {
                    GameObject card = Instantiate(CardPrefab, parent);
                    cardlist.Add(card);
                    int a = GameInfo.inst.PlayerCards[i];
                    card.GetComponent<CardIdx>().Idx = a;
                    card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[a].CardIconNum];
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
        CardInfo.text = "";
        CardInfo.gameObject.GetComponent<TextIdx>().Idx = 99999; //��ĭ����
        ClickObject = null;
        cardselectimage.sprite = ClickObject.GetComponent<CardIdx>().image.sprite;

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
        s = GameInfo.inst.CardsInfo[a].CardInfoNum;
        CardInfo.text = csvData.GameText(s);
        CardInfo.gameObject.GetComponent<TextIdx>().Idx = s;
        cardselectimage.sprite = ClickObject.GetComponent<CardIdx>().image.sprite;
        }
    }
    public void InvenCardButton(GameObject g) // �κ��丮�� ī�� ��ư ������
    {        
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
        GameObject card = Instantiate(CardPrefab, parent);
        cardlist.Add(card);
        card.GetComponent<CardIdx>().Idx = idx;
        card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[idx].CardIconNum];
        GameInfo.inst.PlayerCards.Add(idx);        
        InfoReset();
        CardNumReset();
        SizeSet();
        CardCheck();
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
        cardlist.RemoveAt(num);
        GameInfo.inst.PlayerCards.RemoveAt(num);
        Destroy(ClickObject);
        InfoReset();

        CardNumReset();
        CardCheck();
    }
    public void EquipButton()
    {
        
        
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
            WarningTextOb.SetActive(true);
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

        card.GetComponent<CardIdx>().Idx = a;
        card.GetComponent<CardIdx>().image.sprite = IconManager.inst.Icons[GameInfo.inst.CardsInfo[a].CardIconNum];
        CardNumReset();
        SizeSet();
    }

    public void itemcheat()
    {
        ItemAdd(Random.Range(1, 10));
    }

    public void CardStatusPopupAct()
    {
        CardStatusPopup.SetActive(true);
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

}
