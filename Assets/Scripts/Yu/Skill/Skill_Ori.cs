using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ori : MonoBehaviour
{
    public int Index; // �ε���
    [Header("���� �ؾ��ϴºκ�")]
    public GameObject Player; //�÷��̾�
    public GameObject bulletPrefab; //�Ѿ�Prefab
    public Transform bulletPos;//�Ѿ˻�����ġ (���� �����Ǵ���ġ�� �ʿ��Ҷ� ���)
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

    public virtual void LevelUp()
    {

    }

}
