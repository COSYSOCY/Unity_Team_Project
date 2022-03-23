using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_16 : Skill_Ori
{
    
    public override void LevelUp()
    {
        switch (info.Lv)
        {
            case 0:
                
                break;
            case 1:
                info.bulletCnt++;
                break;
            case 2:
                info.bulletCnt++;
                break;
            case 3:
                info.bulletCnt++;
                break;
            case 4:
                info.bulletCnt++;
                break;
            case 5:
                info.bulletCnt++;
                break;
            case 6:
                info.bulletCnt++;
                break;
            case 7:
                info.bulletCnt++;
                break;
            default:
                break;
        }

        info.Lv++;
    }

    void Start_Func()
    {
        //���۽� ����
        info.Lv = 1;                

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update() //���� ����
    {
        float Range = 5f;
        while (true)
        {            
            yield return new WaitForSeconds(100f);
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//�÷��̾� ��ġ�� ����(40)���� ������Ʈ �迭�� �ޱ�                            
            foreach(Collider col in hits)
            {
                Enemy_Info enemy = col.GetComponent<Enemy_Info>();
                if(enemy !=null)
                {            
                    enemy.Dead();                                       
                }
            }
           
        }
    }


    private void OnEnable()
    {
        if (start == false)
        {
            Start_Func();
            start = true;
        }
    }
    
    
}
