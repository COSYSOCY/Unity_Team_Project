using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ori : MonoBehaviour
{
    public GameObject Player; //�÷��̾�
    public GameObject bulletPrefab; //�Ѿ�Prefab
    public Transform bulletPos;//�Ѿ˻�����ġ (���� �����Ǵ���ġ�� �ʿ��Ҷ� ���)
    public Skill_Info info;
    public float Cool_Main;
    public float Cool_sub1;
    public float Cool_sub2;
    protected bool start = false;

    public virtual void LevelUp()
    {

    }

}
