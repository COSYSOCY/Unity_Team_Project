using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBat : MonoBehaviour
{
    private Transform batPoolPos;

    private Transform target;
    private float atkDelay;
    private float atkCoolTime;
    //[SerializeField] private float moveSpeed;
    private bool isDead;
    public bool isOn = true;
    public Enemy_Info info;
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
    }
    public void CreateStart(float Hpc = 0f, float HpP = 0f)
    {
        float hp = info.Hp_Max + Hpc;
        hp = hp + (hp * HpP * 0.01f);
        StartCoroutine(UpdateEnemy());
        nav.speed = info.Speed*0.1f;
        info.Hp = hp;
        info.moveCheck = true;
        info.nav.speed = info.Speed * 0.1f;
        info.IsKn = false;
        info.IsStun = false;
        info.onhit = false;
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
        yield return null;
        //yield return new WaitForSeconds(0.2f);
    }
    void NavEnemy(Vector3 _target)
    {
        Vector3 endPos = _target + new Vector3(_target.x - transform.position.x * 2f, 1, _target.z - transform.position.z * 2f);
        nav.SetDestination(endPos);
    }
    IEnumerator MoveEnemy()
    {
        //nav.speed = moveSpeed;
        NavEnemy(target.position);
        yield return null;
    }
}
