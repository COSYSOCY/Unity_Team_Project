using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkill_0 : Skill_Ori
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
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());
            //SoundManager.inst.SoundPlay(5);
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();
        for (int i = 1; i <= _BulletCnt(); i++)
        {
            
            
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_0", pos, bulletPos.transform.rotation);
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
            if (i % 2 == 0)
            {
                bullet.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));
                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
                bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                bullet.transform.localScale=new Vector3(local, local, local);
            }
            else
            {
                bullet.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));
                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
                bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                bullet.transform.localScale=new Vector3(local, local, local);
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
