using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Info : MonoBehaviour
{
    public int Idx ;
    public float Hp;
    public float Hp_Max;
    public float Denfece;

    public float Speed;
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

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerstatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        parentTransform = GameObject.Find("TextUi").GetComponent<Transform>();
        uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        //uimanager=GameObject.Find("UIManager").GetComponent<UIManager>();
        Hp_Max = csvData.MonsterHp[Idx];
        Denfece = csvData.MonsterDefence[Idx];
        Speed = csvData.MonsterSpeed[Idx];
        ItemIdx = csvData.MonsterItemIdx[Idx];
        Enemy_Damage = csvData.MonsterDamage[Idx];
    }

    private void OnEnable()
    {
        Hp = Hp_Max;
    }

    public void Damaged(float damage)
    {
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
        yield return new WaitForSeconds(0.35f);
        if (damagecheck==true)
        {
            StartCoroutine(Damage(Enemy_Damage));
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




    public void BossMove()
    {
        Vector3 _target = player.transform.position;
        Vector3 endPos = _target + new Vector3((_target.x-transform.position.x)*0.8f , 2, (_target.z- transform.position.z)*0.8f );
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
