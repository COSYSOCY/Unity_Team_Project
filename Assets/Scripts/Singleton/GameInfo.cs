using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
	static GameInfo inst;
	public float PlayerBGM;
	public float PlayerSE;
	public bool PlayerVFX;
	public bool PlayerDmg;
	public int PlayerGold;
	
	public int HpPlus;
	public int DamagePlus;
	public int BulletCntPlus;
	public int SkillCoolPlus;
	public int HpRegenPlus;
	public int Attack_RangePlus;
	public int MoveSpeedPlus;
	public int DefencePlus;
	public int BulletSpeedPlus;
	public int BulletTimePlus;
	public string Language = "Korean";




	void Awake() => inst = this;


}
