using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public PlayerStatus playerStatus;
    private Transform target;
    [SerializeField] private int hp = 100;
    private float enemyDmg = 10;
    private float atkDelay;
    private float atkCoolTime;
    private float moveSpeed = 2.5f;
    private bool isDead;

    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        
        StartCoroutine(UpdateEnemy());
    }

    void NavEnemy(Vector3 _target)
    {
        nav.SetDestination(_target);
    }

    IEnumerator UpdateEnemy()
    {
        while (!isDead)
        {
            StartCoroutine(EnemyTarget());
            StartCoroutine(MoveEnemy());
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator EnemyTarget()
    {
        Vector3 dir = target.position - transform.position;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator MoveEnemy()
    {
        nav.speed = moveSpeed;
        NavEnemy(target.position);
        yield return null;
    }

}
