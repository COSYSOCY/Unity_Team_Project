using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkill_15 : Skill_Ori
{
    float Speed = 0;
    float UpTime =0;
    int UpCnt = 0;
    public GameObject bullet;
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
        UpTime = 1f;
        UpCnt = 10;
    }

    public override void LevelUpFunc()
    {
        //
        if (info.Lv==6) // 2������ �ɰ�� ����
        {
            Speed = 0;
        }
        if (info.Lv == 8) // 8������ �ɰ�� ����
        {
            //8 ���� ȹ��
            if (GameInfo.inst.Player_Mission[23] == 0)
            {
                GameInfo.inst.MissionGo(23);
            }
        }
    }

    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
    {
        
        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(27);
            yield return StartCoroutine(Skill_Update2());
            
        }
    }
    IEnumerator Skill_Update2()
    {
        int icheck = GameInfo.inst.PlayerCardCheck[59];
        float add= icheck * GameInfo.inst.CardsInfo[59].CardStat_Real1;
        float local = _AtRange() ;
        float Sp = Speed+_SkillReal3();
        int cnt= (int)_SkillReal1();
        MainSingleton.instance.playerinfo.Speed += Sp;
        bullet.SetActive(true);
        for (int i = 0; i < cnt+ UpCnt; i++)
        {
            Vector3 pos = bulletPos.transform.position;
            pos.y = 0;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_15", pos, Quaternion.identity);
            bullet.GetComponent<Bullet_Info>().damage = _Damage();
            bullet.GetComponent<Bullet_Info>().pie = _BulletPie() ;
            bullet.transform.localScale = new Vector3(local, local, local);
            bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime()+ UpTime);
            yield return new WaitForSeconds(_SkillReal2());
        }
        yield return new WaitForSeconds(_CoolSub1(false)+ add);
        bullet.SetActive(false);
        MainSingleton.instance.playerinfo.Speed -= Sp;

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
