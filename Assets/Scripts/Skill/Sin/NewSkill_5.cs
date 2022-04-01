using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_5 : Skill_Ori
{
    public LayerMask bossmask;
    void Start_Func() //���۽� ����
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2������ �ɰ�� ����
        {

        }

    }

    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
    {

        while (true)
        {
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());
            SoundManager.inst.SoundPlay(10);
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _SkillReal1();
        Collider[] Enemys_Boss = Physics.OverlapSphere(Player.transform.position, 30f, bossmask);
        Collider[] Enemys = Physics.OverlapSphere(Player.transform.position, 30f, layermask);
        int ran = Random.Range(0, Enemys.Length);
        GameObject target = null;
        if (Enemys_Boss.Length > 0)
        {
            target = Enemys_Boss[0].gameObject;
        }
        else
        {


            if (Enemys.Length > 0)
            {

                target = Enemys[ran].gameObject;
            }
        }
        if (target == null)
        {
            yield break;
        }
        for (int i = 0; i < _BulletCnt(); i++)
        {
            

            


            
            Vector3 dir = target.transform.position - Player.transform.position ;
            dir.Normalize();
            dir.y = 0;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_5", pos, Quaternion.LookRotation(dir));
            //bullet.transform.LookAt(target.transform);
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
            bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
            bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());

            bullet.transform.localScale = new Vector3(local, local, local);
                yield return new WaitForSeconds(0.15f);
        }
    }

    private void OnEnable() // �ߺ������� ����ó���뽺ũ��Ʈ�ε� �Ű澲��������
    {
        if (start == false && info.goodstart)
        {
            Start_Func();
            start = true;
        }
    }

}
