using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : Skill_Ori
{
    
    void Start_Func() //���۽� ����
    {
        manager.skill_Add(gameObject,info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv==2) // 2������ �ɰ�� ����
        {

        }
    }

    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(Skill_Update2());
        }
    }
    float damage()
    {
        float f = _Damage();
        
        if (GameInfo.inst.PlayerCardCheck[8]>0)
        {
            f = f + (GameInfo.inst.PlayerCardCheck[8] * f);
        }
        return f;
    }
    IEnumerator Skill_Update2()
    {
        for (int i = 1; i <= _BulletCnt(); i++)
        {
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", bulletPos.transform.position, bulletPos.transform.rotation);
            bullet.GetComponent<Bullet_Info>().damage = damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
            if (i % 2 == 0)
            {
                bullet.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));
            }
            else
            {
                bullet.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnEnable() // �ߺ������� ����ó���뽺ũ��Ʈ�ε� �Ű澲��������
    {
        if (start==false&&info.goodstart)
        {
        Start_Func();
            start = true;
        }
    }

}
