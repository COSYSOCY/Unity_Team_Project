using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : Skill_Ori
{
    
    public override void LevelUp()
    {
        // �������� ����Ǵ� �Լ��Դϴ�.
        // 0 �̰Ŵ� Ȱ��ȭ�Ǵ� �κ��̴ϱ� �Ѿ�ּ���
        switch (info.Lv)
        {
            case 0:
                //�ƹ��͵��ƴ�
                break;
            case 1:
                //����ü ����
                info.bulletCnt++;
                break;
            case 2:
                //����ü ����
                info.bulletCnt++;
                break;
            case 3:
                //����ü ����
                info.bulletCnt++;
                break;
            case 4:
                //����ü ����
                info.bulletCnt++;
                break;
            case 5:
                //����ü ����
                info.bulletCnt++;
                break;
            case 6:
                //����ü ����
                info.bulletCnt++;
                break;
            case 7:
                //����ü ����
                info.bulletCnt++;
                break;
            default:
                break;
        }

        info.Lv++;
    }

    void Start_Func() //���۽� ����
    {
        info.Lv = 1; //���� 1�� ����
        info.bulletCnt = 1; // ����ü �� 1�� ����
        info.Damage = 2f; // ������ 2�� ����

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
