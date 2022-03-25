using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public Item item;
    public Image itemImage; // ������ �̹���.

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
}

