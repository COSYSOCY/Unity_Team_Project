using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // 아이템 이름
    [TextArea]
    public string itemDesc; // 아이템 설명
    public Sprite itemImage; // 아이템의 이미지
    public int value; // 값
    public ItemType itemType; // 아이템 유형
     
    public enum ItemType
    {
        Card,
        Character
    }

}
