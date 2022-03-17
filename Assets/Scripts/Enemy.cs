using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerStatus playerStatus;
    private Transform target;
    [SerializeField] private int hp = 100;
    private float enemyDmg = 10;
    private float atkDelay;
    private float atkCoolTime;
    private float moveSpeed = 5f;
    private bool isDead;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        EnemyTarget();
    }

    void EnemyTarget()
    {
        

        Vector3 dir = target.transform.position - gameObject.transform.position;
        Debug.Log(dir);
        transform.position = Vector3.MoveTowards(transform.position, dir, Time.deltaTime * moveSpeed);
        //transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }


}
