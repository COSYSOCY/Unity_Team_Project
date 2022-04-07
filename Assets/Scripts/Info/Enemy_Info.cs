using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Info : MonoBehaviour
{
    public int Idx ;
    public float Hp;
    public float Hp_Max;
    public float Denfece;

    public float Speed;
    public float SpeedOri;
    public int ItemIdx;

    public GameObject TextUi;
    public Transform parentTransform;
    public UIManager uimanager;
    public PlayerStatus playerstatus;
    public float Enemy_Damage;
    public bool damagecheck;
    public GameObject player;
    public bool IsBoss;
    public bool NoPosReset;
    public bool moveCheck;
    public bool IsKn;
    public bool IsStun;
    //히트 점멸
    public SkinnedMeshRenderer[] enemyMat;
    //public SkinnedMeshRenderer[] enemyMat2;
    public bool onhit;
    public NavMeshAgent nav;

    public GameObject StunEffect;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerstatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        parentTransform = GameObject.Find("TextUi").GetComponent<Transform>();
        uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        //enemyMat = transform.GetChild(0).transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material;//히트점멸용 추가됨
        //uimanager=GameObject.Find("UIManager").GetComponent<UIManager>();
        Hp_Max = csvData.MonsterHp[Idx];
        Denfece = csvData.MonsterDefence[Idx];
        Speed = csvData.MonsterSpeed[Idx];
        SpeedOri = Speed;
        ItemIdx = csvData.MonsterItemIdx[Idx];
        Enemy_Damage = csvData.MonsterDamage[Idx];
    }

    private void OnEnable()
    {
        Hp = Hp_Max;
    }

    public void Damaged(float damage)
    {
         //히트 확인용 bool값
        StartCoroutine(EnemyHit());
        float f = damage;
        f = damage - Denfece;
        if (f < 1)
        {
            f = 1f;
        }
        //GameObject clone = Instantiate(TextUi);
        GameObject clone=null;

        if (!GameInfo.inst.PlayerDmg)
        {

        clone =ObjectPooler.SpawnFromPool("TextUi",transform.position);
        clone.transform.SetParent(parentTransform);
        Bounds bounds = GetComponent<Collider>().bounds;
        clone.GetComponent<UIHUDText>().Play(f.ToString("F0"), Color.red, bounds);

        }
        GameObject Effect = ObjectPooler.SpawnFromPool("Enemy_Hit", transform.position, Quaternion.identity);
        //SoundManager.inst.SoundPlay(5);
        Hp -= f;
        if (Hp <1 && gameObject.activeSelf)
        {
            Dead();
            uimanager.KillUp();
        }
    }

    public void Dead()
    {
        MainSingleton.instance.dropSystem.EnemyItemDrop(transform.position, Idx, ItemIdx);
        for (int i = 0; i < enemyMat.Length; i++)
        {
        enemyMat[i].material.SetColor("_EmissionColor", Color.black * 1f);
        }

        if (!IsBoss)
        {
        playerstatus.EnemyCnt--;

        }
        gameObject.SetActive(false);
        moveCheck = false;
            if (playerstatus.EnemyDestory[Idx] == true)
            {
                Destroy(gameObject);
            }




    }
    IEnumerator Damage(float dagame)
    {

        playerstatus.Hp_Damage(dagame);
        yield return new WaitForSeconds(0.2f);
        if (damagecheck==true)
        {
            StartCoroutine(Damage(Enemy_Damage));
        }
    }
    IEnumerator EnemyHit()
    {
        if (!onhit)
        {
            onhit = true;
            for (int i = 0; i < enemyMat.Length; i++)
            {
            enemyMat[i].material.SetColor("_EmissionColor", Color.white);

            }
            yield return new WaitForSeconds(0.15f); // 반짝이는 시간 
            for (int i = 0; i < enemyMat.Length; i++)
            {
            enemyMat[i].material.SetColor("_EmissionColor", Color.black);

            }
            onhit = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(Damage(Enemy_Damage));
            damagecheck = true;
        }
        if (other.transform.CompareTag("Check"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            damagecheck = false;
        }
        if (other.transform.CompareTag("Check"))
        {
           transform.GetChild(0).gameObject.SetActive(false);
        }

    }

    public void EnemyMove()
    {
        float range = Random.Range(28f, 29f);
        int ran = Random.Range(0, 360);
        float x = Mathf.Cos(ran) * 1f;
        float z = Mathf.Sin(ran) * 1f;
        Vector3 Pos = new Vector3(x, 0, z);
        Pos = player.transform.position + (Pos * range);
        Pos.y = 0;
        transform.position = Pos;



    }

    public bool IsTargetVisible(Transform _transform)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        var point = _transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < -1)
                return false;
        }
        return true;
    }
    //void Update()
    //{

    //    if (!IsTargetVisible(transform))
    //    {
    //        Debug.Log("안보임");
    //        transform.GetChild(0).gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        transform.GetChild(0).gameObject.SetActive(true);

    //    }
    //}

    public void KnockEnemy(float t)
    {
        if (!IsKn)
        {

        StartCoroutine(KnockbackFunc(t));
        }
    }
    public void StunFunc(float t)
    {
        if (!IsStun)
        {

            StartCoroutine(Stun(t));
        }
    }

    IEnumerator Stun(float t)
    {
        if (IsStun)
        {
            yield break;

        }
        StunEffect.SetActive(true);
        IsStun = true;
        float SpeedCheck = Speed;
        Speed = 0;


        yield return new WaitForSeconds(t);
        StunEffect.SetActive(false);
        Speed = SpeedCheck;
        IsStun = false;
    }

    IEnumerator KnockbackFunc(float t)
    {
        if (IsKn)
        {
            yield break;
        }
        IsKn = true;
        float SpeedCheck = Speed;
        float cultime = 0;
        float cooltime = t;
        yield return null;
        //Vector3 d = (player.transform.position - transform.position).normalized;
        //Speed = 0;
        //nav.isStopped = true;
        while (cultime <= cooltime)
        {
            cultime += Time.deltaTime;
            transform.Translate(Vector3.back * Time.deltaTime * 20);
            yield return null;
        }
        IsKn = false;
        //nav.isStopped = false;
        //Speed = SpeedCheck;
    }
    public void BossMove()
    {
        Vector3 _target = player.transform.position;
        Vector3 d=(_target-transform.position).normalized;
        d = d * 25f;
        d.y = 0;
        Vector3 endPos = _target + d;
        transform.position = endPos;
        transform.rotation = Quaternion.LookRotation(_target);
    }
    //private void OnBecameVisible()
    //{
    //    transform.GetChild(0).gameObject.SetActive(true);
    //    Debug.Log("보인다");
    //}
    //private void OnBecameInvisible()
    //{
    //    transform.GetChild(0).gameObject.SetActive(false);
    //    Debug.Log("안보인다");
    //}
}
