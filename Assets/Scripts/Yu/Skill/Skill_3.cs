using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_3 : Skill_Ori
{



    public override void LevelUp()
    {
        switch (Lv)
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

        Lv++;
    }

    void Start_Func()
    {
        //���۽� ����
        Lv = 1;
        bulletCnt = 1;
        Damage = 1f;

        StartCoroutine(Skill_Update());
    }


    IEnumerator Skill_Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 30; i++)
            {

                GameObject bullet2 = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
                Rigidbody rigid2 = bullet2.GetComponent<Rigidbody>();
                rigid2.velocity = bulletPos.forward.normalized * 10f;
                yield return new WaitForSeconds(0.15f);
            }
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
