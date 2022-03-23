using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Info : MonoBehaviour
{
    public int Index; // 인덱스
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

    public void LevelUpCheck()
    {
        switch (Index)
        {
            case 0:
                gameObject.GetComponent<Skill_1>().LevelUp();
                break;
            case 1:
                gameObject.GetComponent<Skill_2>().LevelUp();
                break;
            case 2:
                gameObject.GetComponent<Skill_3>().LevelUp();
                break;
            case 3:
                gameObject.GetComponent<Skill_4>().LevelUp();
                break;
            case 4:
                gameObject.GetComponent<Skill_5>().LevelUp();
                break;
            case 5:
                gameObject.GetComponent<Skill_6>().LevelUp();
                break;
            case 6:
                gameObject.GetComponent<Skill_7>().LevelUp();
                break;
            case 7:
                gameObject.GetComponent<Skill_8>().LevelUp();
                break;
            case 8:
                gameObject.GetComponent<Skill_9>().LevelUp();
                break;
            case 9:
                gameObject.GetComponent<Skill_10>().LevelUp();
                break;
            case 10:
                gameObject.GetComponent<Skill_11>().LevelUp();
                break;
            case 11:
                gameObject.GetComponent<Skill_12>().LevelUp();
                break;
            case 12:
                gameObject.GetComponent<Skill_13>().LevelUp();
                break;
            case 13:
                gameObject.GetComponent<Skill_14>().LevelUp();
                break;            
            default:
                break;
        }

    }
}
