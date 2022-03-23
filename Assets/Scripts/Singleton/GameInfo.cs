using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
	static GameInfo inst;
	public static float PlayerBGM; // 배경음
	public static float PlayerSE; // 사운드
	public static bool PlayerVFX; // 이펙트 유무
	public static bool PlayerDmg; //데미지표시 유무
	public static int PlayerGold; // 플레이어 골드
	
	public static float HpPlus; // 체력추가%
	public static float DamagePlus;//데미지추가%
	public static int BulletCntPlus;//투사체수증가
	public static float SkillCoolPlus;//능력 쿨다운 감소%
	public static float HpRegenPlus;//리젠(상수) 초마다 회복
	public static float Attack_RangePlus; //공격범위 증가%
	public static float MoveSpeedPlus; //이동속도증가%
	public static float DefencePlus; // 방어력증가 (상수)
	public static float BulletSpeedPlus;//투사체 이속동도증가%
	public static float BulletTimePlus;//투사체 지속시간 증가%
	public static string Language = "Korean"; // 언어




	void Awake() => inst = this;


}
