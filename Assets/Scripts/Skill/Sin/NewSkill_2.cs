using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_2 : Skill_Ori
{
    string bulletname = "Bullet_2";
    float Upcool = 1f;
    public LayerMask DmgLayermask;
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
        bulletname = "Bullet_2_1";
        Upcool = 0.5f;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
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
            if (GameInfo.inst.Player_Mission[9] == 0)
            {
                GameInfo.inst.MissionGo(9);
            }
        }
    }

    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
    {
        
        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true) * Upcool);
            yield return new WaitForSeconds(_CoolMain(true)*Upcool);
            SoundManager.inst.SoundPlay(9);
            StartCoroutine(Skill_Update2());
        }
    }
    IEnumerator Skill_Update2()
    {

        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();
        List<Collider> Enemys;
        Vector3 endpos;
        Enemys = Physics.OverlapSphere(pos, 30f, layermask).ToList();

        if (Enemys.Count >0)
        {
            for (int i = 0; i < _BulletCnt()+ GameInfo.inst.PlayerCardCheck[76]; i++)
            {

                GameObject target;
                int ran=Random.Range(0, Enemys.Count);
                target = Enemys[ran].gameObject;


                
                
                GameObject laser = ObjectPooler.SpawnFromPool(bulletname, pos, Quaternion.identity);
                laser.transform.localScale = new Vector3(local, local, local);
                Vector3 d = (target.transform.position - laser.transform.position).normalized;



                endpos = target.transform.position+(d * 30);
                endpos.y = 1f;

                laser.GetComponent<LineRenderer>().SetPosition(0, pos);
                laser.GetComponent<LineRenderer>().SetPosition(1, endpos);
                RaycastHit[] Rhits = Physics.SphereCastAll(pos, laser.transform.lossyScale.x,d,30f,DmgLayermask);

                if (Rhits.Length > 0)
                {
                    for (int s = 0; s < Rhits.Length; s++)
                    {
                      
                        if (Rhits[s].transform.gameObject.activeSelf)
                        {
                            //if (Rhits[i].transform.CompareTag("DeOb"))
                            //{
                            //    Rhits[i].transform.GetComponent<DeObjectSystem>().Damaged(_Damage());
                            //}
                            //else
                            //{

                            Rhits[s].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
                            //
                        }
                    }
                }



                
                if (Enemys.Count != 1)
                {
                    Enemys.RemoveAt(ran);
                    yield return new WaitForSeconds(0.1f);
                }
                
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
