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
        //시작시 설정
        info.Lv = 1;                

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update() //범위 공격
    {
        float Range = 5f;
        while (true)
        {            
            yield return new WaitForSeconds(100f);
            Collider[] hits = Physics.OverlapSphere(Player.transform.position, Range);//플레이어 위치에 범위(40)내에 오브젝트 배열로 받기                            
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
