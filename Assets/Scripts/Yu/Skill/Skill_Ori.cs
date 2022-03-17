using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ori : MonoBehaviour
{
    public int Index; // 인덱스
    [Header("셋팅 해야하는부분")]
    public GameObject Player; //플레이어
    public GameObject bulletPrefab; //총알Prefab
    public Transform bulletPos;//총알생성위치 (따로 생성되는위치가 필요할때 사용)
    [Space(16)]
    [Header("수치")]
    public int Lv; // 레벨
    public float Damage; // 데미지
    public int bulletCnt; // 투사체수
    [Space(16)]
    [Header("스킬설명")]
    public string Skill_Name; // 스킬 이름
    public List<string> Lv_Text; // 스킬 업그레이드 설명
    public int Skill_Icon; // 아이콘번호
    [Space(16)]
    protected bool start = false;

    public virtual void LevelUp()
    {

    }

}
