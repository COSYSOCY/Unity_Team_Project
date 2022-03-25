using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Rect invenRect;

    public Item item;
    public Image itemImage; // 아이템 이미지.

    void Start()
    {
        invenRect = transform.parent.parent.GetComponent<RectTransform>().rect;
    }

    //이미지 투명도
    void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    //아이템 획득
    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.itemImage;

        SetColor(1);
    }
    //슬롯 초기화
    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("비긴");
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("드래그");

        if (item != null)
            DragSlot.instance.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("엔드드래그");
        if (DragSlot.instance.transform.localPosition.x < invenRect.xMin ||
         DragSlot.instance.transform.localPosition.x > invenRect.xMax ||
         DragSlot.instance.transform.localPosition.y < invenRect.yMin ||
         DragSlot.instance.transform.localPosition.y > invenRect.yMax)
        {
            Debug.Log("여긴가");

            DragSlot.instance.SetColor(0);
            return;
        }
        else
        {
            DragSlot.instance.SetColor(0);
            DragSlot.instance.dragSlot = null;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("온드롭");
        if (DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
        }
    }
    void ChangeSlot()
    {
        Item _tmItem = item;
        Debug.Log(item);
        AddItem(DragSlot.instance.dragSlot.item);
        if (_tmItem != null)
        {
            DragSlot.instance.dragSlot.AddItem(_tmItem);
        }
        else
        {
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }
}
