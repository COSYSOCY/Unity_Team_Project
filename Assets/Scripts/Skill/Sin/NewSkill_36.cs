using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_36 : Skill_Ori
{
    public GameObject bullet;
    public LineRenderer BLine;
    public GameObject Enemy;
    public bool IsFunc;

    void Start_Func() //���۽� ����
    {
        manager.skill_Add(gameObject, info.Skill_Icon);
        LevelUp();
        bulletPos = GameObject.Find("Skill36_Pos").transform;
        //StartCoroutine(Skill_Update2());
        StartCoroutine(Skill_Update4());
        StartCoroutine(Skill_Update3());
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
    float damage()
    {
        float d = _Damage();
        d = d + (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] * 3);
        return d;
    }
    //private void Update()
    //{
    //    if (Enemy ==null)
    //    {
    //        bullet.SetActive(false);
    //        List<Collider> Enemys = Physics.OverlapSphere(Player.transform.position, 10f, layermask).ToList();

    //        if (Enemys.Count >= 1)
    //        {
    //            int ran = Random.Range(0, Enemys.Count);
    //            Enemy = Enemys[ran].gameObject;
    //            bullet.SetActive(true);
    //            BLine.SetPosition(1, Enemy.transform.position);
    //            Debug.Log("ã��!");
    //        }
    //    }
    //    else
    //    {
    //        if (Enemy.activeSelf==false)
    //        {
    //            Enemy = null;
    //            bullet.SetActive(false);
    //        }
    //        else
    //        {
    //            bullet.SetActive(true);
    //            BLine.SetPosition(0, bulletPos.position);
    //            BLine.SetPosition(1, Enemy.transform.position);
    //        }
    //    }
    //}

    IEnumerator Skill_Update() // ���������� ����Ǵ� ��ũ��Ʈ
    {
        yield return null;
        while (Enemy !=null)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            StartCoroutine(Skill_Update2());
        }
    }
    IEnumerator Skill_Update2()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {

             
                if (Enemy = null)
            {
                bullet.SetActive(false);
                if (!IsFunc)
                {
                    IsFunc = true;
                    StartCoroutine(EnemyFunc());
                }
            }
            else
            {
                if (Enemy.activeSelf==false)
                {
                    Enemy = null;
                    bullet.SetActive(false);
                }
                else
                {

                bullet.SetActive(true);
                BLine.SetPosition(1, Enemy.transform.position);
                }

            }
            yield return null;
        }
    }
    IEnumerator EnemyFunc()
    {

        Debug.Log("ã����");
        List<Collider> Enemys = Physics.OverlapSphere(Player.transform.position, 10f, layermask).ToList();

        if (Enemys.Count >=1)
        {
            int ran = Random.Range(0, Enemys.Count);
            Enemy = Enemys[ran].gameObject;
            bullet.SetActive(true);
            BLine.SetPosition(1, Enemy.transform.position);
            Debug.Log("ã��!");
        }
        else
        {
            Enemy = null;
        }
            




        yield return new WaitForSeconds(0.5f);
        IsFunc = false;
    }
    IEnumerator Skill_Update3()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            
            if (Enemy != null&&Enemy.activeSelf)
            {
                Enemy.GetComponent<Enemy_Info>().Damaged(damage());
            }
            yield return new WaitForSeconds(_CoolMain(false));
            
        }
    }
    IEnumerator Skill_Update4()
    {
        float CoolTime = 0.5f;
        float CurlTime = 0f;
        yield return new WaitForSeconds(0.1f);
        while (true)
        {

            if (Enemy == null)
            {
                bullet.SetActive(false);
                CurlTime+=Time.deltaTime;
                if (CurlTime >= CoolTime)
                {

                    CurlTime = 0;
                List<Collider> Enemys = Physics.OverlapSphere(Player.transform.position, 15f, layermask).ToList();

                if (Enemys.Count >= 1)
                {
                    int ran = Random.Range(0, Enemys.Count);
                    Enemy = Enemys[ran].gameObject;
                    bullet.SetActive(true);
                    BLine.SetPosition(0, bulletPos.position);
                    BLine.SetPosition(1, Enemy.transform.position);
                    //Debug.Log("ã��!");
                }
                }
            }
            else
            {
                if (Enemy.activeSelf == false)
                {
                    Enemy = null;
                    bullet.SetActive(false);
                }
                else
                {
                    CurlTime = 0f;
                    if (Vector3.Distance(Enemy.transform.position,Player.transform.position)>20f)
                    {
                        Enemy = null;
                        bullet.SetActive(false);
                    }
                    else
                    {
                    bullet.SetActive(true);
                    BLine.SetPosition(0, bulletPos.position);
                    BLine.SetPosition(1, Enemy.transform.position);
                    }

                }
            }
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
