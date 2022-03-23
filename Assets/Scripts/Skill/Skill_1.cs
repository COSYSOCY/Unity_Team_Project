using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : Skill_Ori
{
    
    void Start_Func() //���۽� ����
    {
        playerinfo.SkillCnt++;
        manager.Skill_All_Active.Add(gameObject);
        manager.Skill_Active.Add(gameObject);
        LevelUp();
        StartCoroutine(Skill_Update());
    }



    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 1; i <= info.bulletCnt; i++)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", bulletPos.transform.position, bulletPos.transform.rotation); 
                bullet.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;
                    if (i % 2 == 0)
                    {
                        bullet.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));
                    }
                    else
                    {
                        bullet.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));
                    }
            }
        }
    }


    private void OnEnable() // �ߺ������� ����ó���뽺ũ��Ʈ�ε� �Ű澲��������
    {
        if (start==false)
        {
        Start_Func();
            start = true;
        }
    }

}
