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



    public List<GameObject> Skill_All_List; //뽑을때 모든 목록들
    
    
    public List<GameObject> Skill_All_Active; //현재 활성화되고있는 모든것들
    public List<GameObject> Skill_Active; // 현재 활성화되고있는 능력
    public List<GameObject> Skill_Item_Active; // 현재 활성화되고있는 아이템

    private void Start()
    {
        Skill_All_List = Skills;
        for (int i = 0; i < Skill_Items.Count; i++)
        {
            Skill_All_List.Add(Skill_Items[i]);
        }
    }
}
