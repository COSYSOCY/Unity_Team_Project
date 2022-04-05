using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_14 : Skill_Ori
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
            SoundManager.inst.SoundPlay(8);
        }
    }
    IEnumerator Skill_Update2()
    {
        float local = _AtRange();
        Vector3 pos = bulletPos.transform.position;
        pos.y = 0;
        Collider[] Enemys;
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_14", pos, Quaternion.identity);
        bullet.transform.localScale = new Vector3(local, local, local);
        Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x* local, layermask);
        if (Enemys.Length >0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
            }
        }

        yield return null;
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