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
	public bool PlayerBGM; // 배경음
	public bool PlayerSE; // 사운드
	public bool PlayerDmg; //데미지표시 유무
	public static int PlayerGold; // 플레이어 골드
	public static int PlayerPoint; // 플레이어 보석

	public int CharacterIdx; //캐릭터번호
	public int MapIdx; // 맵번호
	public int SkillIdx; // 스킬번호
	public List<int> CharacterActive; // 0 없음 1 구매가능 2 보유함
	public int CharacterMax;
	public static float Range; // 자석

	// 카드
	public int PlayerCardMax; // 게임의 카드 착용 최대갯수
	public int CardMax; // 게임의 카드정보 최대갯수
	public List<int> PlayerCardIdxs; // 플레이어 카드 정보 게임의 카드 최대갯수가 4개라면 1,2,3,4 1번 슬룻에 1번카드 2번슬룻에 2번카드 3번슬룻에3번카드4번슬룻에 4번카드
	public List<int> PlayerCardCheck; // 플레이어 카드체크 손쉽게 확인하는법 PlayerCardCheck[10]=2 라면 인덱스10번의 카드가 2개 착용중이라는 뜻
	public List<int> PlayerCards; // 플레이어가 가지고있는 카드정보들

	public List<CardInfo> CardsInfo; // 게임의 카드정보
	//
	public List<CharacterBtn> CharsInfo; // 게임의 캐릭터정보

	//
	public List<MapInfo> MapsInfo;
	//
	public static float HpPlus; // 최대체력 설정
	public static float DamagePlus;//데미지추가%
	public static int BulletCntPlus;//투사체수증가
	public static float SkillCoolPlus;//능력 쿨다운 감소%
	public static float HpRegenPlus;//리젠(상수) 초마다 회복
	public static float Attack_RangePlus; //공격범위 증가%
	public static float MoveSpeedPlus; //이동속도 설정
	public static float DefencePlus; // 방어력증가 (상수)
	public static float BulletSpeedPlus;//투사체 이속동도증가%
	public static float BulletTimePlus;//투사체 지속시간 증가%
	public static float XpPlus;//Xp증가
	public string Language = "Korean"; // 언어




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
		CharacterActive[0] = 2; //기본캐릭 무조건 있어야함.

		// 임시
		CharacterActive[1] = 1;
		CharacterActive[2] = 1;
		// 임시
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
		// 임시
		//PlayerCardIdxs[0] = 1;
		//PlayerCardIdxs[1] = 2;
		//PlayerCardIdxs[2] = 3;
		//PlayerCardIdxs[3] = 0;


		// 임시
	}
	public static void soundcheck()
    {
		inst.audioSo.volume = 1f;

	}

}
