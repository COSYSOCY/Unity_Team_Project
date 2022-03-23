using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Info : MonoBehaviour
{
    public int Index; // �ε���
    [Space(16)]
    [Header("��ġ")]
    public int Lv; // ����
    public float Damage; // ������
    public int bulletCnt; // ����ü��
    [Space(16)]
    [Header("��ų����")]
    public string Skill_Name; // ��ų �̸�
    public List<string> Lv_Text; // ��ų ���׷��̵� ����
    public int Skill_Icon; // �����ܹ�ȣ
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
