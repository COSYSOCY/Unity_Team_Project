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

        if (!GameInfo.PlayerDmg)
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
    void ItemRespawn(int i) // 랜덤아이템생성
    {
        int itemRnd = Random.Range(0, 10);

        if (itemRnd <= 5)
        {
            if (i==1)
            {
                ObjectPooler.SpawnFromPool("item_xp_1", transform.position, transform.rotation);
            }
        }
    }
    public void Dead()
    {
    ItemRespawn(ItemIdx);

        playerstatus.EnemyCnt--;
        gameObject.SetActive(false);
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
    private void Update()
    {
        if ((player.transform.position - transform.position).magnitude > 30)
        {
            EnemyMove();
        }
    }
    void EnemyMove()
    {
        float range = Random.Range(25f, 27f);
        int ran = Random.Range(0, 360);
        float x = Mathf.Cos(ran) * 1f;
        float z = Mathf.Sin(ran) * 1f;
        Vector3 Pos = new Vector3(x, 0, z);
        Pos = player.transform.position + (Pos * range);
        transform.position = Pos;
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
