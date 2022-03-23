using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ori : MonoBehaviour
{
    public PlayerInfo playerinfo;
    public GameObject Player; //�÷��̾�
    public GameObject bulletPrefab; //�Ѿ�Prefab
    public SkillManager manager;
    public Transform bulletPos;//�Ѿ˻�����ġ (���� �����Ǵ���ġ�� �ʿ��Ҷ� ���)
    public Skill_Info info;
    public float Cool_Main;
    public float Cool_sub1;
    public float Cool_sub2;
    protected bool start = false;


    /*
float _Damage() // ������
int _BulletCnt() // ����ü��
float _BulletSpeed() // ����ü�̵��ӵ�
int _BulletPie() // ����ü����
float _BulletAtCri() // ũ��Ȯ��
float _CoolMain(bool b) // b�� true�̸� ������
float _CoolSub1(bool b) // b�� true�̸� ������
float _CoolSub2(bool b) // b�� true�̸� ������
float _AtRange() // ���ݹ����ε� ������� ������ �̰ɷ� ũ�⸦ �����ϴ¹���?
float _SkillReal1() // �Ǽ�1 ���� �����һ����
float _SkillReal2() // �Ǽ�2 ���� �����һ����
float _SkillReal3() // �Ǽ�3 ���� �����һ����
---
�̹��� info.�ٿ��� ����մϴ� �������
int Lv; // ����
int Index; // �ε���
int bulletCntMax; // ����ü �ִ밹��
���� ( info.bulletCntMax )
     */

    protected float _Damage()
    {
        float d;
        d= Random.Range(info.DamageMin, info.DamageMax);
        d = d + (d * (GameInfo.DamagePlus * 0.01f));
        return d;
    }

    protected int _BulletCnt()
    {
        int i;
        i = info.bulletCnt + GameInfo.BulletCntPlus;
        return i;
    }
    protected float _BulletSpeed()
    {
        float d;
        d = Random.Range(info.DamageMin, info.DamageMax);
        d = d + (d * (GameInfo.BulletSpeedPlus * 0.01f));
        return d;
    }
    protected int _BulletPie()
    {
        int i;
        i = info.BulletPie ;
        return i;
    }

    protected float _BulletAtCri()
    {
        float f;
        f = info.BulletAtCri;
        return f;
    }
    protected float _CoolMain(bool b) // b �� true�� �� ����
    {
         float f;
         float f2;
        f = info.CoolMain;
        if (!b)
        {
            return f;
        }
        
        f2 = GameInfo.SkillCoolPlus;//���߿� ��ű� �߰��Ҳ�
        Mathf.Clamp(f2, 0, 50f);
        f2 = (100 - f2)*0.01f;
        f *= f2;
        return f;
    }
    protected float _CoolSub1(bool b) // b �� true�� �� ����
    {
        float f;
        float f2;
        f = info.CoolSub1;
        if (!b)
        {
            return f;
        }

        f2 = GameInfo.SkillCoolPlus;//���߿� ��ű� �߰��Ҳ�
        Mathf.Clamp(f2, 0, 50f);
        f2 = (100 - f2) * 0.01f;
        f *= f2;
        return f;
    }
    protected float _CoolSub2(bool b) // b �� true�� �� ����
    {
        float f;
        float f2;
        f = info.CoolSub2;
        if (!b)
        {
            return f;
        }

        f2 = GameInfo.SkillCoolPlus;//���߿� ��ű� �߰��Ҳ�
        Mathf.Clamp(f2, 0, 50f);
        f2 = (100 - f2) * 0.01f;
        f *= f2;
        return f;
    }
    protected float _AtRange()
    {
        float f;
        f = info.AtRange;
        return f;
    }

    protected float _SkillReal1()
    {
        float f;
        f = info.SkillReal1;
        return f;
    }
    protected float _SkillReal2()
    {
        float f;
        f = info.SkillReal2;
        return f;
    }
    protected float _SkillReal3()
    {
        float f;
        f = info.SkillReal3;
        return f;
    }
    public void LevelUp()
    {
        

        info.Lv++;
        info.DamageMin = info.DamageCheckMin[info.Lv];
        info.DamageMax = info.DamageCheckMax[info.Lv];
        info.bulletCnt = info.BulletCntCheck[info.Lv];
        info.bulletCntMax = info.BulletCntMaxCheck[info.Lv];
        info.BulletSpeed = info.DamageCheckMin[info.Lv];
        info.BulletPie = info.BulletPieCheck[info.Lv];
        info.BulletAtCri = info.BulletAtCriCheck[info.Lv];
        info.CoolMain = info.CoolMainCheck[info.Lv];
        info.CoolSub1 = info.CoolSub1Check[info.Lv];
        info.CoolSub2 = info.CoolSub2Check[info.Lv];
        info.AtRange = info.AtRangeCheck[info.Lv];
        info.SkillReal1 = info.SkillReal1Check[info.Lv];
        info.SkillReal2 = info.SkillReal2Check[info.Lv];
        info.SkillReal3 = info.SkillReal3Check[info.Lv];

    }

}
