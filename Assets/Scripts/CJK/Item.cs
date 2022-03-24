using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // ������ �̸�
    [TextArea]
    public string itemDesc; // ������ ����
    public Sprite itemImage; // �������� �̹���
    public int value; // ��
    public ItemType itemType; // ������ ����
     
    public enum ItemType
    {
        Card,
        Character
    }

}
