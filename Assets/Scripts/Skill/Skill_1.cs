using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : Skill_Ori
{
    
    public override void LevelUp()
    {
        // 레벨업시 실행되는 함수입니다.
        // 0 이거는 활성화되는 부분이니까 넘어가주세요
        switch (info.Lv)
        {
            case 0:
                //아무것도아님
                break;
            case 1:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 2:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 3:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 4:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 5:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 6:
                //투사체 증가
                info.bulletCnt++;
                break;
            case 7:
                //투사체 증가
                info.bulletCnt++;
                break;
            default:
                break;
        }

        info.Lv++;
    }

    void Start_Func() //시작시 설정
    {
        info.Lv = 1; //레벨 1로 설정
        info.bulletCnt = 1; // 투사체 수 1로 설정
        info.Damage = 2f; // 데미지 2로 설정

        StartCoroutine(Skill_Update());
    }



    IEnumerator Skill_Update() // 실질적으로 실행되는 스크립트
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 1; i <= info.bulletCnt; i++)
            {
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_1", bulletPos.transform.position, bulletPos.transform.rotation); 
                bullet.GetComponent<Bullet_Trigger_1>().Damage = info.Damage;
                    if (i % 2 == 0)
                    {
                        bullet.transform.Translate(new Vector3((i / 2) * -1, 0f, 0f));
                    }
                    else
                    {
                        bullet.transform.Translate(new Vector3((i / 2) * 1, 0f, 0f));
                    }
            }
        }
    }


    private void OnEnable() // 중복방지용 버그처리용스크립트인데 신경쓰지마세요
    {
        if (start==false)
        {
        Start_Func();
            start = true;
        }
    }

}
