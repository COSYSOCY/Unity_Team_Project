using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSkill_37 : Skill_Ori
{
    int UpCnt=0;

    public override void LevelUpFunc()
    {
        //
        if (info.Lv == 2) // 2레벨이 될경우 실행
        {

        }
    }


    void Start_Func()
    {
        LevelUp();
        manager.skill_Add(gameObject, info.Skill_Icon);
        StartCoroutine(Skill_Update());
        if (MainSingleton.instance.playerstat.SkillItemactive[info.SkillCreateIdx] >= 1)
        {
            MainSingleton.instance.skillmanager.All_Skill_Items[info.SkillCreateIdx].GetComponent<Skill_Item_Ori>().CreateFunc();
            CreateFunc();
        }
    }
    public override void CreateFunc()
    {
        UpCnt = 4;
        manager.FoucsOb[info.ActiveIdx].SetActive(true);
    }
    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {

        while (true)
        {
            CoolTimesystem.NextFunc(_CoolMain(true));
            yield return new WaitForSeconds(_CoolMain(true));
            SoundManager.inst.SoundPlay(15);

                StartCoroutine(Skill_Update2());

        }
    }
    
    IEnumerator Skill_Update2()
    {

        Vector3 pos = bulletPos.transform.position;
        pos.y = 1;
        float local = _AtRange();
        List<Collider> Enemys = Physics.OverlapSphere(Player.transform.position, 20f, layermask).ToList();

        for (int i = 0; i < _BulletCnt()+ UpCnt; i++)
        {
            int ran = Random.Range(0, Enemys.Count);
            GameObject target = Enemys[ran].gameObject;
            GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_37", target.transform.position, Quaternion.Euler(new Vector3(-90f, 0f)));
            target.GetComponent<Enemy_Info>().Damaged(_Damage());
            bullet.transform.localScale = new Vector3(local, local, local);

            if (Enemys.Count == 1)
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
