using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_14 : Skill_Ori
{



    public override void LevelUp()
    {
        switch (info.Lv)
        {
            case 0:
                //�ƹ��͵��ƴ�
                break;
            case 1:
                //..;
                break;
            case 2:
                //..;
                break;
            case 3:
                //..
                break;
            case 4:
                //.
                break;
            case 5:
                //.
                break;
            case 6:
                //.
                break;
            case 7:
                //.
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
        info.bulletCnt = 1;
        info.Damage = 1f;

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject bullet = Instantiate(bulletPrefab, Player.transform.position, Quaternion.identity);

            // �̻��� ������ y������ 0~360 �����ϰ� ����
            //Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            bullet.transform.rotation = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
            //rigid.velocity = bulletPos.forward.normalized * 20f;

        }
    }


    private void OnEnable()
    {
        if (start==false)
        {
        Start_Func();
            start = true;
        }
    }
}