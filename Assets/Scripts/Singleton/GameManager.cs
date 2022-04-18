using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager inst;
	public bool PlayerBGM; // 배경음
	public bool PlayerSE; // 사운드
	public bool PlayerDmg; //데미지표시 유무
	public bool PlayerCoolUi; //쿨타임표시 유무
	public int PlayerGold; // 플레이어 골드
	public int PlayerKill; // 플레이어 킬수

	public int CharacterIdx; //캐릭터번호
	public int MapIdx; // 맵번호
	public int SkillIdx; // 스킬번호
    private void Awake()
    {
        if (null == inst)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
