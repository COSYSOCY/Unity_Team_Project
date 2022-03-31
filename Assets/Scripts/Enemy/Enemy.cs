using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //�������� ���� ��ġ
    public Transform enemyPoolPos;

    private Transform target;
    private float atkDelay;
    private float atkCoolTime;
    //[SerializeField] private float moveSpeed;
    private bool isDead;

    NavMeshAgent nav;
    public Enemy_Info info;
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
        // if (transform.parent != null)
        // transform.parent = transform.parent.parent;
        //nav.enabled = true;
        //
    }
    IEnumerator moveFunc()
    {
        while (true)
        {
            if (Vector3.Distance(target.position, transform.position) > 34f )
            {  //34�̻� �־����� ���ġ
                if (info.IsBoss)
                {
                    info.BossMove();

                }
                else
                {

                info.EnemyMove();
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    public void CreateStart()
    {
        StartCoroutine(UpdateEnemy());
        info.moveCheck = true;
        nav.speed = info.Speed*0.1f;
        if (!info.NoPosReset)
        {

        StartCoroutine(moveFunc()); 
        }
    }
    //SetDestination ���� �����κ�
    void OnDisable()
    {
        nav.gameObject.SetActive(false);
        //transform.GetComponent<NavMeshAgent>().gameObject.SetActive(false);
        nav.enabled = false;
        //Invoke("ReAttach", 0.01f);
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
        nav.enabled = true;
        while (!isDead)
        {
            StartCoroutine(EnemyTarget());
            //StartCoroutine(MoveEnemy());
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator EnemyTarget()
    {
        Vector3 dir = target.position - transform.position;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
        //transform.rotation= Quaternion.LookRotation(target.transform.position);
        //nav.speed = moveSpeed;
        NavEnemy(target.position);
        //yield return new WaitForSeconds(0.2f);
        yield return null;
    }
    IEnumerator MoveEnemy()
    {
        //nav.speed = moveSpeed;
        NavEnemy(target.position);
        yield return null;
    }
}