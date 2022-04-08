using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_18 : MonoBehaviour
{
    public Bullet_Info info;
    public float CulTime;
    public LayerMask layermask;
    private void OnEnable()
    {
        CulTime = 0;
    }
    private void Update()
    {
        CulTime+=Time.deltaTime;
        if (CulTime >= 0.5f)
        {
            CulTime=0;
            Collider[] Enemys;

            Enemys = Physics.OverlapSphere(transform.position, transform.lossyScale.x , layermask);
            if (Enemys.Length > 0)
            {
                for (int i = 0; i < Enemys.Length; i++)
                {
                    Enemys[i].transform.GetComponent<Enemy_Info>().Damaged(info.damage);
                    if (MainSingleton.instance.playerstat.SkillItemactive[18] >= 1)
                    {
                        Enemys[i].transform.GetComponent<Enemy_Info>().StunFunc(2f);
                    }
                }
            }
        }
    }
}
