using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_1 : Skill_Ori
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
            SoundManager.inst.SoundPlay(6);
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();
        List<Collider> Enemys;
        Enemys = Physics.OverlapSphere(pos, 30f, layermask).ToList();
        Enemys.Sort(delegate (Collider t1, Collider t2) {
            return ((t1.transform.position - Player.transform.position).magnitude).CompareTo((t2.transform.position - Player.transform.position).magnitude);
        });

        if (Enemys.Count >0)
        {
            for (int i = 0; i < _BulletCnt(); i++)
            {

                GameObject target;
                if (i >= Enemys.Count)
                {
                    target = Enemys[0].gameObject;
                }
                else
                {
                    target = Enemys[i].gameObject;
                }
                Vector3 dir = target.transform.position - Player.transform.position;
                dir.Normalize();
                dir.y = 0;
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", pos, Quaternion.LookRotation(dir));
                bullet.GetComponent<Bullet_Info>().damage = _Damage();
                bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
                bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                bullet.transform.localScale = new Vector3(local, local, local);
                yield return new WaitForSeconds(0.1f);
            }
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
