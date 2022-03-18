using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Info : MonoBehaviour
{
    public float Hp;
    public GameObject[] itemprefabs;
    public GameObject TextUi;
    public Transform parentTransform;
    public UIManager uimanager;
    private void Start()
    {
        parentTransform=GameObject.Find("TextUi").GetComponent<Transform>();
        uimanager=GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void Damaged(float damage)
    {
        GameObject clone = Instantiate(TextUi);
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
    void ItemRespawn() // ·£´ý¾ÆÀÌÅÛ»ý¼º
    {
        int itemRnd = Random.Range(0, 10);

        if (itemRnd <= 5)
        {
            if (Random.Range(0, 10) < 2)
            {
                Instantiate(itemprefabs[0], transform.position, transform.rotation);
            }
            else
            {
                Instantiate(itemprefabs[1], transform.position, transform.rotation);

            }

        }

    }
    public void Dead()
    {
        //Á×À½
        ItemRespawn();
        gameObject.SetActive(false);
    }
}
