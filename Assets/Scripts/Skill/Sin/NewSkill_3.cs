using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_3 : Skill_Ori
{
    float UpRange;


    public GameObject partic1;
    public GameObject bullet;
    void Start_Func() //���۽� ����
    {
            SoundManager.inst.SoundPlay(10);
        manager.skill_Add(gameObject,info.Skill_Icon);
        LevelUp();
        StartCoroutine(Skill_Update());
        
        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
        else
        {
            bullet.SetActive(true);
        }
    }
    public override void CreateFunc()
    {

            bullet.gameObject.SetActive(false);
            partic1.gameObject.SetActive(true);
        UpRange = 2;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
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
            yield return new WaitForSeconds(_CoolMain(false));

            float ar = _AtRange();

            StartCoroutine(Skill_Update2());
        }
        

    }
    IEnumerator Skill_Update2()
    {

        Vector3 pos = bulletPos.transform.position;
        pos.y = 0;
        Collider[] Enemys;
        Enemys = Physics.OverlapSphere(Player.transform.position, Player.transform.lossyScale.x*_AtRange()+ UpRange, layermask);
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
