using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<GameObject> Skills;
    public List<GameObject> Skill_Items;
    public List<GameObject> Player_Skill;
    public List<Sprite> Skill_icon;


    public List<GameObject> Player_Skill_Item;



    public List<GameObject> Skill_All_List; //������ ��� ��ϵ�
    
    
    public List<GameObject> Skill_All_Active; //���� Ȱ��ȭ�ǰ��ִ� ���͵�
    public List<GameObject> Skill_Active; // ���� Ȱ��ȭ�ǰ��ִ� �ɷ�
    public List<GameObject> Skill_Item_Active; // ���� Ȱ��ȭ�ǰ��ִ� ������

    private void Start()
    {
        Skill_All_List = Skills;
        for (int i = 0; i < Skill_Items.Count; i++)
        {
            Skill_All_List.Add(Skill_Items[i]);
        }
    }
}
