using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_17 : Skill_Ori
{
    float Radius;
    public GameObject bullet;

    void Start_Func() //���۽� ����
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
        bullet.SetActive(true);

        //

        Radius = 5f; // �Ÿ�

        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {

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
           
            bullet.SetActive(true);
            StartCoroutine(Skill_Update2());
            StartCoroutine(Skill_Update3());



        }
    }
    IEnumerator Skill_Update3()
    {
        yield return new WaitForSeconds(_CoolSub1(false));
        bullet.SetActive(false);
        SoundManager.inst.SoundPlay(15);
    }
    IEnumerator Skill_Update2()
    {
        for (int i = 0; i < _BulletCnt(); i++)
        {
            float angle = i * Mathf.PI * 2 / _BulletCnt();
            float x = Mathf.Cos(angle) * Radius;
            float z = Mathf.Sin(angle) * Radius;
            Vector3 pos = bullet.transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            //par = Instantiate(BulletD, pos, rot);
            GameObject par = ObjectPooler.SpawnFromPool("Bullet_17", pos, rot);
            par.transform.parent = bullet.gameObject.transform;// �⵵�� ������Ʈ�Ʒ� �ڽİ�ü�� ť�����
            par.GetComponent<Bullet_Info>().damage = _Damage();
            par.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
        }
        yield return null;
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
