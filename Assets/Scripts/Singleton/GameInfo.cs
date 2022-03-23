using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
	static GameInfo inst;
	public static float PlayerBGM;
	public static float PlayerSE;
	public static bool PlayerVFX;
	public static bool PlayerDmg;
	public static int PlayerGold;
	
	public static int HpPlus;
	public static int DamagePlus;
	public static int BulletCntPlus;
	public static int SkillCoolPlus;
	public static int HpRegenPlus;
	public static int Attack_RangePlus;
	public static int MoveSpeedPlus;
	public static int DefencePlus;
	public static int BulletSpeedPlus;
	public static int BulletTimePlus;
	public static string Language = "Korean";




	void Awake() => inst = this;


}
