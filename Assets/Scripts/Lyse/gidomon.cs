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
        //기도문생성
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
            par.transform.parent = gameObject.transform;// 기도문 오브젝트아래 자식객체로 큐브생성
            par.GetComponent<Bullet_Trigger_5>().Damage = Dagame;
        }
    }
}
