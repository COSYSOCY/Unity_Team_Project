using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public MeshRenderer meshRenderer;
    public GameObject ItemText;

    public GameObject chi;
    


    public enum Item_ENUM
    {
        gold=0,
        XP=1,
        HP=2,
        Card=3,
    };
    public Item_ENUM item_enum;

    private void Start()
    {
        levelstatus = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Levelstatus>();
        Player = GameObject.FindGameObjectWithTag("Player");
        itemprefabs = GameObject.FindGameObjectWithTag("Item");
        playerstatus=Player.GetComponent<PlayerStatus>();
    }
    public void CardCreate(int num)
    {
        item_stat = num;
        int i = GameInfo.inst.CardsInfo[item_stat].CardNameNum;
        ItemText = ObjectPooler.SpawnFromPool("Item_Info_Text", transform.position, Quaternion.identity);
        ItemText.transform.SetParent(MainSingleton.instance.ItemCreateTranform);
        ItemText.GetComponentInChildren<Text>().text = csvData.GameText(i);
        //ItemText.transform.position = Camera.main.ScreenToWorldPoint(transform.position + new Vector3(0, 0, 1f));
        //ItemText.transform.position = Camera.main.WorldToViewportPoint(transform.position);
        
        StartCoroutine(itemTextMove());
        //
        
    }
    IEnumerator itemTextMove()
    {
        while (true)
        {
            if (ItemText==null)
            {
                yield break;
            }

            ItemText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0, 1f));

            yield return new WaitForEndOfFrame();
        }
    }
    public void statSet(int i)
    {
        item_stat = i;
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
                    SoundManager.inst.SoundPlay(0);
                    break;
                case Item_ENUM.XP:
                    playerstatus.XpPlus(item_stat);

                    SoundManager.inst.SoundPlay(1);
                    break;
                case Item_ENUM.HP:
                    playerstatus.HpPlus(item_stat);

                    SoundManager.inst.SoundPlay(2);
                    break;
                case Item_ENUM.Card:
                    playerstatus.CardDrop(item_stat);
                    SoundManager.inst.SoundPlay(0);

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
        if (other.transform.CompareTag("Check") )
        {
            chi.SetActive(true);
            //meshRenderer.enabled = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Check"))
        {
            chi.SetActive(false);
            //meshRenderer.enabled = false;
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


        //if (item_enum == Item_ENUM.Card)
        //{
        //    if (ItemText != null)
        //    {
        //        ItemText.SetActive(false);
        //        ItemText = null;

        //    }
        //}


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
        if (item_enum == Item_ENUM.Card)
        {
            if (ItemText != null)
            {
                ItemText.SetActive(false);
                ItemText = null;

            }
        }

    }
}
