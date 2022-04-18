using System;
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

	public string UserName;
	public string Id;
	public bool GameStart=false;

	public static GameInfo inst;
	public AudioSource audioSo;
	public AudioSource audioSo2;
	public bool PlayerBGM; // 배경음
	public bool PlayerSE; // 사운드
	public bool PlayerDmg; //데미지표시 유무
	public bool PlayerCoolUi; //쿨타임표시 유무
	public static int PlayerGold; // 플레이어 골드
	public int PlayerKill; // 플레이어 킬수

	public int PlayerCardPickCnt; // 플레이어 뽑기 획수
	public int PlayerCardMixCnt; // 플레이어 합성 횟수

	public  int PlayerLevel; // 플레이어 레벨
	public  int PlayerXp; // 플레이어 경험치
	public  int PlayerXpMax; // 플레이어 최대경험치
	public  int PlayerEnergy; // 플레이어 에너지

	public  int PlayerEnergyMax; // 플레이어 최대에너지

	public int CharacterIdx; //캐릭터번호
	public int MapIdx; // 맵번호
	public int SkillIdx; // 스킬번호
	public List<int> CharacterActive; // 0 없음 1 구매가능 2 보유함
	public int CharacterMax;
	public static float Range; // 자석

	// 카드
	public int PlayerCardMax; // 게임의 카드 착용 최대갯수
	public int GameSystemCardMax=8; // 게임시스템의 착용횟수
	public int CardMax; // 게임의 카드정보 최대갯수
	public List<int> PlayerCardIdxs; // 플레이어 카드 정보 게임의 카드 최대갯수가 4개라면 1,2,3,4 1번 슬룻에 1번카드 2번슬룻에 2번카드 3번슬룻에3번카드4번슬룻에 4번카드
	public List<int> PlayerCardCheck; // 플레이어 카드체크 손쉽게 확인하는법 PlayerCardCheck[10]=2 라면 인덱스10번의 카드가 2개 착용중이라는 뜻
	public List<int> PlayerCards; // 플레이어가 가지고있는 카드정보들

	public List<CardInfo> CardsInfo; // 게임의 카드정보
	//
	public List<CharacterBtn> CharsInfo; // 게임의 캐릭터정보

	//
	public List<MapInfo> MapsInfo;
	public List<int> PlayerMap; // 플레이어가 가지고있는 맵

	//
	public static float HpPlus; // 최대체력 설정
	public static float DamagePlus;//데미지추가%
	public static int BulletCntPlus;//투사체수증가
	public static float SkillCoolPlus;//능력 쿨다운 감소%
	public static float HpRegenPlus;//리젠(상수) 초마다 회복
	public static float Attack_RangePlus; //공격범위 증가%
	public float MoveSpeedPlus; //이동속도 설정
	public static float DefencePlus; // 방어력증가 (상수)
	public static float BulletSpeedPlus;//투사체 이속동도증가%
	public static float BulletTimePlus;//투사체 지속시간 증가%
	public static float XpPlus;//Xp증가
	public string Language; // 언어

	public List<int> Card_Lv1;
	public List<int> Card_Lv2;
	public List<int> Card_Lv3;
	public List<int> Card_Lv4;
	public List<int> Card_Lv5;

	//상점
	 // 하루 광고보면 돈주는거 최대횟수 현재 서버로 저장해야함
	 // 하루 광고보면 카드 최대횟수 현재 서버로 저장해야함
							  //파워업
	public List<int> Player_PowerUp;
	public int Roulette = 0;

	//
	public List<int> Player_Mission;

	//====== 시간관리
	public DateTime Daycom1; // 일일보상
	public DateTime Daycom2; // 연속보상
	public DateTime Daycom3; // 월보상
	
	public int DayCom2Int;
	public int DayCom3Int;

	//===
	//== 광고 3회
	public bool[] IsAdGold;
	public DateTime[] AdGoldTime=new DateTime[3];
	public bool[] IsAdCard;
	public DateTime[] AdCardTime=new DateTime[3];
	public int AdGoldFreeMax()
    {
		int cnt = 0;
        for (int i = 0; i < IsAdGold.Length; i++)
        {
            if (!IsAdGold[i])
            {
				cnt++;
            }
        }
		return cnt;
    }

	public int AdCardFreeMax()
    {
		int cnt = 0;
		for (int i = 0; i < IsAdCard.Length; i++)
		{
			if (!IsAdCard[i])
			{
				cnt++;
			}
		}
		return cnt;
	}

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

	public int RandomCard(int Lv)
    {
		int random = UnityEngine.Random.Range(0, Cards_Lv(Lv).Count);
		return random;
	}

	public void MissionGo(int idx)
    {
        if (Player_Mission[idx] ==1)
        {
			return;
        }
		Player_Mission[idx] = 1;
		string s = "";
		int check = csvData.MissionOrder[idx];
		if (PcTestMode)
        {
			return;
        }
        switch (check)
        {
			case 0:
				s = GPGSIds.achievement_first_play;
				break;
			case 1:
				s = GPGSIds.achievement_blue_meadow_clear;
				break;
			case 2:
				s = GPGSIds.achievement_desert_clear;
				break;
			case 3:
				s = GPGSIds.achievement_desert_and_city_clear;
				break;
			case 4:
				s = GPGSIds.achievement_ice_meadow_clear;
				break;
			case 5:
				s = GPGSIds.achievement_open_card_number_1;
				break;
			case 6:
				s = GPGSIds.achievement_open_only_4_cards;
				break;
			case 7:
				s = GPGSIds.achievement_open_only_8_cards;
				break;
			case 8:
				s = GPGSIds.achievement_level_10_achievement;
				break;
			case 9:
				s = GPGSIds.achievement_level_50_achieved;
				break;
			case 10:
				s = GPGSIds.achievement_level_100_achievement;
				break;
			case 11:
				s = GPGSIds.achievement_achieve_the_first_100_kills;
				break;
			case 12:
				s = GPGSIds.achievement_achieving_the_first_1000_kills;
				break;
			case 13:
				s = GPGSIds.achievement_achieved_the_first_10000_kills;
				break;
			case 14:
				s = GPGSIds.achievement_achieved_the_first_100000_kills;
				break;
			case 15:
				s = GPGSIds.achievement_acquired_card_1;
				break;
			case 16:
				s = GPGSIds.achievement_acquired_card_2;
				break;
			case 17:
				s = GPGSIds.achievement_acquired_card_3;
				break;
			case 18:
				s = GPGSIds.achievement_acquired_card_4;
				break;
			case 19:
				s = GPGSIds.achievement_acquired_card_5;
				break;
			case 20:
				s = GPGSIds.achievement_5_card_draws;
				break;
			case 21:
				s = GPGSIds.achievement_100_card_draws;
				break;
			case 22:
				s = GPGSIds.achievement_5_card_mix;
				break;
			case 23:
				s = GPGSIds.achievement_100_card_mix;
				break;
			case 24:
				s = GPGSIds.achievement_nuff_gun_levle_8;
				break;
			case 25:
				s = GPGSIds.achievement_death_gun_levle_8;
				break;
			case 26:
				s = GPGSIds.achievement_rail_gun_levle_8;
				break;
			case 27:
				s = GPGSIds.achievement_magnetic_field_levle_8;
				break;
			case 28:
				s = GPGSIds.achievement_flame_radiation_levle_8;
				break;
			case 29:
				s = GPGSIds.achievement_bully_gun_levle_8;
				break;
			case 30:
				s = GPGSIds.achievement_bumping_bombing_levle_8;
				break;
			case 31:
				s = GPGSIds.achievement_duck_levle_8;
				break;
			case 32:
				s = GPGSIds.achievement_brainberry_levle_8;
				break;
			case 33:
				s = GPGSIds.achievement_repair_levle_8;
				break;
			case 34:
				s = GPGSIds.achievement_circular_dora_levle_8;
				break;
			case 35:
				s = GPGSIds.achievement_blocking_pillow_hall_levle_8;
				break;
			case 36:
				s = GPGSIds.achievement_flame_ball_levle_8;
				break;
			case 37:
				s = GPGSIds.achievement_reflecting_beet_levle_8;
				break;
			case 38:
				s = GPGSIds.achievement_ice_bath_levle_8;
				break;
			case 39:
				s = GPGSIds.achievement_blaze_staff_levle_8;
				break;
			case 40:
				s = GPGSIds.achievement_dark_boom_levle_8;
				break;
			case 41:
				s = GPGSIds.achievement_shooting_star_levle_8;
				break;
			case 42:
				s = GPGSIds.achievement_tornado_levle_8;
				break;
			case 43:
				s = GPGSIds.achievement_equalizer_levle_8;
				break;




			default:
				break;
        }
        GPGSBinder.Inst.UnlockAchievement(s, success => {
			if (success)
            {

			
            }
            else
            {
				Player_Mission[idx] = 0;
			}

			if (GameInfo.inst.PcTestMode)
			{
				ServerDataSystem.inst.SaveData2asdasdasd();
			}
			else
			{
				ServerDataSystem.inst.SaveData2asdasdasd();
				//ServerDataSystem.inst.ServerSave();
			}
		});
	}

}
