using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_CJK : Skill_Ori
{
    void Start_Func()
    {
        LevelUp();
        manager.skill_Add(gameObject, info.Skill_Icon);
        StartCoroutine(Skill_Update());
    }



    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 1; i <= info.bulletCnt; i++)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("BulletJK", bulletPos.transform.position, bulletPos.transform.rotation);
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
            }
        }
    }
    private void OnEnable() // �ߺ������� ����ó���뽺ũ��Ʈ�ε� �Ű澲��������
    {
        if (start == false)
        {
            Start_Func();
            start = true;
        }
    }

}
