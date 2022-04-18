using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_1 : Skill_Ori
{
    string bulletname = "Bullet_1";
    int UpPie = 0;
    float UpSpeed = 0;
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
        UpPie = 1;
        bulletname = "Bullet_1_1";
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
        UpSpeed = 80f;
    }
    public override void LevelUpFunc()
    {
        //
        if (info.Lv==2) // 2������ �ɰ�� ����
        {

        }
        if (info.Lv == 8) // 8������ �ɰ�� ����
        {
            //8 ���� ȹ��
            if (GameInfo.inst.Player_Mission[7] == 0)
            {
                GameInfo.inst.MissionGo(7);
            }
        }
    }
    float damage()
    {
        float d = _Damage();
        int i = GameInfo.inst.PlayerCardCheck[40];
        //GameInfo.inst.CardsInfo[17].CardStat_Real1
        float d_C = 0;
        float d_P = i * GameInfo.inst.CardsInfo[40].CardStat_Real1;
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
            StartCoroutine(Skill_Update2());
           // SoundManager.inst.SoundPlay(6);
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();
        List<Collider> Enemys;
        Enemys = Physics.OverlapSphere(pos, 30f, layermask).ToList();
        Enemys.Sort(delegate (Collider t1, Collider t2) {
            return ((t1.transform.position - Player.transform.position).magnitude).CompareTo((t2.transform.position - Player.transform.position).magnitude);
        });

        if (Enemys.Count >0)
        {
            for (int i = 0; i < _BulletCnt(); i++)
            {
                SoundManager.inst.SoundPlay(8);
                GameObject target;
                if (i >= Enemys.Count)
                {
                    target = Enemys[0].gameObject;
                }
                else
                {
                    target = Enemys[i].gameObject;
                }
                pos = bulletPos.transform.position;
                pos.y = 1;
                Vector3 dir = target.transform.position - Player.transform.position;
                dir.Normalize();
                dir.y = 0;
                GameObject bullet = ObjectPooler.SpawnFromPool(bulletname, pos, Quaternion.LookRotation(dir));
                bullet.GetComponent<Bullet_Info>().damage = damage();
                bullet.GetComponent<Bullet_Info>().pie = _BulletPie()+UpPie;
                bullet.GetComponent<Bullet_Info>().move = _BulletSpeed() + UpSpeed ;
                bullet.GetComponent<Bullet_Info>().Destorybullet(_BulletTime());
                bullet.transform.localScale = new Vector3(local, local, local);
                yield return new WaitForSeconds(0.1f);
            }
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
