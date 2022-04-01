using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_9 : Skill_Ori
{


    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2������ �ɰ�� ����
        {

        }
    }


    void Start_Func()
    {
        LevelUp();
        manager.skill_Add(gameObject, info.Skill_Icon);
        StartCoroutine(Skill_Update());
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
        pos.y = 1;
        float local = _AtRange()*2f;
        List<Collider> Enemys = Physics.OverlapSphere(Player.transform.position, 30f, layermask).ToList();

            for (int i = 0; i < _BulletCnt(); i++)
            {
                int ran = Random.Range(0, Enemys.Count);
                GameObject target =  Enemys[ran].gameObject;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_9", target.transform.position, Quaternion.Euler(new Vector3(-90f,0f)));
            target.GetComponent<Enemy_Info>().Damaged(_Damage());
                    bullet.transform.localScale = new Vector3(local, local, local);

            if (Enemys.Count ==1)
            {
                yield break;
            }
                Enemys.RemoveAt(ran);


            }

        yield return null;
        
    }


    private void OnEnable()
    {
        if (start == false && info.goodstart)
        {
            Start_Func();
            start = true;
        }
    }
}
