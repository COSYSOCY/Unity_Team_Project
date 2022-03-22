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
    private void Start()
    {
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
    void ItemRespawn() // ���������ۻ���
    {
        int itemRnd = Random.Range(0, 10);

        if (itemRnd <= 5)
        {
                ObjectPooler.SpawnFromPool("item_xp_1", transform.position, transform.rotation);
        }
    }
    public void Dead()
    {
        //����
        
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
    }
}
