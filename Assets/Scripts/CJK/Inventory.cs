using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject go_SlotParent;
    public Slot[] slots;

    void Start()
    {
        slots = go_SlotParent.GetComponentsInChildren<Slot>();
    }
    public void ItemAcquisition(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }
        }
    }
}
