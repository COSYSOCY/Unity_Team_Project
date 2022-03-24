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
        DataMGR.instance.currentChara = character;//Ŀ��Ʈĳ���͸� ĳ���ͷ� �ʱ�ȭ���ִ��ڵ�
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
        Debug.Log("���õǾ����ϴ�");
        
    }

    void OnDeselect()
    {
        Debug.Log("���þȵ�");
    }
}
