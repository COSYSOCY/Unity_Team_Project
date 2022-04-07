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


        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
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

    Vector3 RandomPos()
    {
        float x = Random.Range(-11f, 11f);
        float z = Random.Range(-17f, 26f);
        Vector3 pos = new Vector3(x, 1, z);
        return pos;
    }
    IEnumerator Skill_Update2()
    {

        float local = _AtRange();

        for (int z = 0; z < _BulletCnt(); z++)
        {
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_18", RandomPos(), Quaternion.identity);
            bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
            bullet.transform.localScale = new Vector3(local, local, local);

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
