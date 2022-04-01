using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_3 : Skill_Ori
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
        }
    }
    IEnumerator Skill_Update2()
    {
        Vector3 pos = bulletPos.transform.position;
        pos.y = 0;
        float local = _AtRange();
        List<Collider> Enemys;
        Vector3 endpos;
        Enemys = Physics.OverlapSphere(pos, 30f, layermask).ToList();

        if (Enemys.Count >0)
        {
            for (int i = 0; i < _BulletCnt(); i++)
            {

                GameObject target;
                int ran=Random.Range(0, Enemys.Count);
                target = Enemys[ran].gameObject;


                GameObject laser = ObjectPooler.SpawnFromPool("Bullet_3", pos, Quaternion.identity);
                laser.transform.localScale = new Vector3(local, local, local);
                Vector3 d = target.transform.position - Player.transform.position;
                d.Normalize();
                d.y = 0f;
                endpos = d * 50;
                laser.GetComponent<LineRenderer>().SetPosition(0, Player.transform.position);
                laser.GetComponent<LineRenderer>().SetPosition(1, endpos);

                RaycastHit[] Rhits = Physics.SphereCastAll(Player.transform.position, laser.transform.lossyScale.x, d,layermask);

                if (Rhits.Length > 0)
                {
                    for (int s = 0; s < Rhits.Length; s++)
                    {
                        if (Rhits[i].transform.gameObject.activeSelf)
                        {
                            Rhits[i].transform.GetComponent<Enemy_Info>().Damaged(_Damage());
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