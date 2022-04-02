using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CharSkill
{
    public List<GameObject> Skill;
    public List<GameObject> SkillItem;
}

public class SkillManager : MonoBehaviour
{
    public List<GameObject> All_Skill;
    public List<GameObject> All_Skill_Items;
    public List<GameObject> Skills;
    public List<GameObject> Skill_Items;
    public List<GameObject> Player_Skill;
    //public List<Sprite> Skill_icon;
    public PlayerInfo playerinfo;

    public List<Image> ui_skill_Icon;
    public List<Image> ui_skillItem_Icon;

    public List<CharSkill> CharSkillAndItem;
    public List<GameObject> Player_Skill_Item;



   // public List<GameObject> Skill_All_List; //뽑을때 모든 목록들
    
    
    public List<GameObject> Skill_All_Active; //현재 활성화되고있는 모든것들
    public List<GameObject> Skill_Active; // 현재 활성화되고있는 능력
    public List<GameObject> Skill_Item_Active; // 현재 활성화되고있는 아이템

    //public List<Skill_Info> SkillInfo;
    public List<Skill_ItemInfo> ItemInfo;

    public void skill_Add(GameObject g, int icon)
    {
        //Debug.Log("체크");
        ui_skill_Icon[playerinfo.SkillCnt].sprite = IconManager.inst.Icons[icon];
        playerinfo.SkillCnt++;
        Skill_All_Active.Add(g);
        Skill_Active.Add(g);
        //SkillInfo.Add(g.GetComponent<Skill_Info>());
        //UI추가하기
    }
    public void skill_item_Add(GameObject g, int icon)
    {
        ui_skillItem_Icon[playerinfo.SkillItemCnt].sprite = IconManager.inst.Icons[icon];
        playerinfo.SkillItemCnt++;
        Skill_All_Active.Add(g);
        Skill_Item_Active.Add(g);
        ItemInfo.Add(g.GetComponent<Skill_ItemInfo>());
        //UI추가하기
    }

    public float HpPlusC()
    {
        float f=0;

        if (Skill_Item_Active.Count >=1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].HpPlusC;
            }
        }

        return f;
    }
    public float HpPlusPer()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].HpPlusPer;
            }
        }

        return f;
    }
    public float HpRegen()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].HpRegen;
            }
        }

        return f;
    }
    public float Defence()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].Defence;
            }
        }

        return f;
    }

    public float AtPlus()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].AtPlus;
            }
        }

        return f;
    }
    public float Cool()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].Cool;
            }
        }

        return f;
    }
    public float AtRange()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].AtRange;
            }
        }

        return f;
    }
    public float Speed()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].Speed;
            }
        }

        return f;
    }
    public int BulletCnt()
    {
        int a = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                a += ItemInfo[i].BulletCnt;
            }
        }

        return a;
    }
    public float GoldPlus()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].GoldPlus;
            }
        }

        return f;
    }
    public float XpPlus()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].XpPlus;
            }
        }

        return f;
    }
    public float BulletSpeed()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].BulletSpeed;
            }
        }

        return f;
    }
    public float BulletTime()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].BulletTime;
            }
        }

        return f;
    }
    public float _Range()
    {
        float f = 0;

        if (Skill_Item_Active.Count >= 1)
        {
            for (int i = 0; i < Skill_Item_Active.Count; i++)
            {
                f += ItemInfo[i].Range;
            }
        }

        return f;
    }

}
