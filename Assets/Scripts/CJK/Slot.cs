using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private Rect invenRect;

    public Item item;
    public Image itemImage; // ������ �̹���.

    void Start()
    {
        invenRect = transform.parent.parent.GetComponent<RectTransform>().rect;
    }

    //�̹��� ����
    void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    //������ ȹ��
    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.itemImage;

        SetColor(1);
    }
    //���� �ʱ�ȭ
    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("���");
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("�巡��");

        if (item != null)
            DragSlot.instance.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("����巡��");
        if (DragSlot.instance.transform.localPosition.x < invenRect.xMin ||
         DragSlot.instance.transform.localPosition.x > invenRect.xMax ||
         DragSlot.instance.transform.localPosition.y < invenRect.yMin ||
         DragSlot.instance.transform.localPosition.y > invenRect.yMax)
        {
            Debug.Log("���䰡");

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
        Debug.Log("�µ��");
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
