using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    public GameObject[] item;
    public Inventory inventory;




    public void ItemAdditional()
    {
        int ran = Random.Range(0, 3);

        Instantiate(item[ran]);
        Debug.Log(item[ran]); 


        inventory.ItemAcquisition(item[ran].GetComponent<Item>());
    }


}
