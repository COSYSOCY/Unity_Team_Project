using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChara : MonoBehaviour
{
    public Character character;
    public SelectChara[] chars;
    
    void Start()
    {
        if (DataMGR.instance.currentChara == character)
        {
            Onselect();
        }
        else OnDeselect();
    }


    private void OnMouseUpAsButton()
    {
        DataMGR.instance.currentChara = character;//커런트캐릭터를 캐릭터로 초기화해주는코드
        Onselect();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != this)
            {
                chars[i].OnDeselect();
            }
        }
    }



    void Onselect()
    {
        Debug.Log("선택되었습니다");
        
    }

    void OnDeselect()
    {
        Debug.Log("선택안됨");
    }
}
