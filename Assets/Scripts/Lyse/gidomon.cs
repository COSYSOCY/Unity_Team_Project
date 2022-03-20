using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gidomon : MonoBehaviour
{
    public GameObject BulletD;
    //GameObject par;    
    public int numberOfObjects = 20;
    public float radius = 5f;
    public float Dagame;

    void Start()
    {
        //�⵵������
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            //par = Instantiate(BulletD, pos, rot);
            GameObject par = ObjectPooler.SpawnFromPool("Bullet_12", pos, rot);
            par.transform.parent = gameObject.transform;// �⵵�� ������Ʈ�Ʒ� �ڽİ�ü�� ť�����
            par.GetComponent<Bullet_Trigger_5>().Damage = Dagame;
        }
    }
}
