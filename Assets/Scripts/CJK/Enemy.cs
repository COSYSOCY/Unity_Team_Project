using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //리스폰을 위한 위치
    public Transform enemyPoolPos;

    private Transform target;
    private int hp = 100;
    private int enemyDmg = 20;
    private float atkDelay;
    private float atkCoolTime;
    [SerializeField] private float moveSpeed;
    private bool isDead;

    NavMeshAgent nav;

    private Renderer enemyColor;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        enemyColor = gameObject.GetComponent<Renderer>();
        enemyPoolPos = GameObject.Find("EnemyList").GetComponent<Transform>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void OnEnable()
    {
        if (transform.parent != null)
            transform.parent = transform.parent.parent;
        StartCoroutine(UpdateEnemy());
    }
    //SetDestination 버그 수정부분
    void OnDisable()
    {

        Invoke("ReAttach", 0.01f);
    }
    void ReAttach()
    {
        gameObject.transform.SetParent(enemyPoolPos.transform);
        transform.SetAsLastSibling();
    }
    // --------------------
    void NavEnemy(Vector3 _target)
    {
        nav.SetDestination(_target);
    }
    IEnumerator UpdateEnemy()
    {
        yield return new WaitForSeconds(0.2f);
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