using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSelect : MonoBehaviour
{
    [SerializeField] private GameObject selBase;
    [SerializeField] private Text txt_ItemName;
    [SerializeField] private Text txt_ItemDec;

    private Slot slot;

    public void SelectSlot()
    {
        slot = GetComponent<Slot>();
        ShowSlotInfo(slot.item);
    }

    public void ShowSlotInfo(Item _item)
    {
        Debug.Log(_item);
        selBase.SetActive(true);
        txt_ItemName.text = _item.itemName;
        txt_ItemDec.text = _item.itemDesc;
    }

}
