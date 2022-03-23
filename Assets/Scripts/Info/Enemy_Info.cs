using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Info : MonoBehaviour
{
    public int Idx ;
    public float Hp;
    public float Hp_Max;
    public enum Enemy_ENUM
    {
        none=0,
        Enemy_1,
        bat,
    }
    public Enemy_ENUM enemy_enum;
    public GameObject[] itemprefabs;
    public GameObject TextUi;
    public Transform parentTransform;
    public UIManager uimanager;
    public PlayerStatus playerstatus;
    public float Enemy_Damage;
    public bool damagecheck;
    public GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        playerstatus =GameObject.Find("Player").GetComponent<PlayerStatus>();
        parentTransform =GameObject.Find("TextUi").GetComponent<Transform>();
        uimanager=GameObject.Find("UIManager").GetComponent<UIManager>();
        //uimanager=GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void OnEnable()
    {
        Hp = Hp_Max;
    }

    public void Damaged(float damage)
    {
        //GameObject clone = Instantiate(TextUi);
        GameObject clone = ObjectPooler.SpawnFromPool("TextUi",transform.position);
        clone.transform.SetParent(parentTransform);
        Bounds bounds = GetComponent<Collider>().bounds;
        clone.GetComponent<UIHUDText>().Play(damage.ToString("F0"), Color.red, bounds);

        Hp -= damage;
        if (Hp <1 && gameObject.activeSelf)
        {
            Dead();
            uimanager.KillUp();
        }
    }
    void ItemRespawn() // 랜덤아이템생성
    {
        int itemRnd = Random.Range(0, 10);

        if (itemRnd <= 5)
        {
                ObjectPooler.SpawnFromPool("item_xp_1", transform.position, transform.rotation);
        }
    }
    public void Dead()
    {
        //죽음
        
        switch (enemy_enum)
        {
            case Enemy_ENUM.none:
                break;
            case Enemy_ENUM.Enemy_1:
                ItemRespawn();
                break;
            case Enemy_ENUM.bat:
                ItemRespawn();
                break;
            default:
                break;
        }
        playerstatus.EnemyCnt--;
        gameObject.SetActive(false);
            if (playerstatus.EnemyDestory[Idx] == true)
            {
                Destroy(gameObject);
            }
    }
    IEnumerator Damage(float dagame)
    {
        damagecheck = true;
        playerstatus.HpPlus(-dagame);
        yield return new WaitForSeconds(0.5f);
        damagecheck = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")&& damagecheck==false)
        {
            StartCoroutine(Damage(Enemy_Damage));
        }
        if (other.transform.CompareTag("Check"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Check"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void Update()
    {   
        if ((player.transform.position - transform.position).magnitude > 30)
        {  //30이상 멀어지면 재배치
            EnemyMove();
        }
        if ((player.transform.position - transform.position).magnitude > 30 && gameObject.CompareTag("FieldBoss"))
        {  //30이상 멀어지면서 테그가 FieldBoss면 재배치
            BossMove();
        }

    }
    void EnemyMove()
    {   
        float range = Random.Range(25f, 30f);
        int ran = Random.Range(0, 360);
        float x = Mathf.Cos(ran) * 1f;
        float z = Mathf.Sin(ran) * 1f;
        Vector3 Pos = new Vector3(x, 0, z);
        Pos = player.transform.position + (Pos * range);
        transform.position = Pos;
    }
    void BossMove()
    {
        Vector3 _target = player.transform.position;
        Vector3 endPos = _target + new Vector3(_target.x - (transform.position.x * 0.9f), 1, _target.z - (transform.position.z * 0.9f));
        transform.position = endPos;
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
