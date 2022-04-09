using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_16 : Skill_Ori
{
    float Upscale = 0;
    void Start_Func() //���۽� ����
    {
        manager.skill_Add(gameObject,info.Skill_Icon);
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
        Upscale = 2f;
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
            SoundManager.inst.SoundPlay(28);
        }
    }
    Vector3 RandomPos()
    {
        float x = Random.Range(-11f, 11f);
        float z = Random.Range(-17f, 26f);
        Vector3 pos = new Vector3(Player.transform.position.x + x,1, Player.transform.position.z+z) ;
        return pos;
    }
    IEnumerator Skill_Update2()
    {

        float local = _AtRange()+ Upscale+1;

        for (int z = 0; z < _BulletCnt(); z++)
        {

        Collider[] Enemys;
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_16", RandomPos(), Quaternion.identity);
        bullet.transform.localScale = new Vector3(local, local, local);
        Enemys = Physics.OverlapSphere(bullet.transform.position, bullet.transform.lossyScale.x * local, layermask);
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
            }
        }

        yield return null;

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
