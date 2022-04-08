using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_35 : Skill_Ori
{
    float Upscale = 0f;
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
        Upscale = 5f;
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
    IEnumerator Skill_Update2()
    {
        float local = _AtRange() + Upscale;
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_35", pos, Quaternion.identity);
        bullet.transform.localScale = new Vector3(local, local, local);
        StartCoroutine(DamageFunc(_SkillReal1(), bullet));
        yield return null;
    }
    IEnumerator DamageFunc(float t,GameObject g)
    {
        yield return new WaitForSeconds(t);

        Collider[] Enemys;
        Enemys = Physics.OverlapSphere(g.transform.position, g.transform.lossyScale.x, layermask);
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
            }
        }
        g.SetActive(false);
        
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
