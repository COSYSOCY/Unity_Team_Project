using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBat : MonoBehaviour
{
    private Transform batPoolPos;

    private Transform target;
    private int hp = 100;
    private int enemyDmg = 20;
    private float atkDelay;
    private float atkCoolTime;
    [SerializeField] private float moveSpeed;
    private bool isDead;
    public bool isOn = true;

    NavMeshAgent nav;

    private Renderer enemyColor;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        enemyColor = gameObject.GetComponent<Renderer>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        batPoolPos = GameObject.Find("BatList").GetComponent<Transform>();

    }
    //SetDestination ©ö?¡¾¡¿ ¨ù??¢´¨¬?¨¬¨¢
    private void OnEnable()
    {
        //if (transform.parent != null)
        // transform.parent = transform.parent.parent;
        //
        StartCoroutine(UpdateEnemy());
    }
    void OnDisable()
    {
        nav.enabled = false;
        //Invoke("ReAttach", 1f);
    }
    void ReAttach()
    {
        gameObject.transform.SetParent(batPoolPos.transform);
        transform.position = Vector3.zero;
    }
    // --------------------

    IEnumerator UpdateEnemy()
    {
        yield return new WaitForSeconds(0.2f);
        nav.enabled = true;
        StartCoroutine(MoveEnemy());
        while (!isDead)
        {
            StartCoroutine(EnemyTarget());
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator EnemyTarget()
    {
        Vector3 dir = target.position - transform.position;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
        yield return new WaitForSeconds(0.2f);
    }
    void NavEnemy(Vector3 _target)
    {
        Vector3 endPos = _target + new Vector3(_target.x - transform.position.x * 2f, 1, _target.z - transform.position.z * 2f);
        nav.SetDestination(endPos);
    }
    IEnumerator MoveEnemy()
    {
        nav.speed = moveSpeed;
        NavEnemy(target.position);
        yield return null;
    }
}
