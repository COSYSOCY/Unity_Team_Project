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
	public float CardStat_HpC;
	public float CardStat_HpP;
	public float CardStat_HpRegen;
	public float CardStat_Defence;
	public float CardStat_Speed;
	public float CardStat_DamageP;
	public int CardStat_BtCnt;
	public float CardStat_Cool;
	public float CardStat_XpPlus;

}
public class GameInfo : MonoBehaviour
{
	public static GameInfo inst;
	public AudioSource audioSo;
	public bool PlayerBGM; // �����
	public bool PlayerSE; // ����
	public bool PlayerDmg; //������ǥ�� ����
	public static int PlayerGold; // �÷��̾� ���
	public static int PlayerPoint; // �÷��̾� ����

	public int CharacterIdx; //ĳ���͹�ȣ
	public int MapIdx; // �ʹ�ȣ
	public int SkillIdx; // ��ų��ȣ
	public List<int> CharacterActive; // 0 ���� 1 ���Ű��� 2 ������
	public int CharacterMax;
	public static float Range; // �ڼ�

	// ī��
	public int PlayerCardMax; // ������ ī�� ���� �ִ밹��
	public int CardMax; // ������ ī������ �ִ밹��
	public List<int> PlayerCardIdxs; // �÷��̾� ī�� ���� ������ ī�� �ִ밹���� 4����� 1,2,3,4 1�� ���� 1��ī�� 2������ 2��ī�� 3������3��ī��4������ 4��ī��
	public List<int> PlayerCardCheck; // �÷��̾� ī��üũ �ս��� Ȯ���ϴ¹� PlayerCardCheck[10]=2 ��� �ε���10���� ī�尡 2�� �������̶�� ��
	public List<int> PlayerCards; // �÷��̾ �������ִ� ī��������

	public List<CardInfo> CardsInfo; // ������ ī������
	//
	public List<CharacterBtn> CharsInfo; // ������ ĳ��������

	//
	public List<MapInfo> MapsInfo;
	//
	public static float HpPlus; // �ִ�ü�� ����
	public static float DamagePlus;//�������߰�%
	public static int BulletCntPlus;//����ü������
	public static float SkillCoolPlus;//�ɷ� ��ٿ� ����%
	public static float HpRegenPlus;//����(���) �ʸ��� ȸ��
	public static float Attack_RangePlus; //���ݹ��� ����%
	public static float MoveSpeedPlus; //�̵��ӵ� ����
	public static float DefencePlus; // �������� (���)
	public static float BulletSpeedPlus;//����ü �̼ӵ�������%
	public static float BulletTimePlus;//����ü ���ӽð� ����%
	public static float XpPlus;//Xp����
	public string Language = "Korean"; // ���




	void Awake()
	{
		inst = this;
		audioSo = inst.GetComponent<AudioSource>();
		PlayerGold = 600;
		PlayerPoint = 5;
	}

	public void CharaMax()
    {
		for (int i = 0; i < CharacterMax; i++)
		{
			CharacterActive.Add(0);

		}
		CharacterActive[0] = 2; //�⺻ĳ�� ������ �־����.

		// �ӽ�
		CharacterActive[1] = 1;
		CharacterActive[2] = 1;
		// �ӽ�
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
			CardsInfo[i].CardStat_HpC = csvData.CardHpC[i];
			CardsInfo[i].CardStat_HpP = csvData.CardHpP[i];
			CardsInfo[i].CardStat_HpRegen = csvData.CardHpRegen[i];
			CardsInfo[i].CardStat_Defence = csvData.CardDefence[i];
			CardsInfo[i].CardStat_Speed = csvData.CardSpeed[i];
			CardsInfo[i].CardStat_DamageP = csvData.CardDamage[i];
			CardsInfo[i].CardStat_BtCnt = csvData.CardBtCnt[i];
			CardsInfo[i].CardStat_Cool = csvData.CardCood[i];
			CardsInfo[i].CardStat_XpPlus = csvData.CardXpPlus[i];
			PlayerCardCheck.Add(0);
		}
        for (int i = 0; i < PlayerCardMax; i++)
        {
			PlayerCardIdxs.Add(0);

		}
		// �ӽ�
		//PlayerCardIdxs[0] = 1;
		//PlayerCardIdxs[1] = 2;
		//PlayerCardIdxs[2] = 3;
		//PlayerCardIdxs[3] = 0;


		// �ӽ�
	}
	public static void soundcheck()
    {
		inst.audioSo.volume = 1f;

	}

}
