using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ori : MonoBehaviour
{
    public GameObject Player; //�÷��̾�
    public GameObject bulletPrefab; //�Ѿ�Prefab
    public Transform bulletPos;//�Ѿ˻�����ġ (���� �����Ǵ���ġ�� �ʿ��Ҷ� ���)
    public Skill_Info info;
    protected bool start = false;

    public virtual void LevelUp()
    {

    }

}
