using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInfo
{
	public int CardIdx;
	public int CardLv;
	public int CardNameNum;
	public int CardInfoNum;
	public int CardIconNum;
	public int CardPrice;
	public int CardFocus;
	public float CardStat_HpC;
	public float CardStat_HpP;
	public float CardStat_HpRegen;
	public float CardStat_Defence;
	public float CardStat_Speed;
	public float CardStat_DamageP;
	public int CardStat_BtCnt;
	public float CardStat_Cool;
	public float CardStat_XpPlus;


	public float CardStat_GoldPlus;
	public float CardStat_AttackRange;
	public float CardStat_Range;

	public float CardStat_DmgPer;
	public float CardStat_BuSpeed;
	public float CardStat_BuTime;

	public float CardStat_Real1;
	public float CardStat_Real2;



}
public class GameInfo : MonoBehaviour
{
	public bool PcTestMode = false;
	public bool isTestMode;

	public bool GameStart=false;

	public static GameInfo inst;
	public AudioSource audioSo;
	public AudioSource audioSo2;
	public bool PlayerBGM; // �����
	public bool PlayerSE; // ����
	public bool PlayerDmg; //������ǥ�� ����
	public bool PlayerCoolUi; //��Ÿ��ǥ�� ����
	public static int PlayerGold; // �÷��̾� ���
	//public static int PlayerPoint; // �÷��̾� ����

	public  int PlayerLevel; // �÷��̾� ����
	public  int PlayerXp; // �÷��̾� ����ġ
	public  int PlayerXpMax; // �÷��̾� �ִ����ġ
	public  int PlayerEnergy; // �÷��̾� ������

	public  int PlayerEnergyMax; // �÷��̾� �ִ뿡����

	public int CharacterIdx; //ĳ���͹�ȣ
	public int MapIdx; // �ʹ�ȣ
	public int SkillIdx; // ��ų��ȣ
	public List<int> CharacterActive; // 0 ���� 1 ���Ű��� 2 ������
	public int CharacterMax;
	public static float Range; // �ڼ�

	// ī��
	public int PlayerCardMax; // ������ ī�� ���� �ִ밹��
	public int GameSystemCardMax=8; // ���ӽý����� ����Ƚ��
	public int CardMax; // ������ ī������ �ִ밹��
	public List<int> PlayerCardIdxs; // �÷��̾� ī�� ���� ������ ī�� �ִ밹���� 4����� 1,2,3,4 1�� ���� 1��ī�� 2������ 2��ī�� 3������3��ī��4������ 4��ī��
	public List<int> PlayerCardCheck; // �÷��̾� ī��üũ �ս��� Ȯ���ϴ¹� PlayerCardCheck[10]=2 ��� �ε���10���� ī�尡 2�� �������̶�� ��
	public List<int> PlayerCards; // �÷��̾ �������ִ� ī��������

	public List<CardInfo> CardsInfo; // ������ ī������
	//
	public List<CharacterBtn> CharsInfo; // ������ ĳ��������

	//
	public List<MapInfo> MapsInfo;
	public List<int> PlayerMap; // �÷��̾ �������ִ� ��

	//
	public static float HpPlus; // �ִ�ü�� ����
	public static float DamagePlus;//�������߰�%
	public static int BulletCntPlus;//����ü������
	public static float SkillCoolPlus;//�ɷ� ��ٿ� ����%
	public static float HpRegenPlus;//����(���) �ʸ��� ȸ��
	public static float Attack_RangePlus; //���ݹ��� ����%
	public float MoveSpeedPlus; //�̵��ӵ� ����
	public static float DefencePlus; // �������� (���)
	public static float BulletSpeedPlus;//����ü �̼ӵ�������%
	public static float BulletTimePlus;//����ü ���ӽð� ����%
	public static float XpPlus;//Xp����
	public string Language; // ���

	public List<int> Card_Lv1;
	public List<int> Card_Lv2;
	public List<int> Card_Lv3;
	public List<int> Card_Lv4;
	public List<int> Card_Lv5;

	//����
	public int AdGoldFreeMax; // �Ϸ� ������ ���ִ°� �ִ�Ƚ�� ���� ������ �����ؾ���
	public int AdCardFreeMax; // �Ϸ� ������ ī�� �ִ�Ƚ�� ���� ������ �����ؾ���
							  //�Ŀ���
	public List<int> Player_PowerUp;
	public int Roulette = 0;


	void Awake()
	{
		inst = this;
		audioSo = inst.GetComponent<AudioSource>();
	}

	public void CharaMax()
    {
		for (int i = 0; i < CharacterMax; i++)
		{
			CharacterActive.Add(0);
		}

		
	}

	public void PlayerXpPlus(int i)
    {
		PlayerXp += i;
        if (PlayerXp >= PlayerXpMax)
        {
			PlayerLevelUp();
		}

	}
	public void PlayerLevelUp()
    {
		PlayerXp -= PlayerXpMax;
		PlayerLevel++;
		PlayerXpMax = csvData.PlayerExpMax[PlayerLevel];
		PlayerXpPlus(0);
	}
    public void TestFunc() //ó�� �Ҷ� �ִ°� �׽�Ʈ��
    {
		AdGoldFreeMax = 3;

	}

    public void CardCheck()
    {
        for (int i = 0; i < CardMax; i++)
        {
			CardsInfo.Add(new CardInfo());
			CardsInfo[i].CardIdx = i;
			CardsInfo[i].CardNameNum = csvData.CardNameNum[i];
			CardsInfo[i].CardInfoNum = csvData.CardInfoNum[i];
			CardsInfo[i].CardIconNum = csvData.CardIconNum[i];
			CardsInfo[i].CardLv = csvData.CardLevel[i];
			CardsInfo[i].CardPrice = csvData.CardPrice[i];
			CardsInfo[i].CardFocus = csvData.CardFocus[i];
			CardsInfo[i].CardStat_HpC = csvData.CardHpC[i];
			CardsInfo[i].CardStat_HpP = csvData.CardHpP[i];
			CardsInfo[i].CardStat_HpRegen = csvData.CardHpRegen[i];
			CardsInfo[i].CardStat_Defence = csvData.CardDefence[i];
			CardsInfo[i].CardStat_Speed = csvData.CardSpeed[i];
			CardsInfo[i].CardStat_DamageP = csvData.CardDamage[i];
			CardsInfo[i].CardStat_BtCnt = csvData.CardBtCnt[i];
			CardsInfo[i].CardStat_Cool = csvData.CardCood[i];
			CardsInfo[i].CardStat_XpPlus = csvData.CardXpPlus[i];

			CardsInfo[i].CardStat_GoldPlus = csvData.CardGoldPlus[i];
			CardsInfo[i].CardStat_AttackRange = csvData.CardAttackRange[i];
			CardsInfo[i].CardStat_Range = csvData.CardRange[i];

			CardsInfo[i].CardStat_DmgPer = csvData.CardDmgPer[i];
			CardsInfo[i].CardStat_BuSpeed = csvData.CardBuSpeed[i];
			CardsInfo[i].CardStat_BuTime = csvData.CardBuTime[i];

			CardsInfo[i].CardStat_Real1 = csvData.CardReal1[i];
			CardsInfo[i].CardStat_Real2 = csvData.CardReal2[i];

            switch (CardsInfo[i].CardLv)
            {
				case 1:
					Card_Lv1.Add(i);
					break;
				case 2:
					Card_Lv2.Add(i);
					break;
				case 3:
					Card_Lv3.Add(i);
					break;
				case 4:
					Card_Lv4.Add(i);
					break;
				case 5:
					Card_Lv5.Add(i);
					break;
				default:
					break;
			}
			PlayerCardCheck.Add(0);
		}
        for (int i = 0; i < GameSystemCardMax; i++)
        {
			PlayerCardIdxs.Add(0);

		}

	}
	public List<int> Cards_Lv(int lv)
    {
		switch (lv)
		{
			case 1:
				return Card_Lv1;

			case 2:
				return Card_Lv2;

			case 3:
				return Card_Lv3;

			case 4:
				return Card_Lv4;

			case 5:
				return Card_Lv5;

			default:
				return Card_Lv1;

		}
		return Card_Lv1;
	}
	public static void soundcheck()
    {
		inst.audioSo.volume = 1f;

	}


}
