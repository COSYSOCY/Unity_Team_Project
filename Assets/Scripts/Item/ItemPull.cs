using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemPull : MonoBehaviour
{
    public GameObject Player;
    public GameObject itemprefabs;    
    public float speed = 10f;
    public Levelstatus levelstatus;
    public PlayerStatus playerstatus;
    public int item_stat;
    public bool pullcheck=false;
    public bool playcolcheck = false;
    public enum Item_ENUM
    {
        gold=0,
        XP=1,
        HP=2,
    };
    public Item_ENUM item_enum;

    private void Start()
    {
        levelstatus = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Levelstatus>();
        Player = GameObject.FindGameObjectWithTag("Player");
        itemprefabs = GameObject.FindGameObjectWithTag("Item");
        playerstatus=Player.GetComponent<PlayerStatus>();
    }



    //딸려온 오브젝트가 파괴되면 경험치올라옴
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("체크");
        if (other.transform.CompareTag("Player")&& playcolcheck)
        {
            switch (item_enum)
            {
                case Item_ENUM.gold:
                    playerstatus.GoldPlus(item_stat);
                    break;
                case Item_ENUM.XP:
                    playerstatus.XpPlus(item_stat);
                    break;
                case Item_ENUM.HP:
                    playerstatus.HpPlus(item_stat);
                    break;
                default:
                    break;
            }



            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("Pull")&& pullcheck==false)
        {
           
            pullcheck = true;
            transform.LookAt(Player.transform);
            StartCoroutine(itemmove2());
        }

    }

    IEnumerator itemmove()
    {

        while (true)
        {
            transform.LookAt(Player.transform);
            transform.Translate(Vector3.forward*Time.deltaTime*speed);
            yield return null;
        }
    }
    IEnumerator itemmove2()
    {
        float cooltime =0;
        while (true)
        {
            cooltime += Time.deltaTime;

            //
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            if (cooltime >= 0.2f)
            {
                playcolcheck = true;
                StartCoroutine(itemmove());
                yield break;
            }
            yield return null;

        }
    }



    private void OnDisable()
    {
        pullcheck = false;
    }
}
