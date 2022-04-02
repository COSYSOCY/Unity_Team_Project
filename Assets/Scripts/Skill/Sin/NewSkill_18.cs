using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_18 : Skill_Ori
{


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



        }
    }

    public Vector3 RandomSphereInPoint(float radius)
    {
        //Random.onUnitSphere : �ݰ� 1�� ���� ���� ǥ��󿡼� ������ ������ ��ȯ�մϴ�. (�б� ����)
        Vector3 getPoint = Random.onUnitSphere;
        getPoint.y = 0.0f;

        // 0.0f ���� ������ �������� ���� ������ ������ �� ����.
        float r = Random.Range(0.0f, radius);

        // ���� �� ��ġ��ŭ �����̵��� �ʿ��ϹǷ�. position�� �����ش�.
        return (getPoint * r) + Player.transform.position;
    }


    IEnumerator Skill_Update2()
    {
        float local = _AtRange();
        for (int i = 0; i < _BulletCnt(); i++)
        {
            Vector3 pos = RandomSphereInPoint(20f);
            pos.y = 0;
            Collider[] Enemys;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_18", pos, Quaternion.identity);
            bullet.transform.localScale = new Vector3(local, local, local);
            Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x * local, layermask);
            if (Enemys.Length > 0)
            {
                for (int a = 0; a < Enemys.Length; i++)
                {
                    Enemys[a].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
                }
            }

            yield return null;
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
