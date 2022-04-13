using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_5 : Skill_Ori
{
    float UpCntX=1f;
    public LayerMask bossmask;
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
        UpCntX = 2f;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2������ �ɰ�� ����
        {

        }
        if (info.Lv == 8) // 8������ �ɰ�� ����
        {
            //8 ���� ȹ��
            if (GameInfo.inst.Player_Mission[10] == 0)
            {
                GameInfo.inst.Player_Mission[10] = 1;
            }
        }
    }
    float damage()
    {
        float d = _Damage();
        int i = GameInfo.inst.PlayerCardCheck[75];
        //GameInfo.inst.CardsInfo[17].CardStat_Real1
        float d_C = 0;
        float d_P = i * GameInfo.inst.CardsInfo[75].CardStat_Real1;
        d = d + d_C;
        d = d + (d * d_P * 0.01f);

        return d;
    }
    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
    {

        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(12);
            yield return Skill_Update2();
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
        for (int i = 0; i < _BulletCnt()*UpCntX; i++)
        {
            

            


            
            Vector3 dir = target.transform.position - Player.transform.position ;
            dir.Normalize();
            dir.y = 0;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_5", pos, Quaternion.LookRotation(dir));
            //bullet.transform.LookAt(target.transform);
            bullet.GetComponent<Bullet_Info>().damage = damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie();
            bullet.GetComponent<Bullet_Info>().move = _BulletSpeed();
            bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());

            bullet.transform.localScale = new Vector3(local, local, local);
                yield return new WaitForSeconds(0.1f);
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
