using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public GameObject ItemUiObj;
    public GameObject Eq;    
    public PlayerInfo playerInfo;
    public List<GameObject> num;
    public List<GameObject> num2;
    public SkillManager skillManager;
    public GameObject[] Skill_name;
    public GameObject[] Skill_Lv;
    public GameObject[] Skill_Text;
    public GameObject[] Skill_Image;
    public PlayerStatus status;
    public PlayerMoving moving;
    public bool testcheck = false;
    public List<GameObject> LevelupUiOb;

    public void Update()
    {
        ItemUiObj = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject;
        Eq = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_1").gameObject;
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        status = GameObject.Find("Player").GetComponent<PlayerStatus>();
        moving = GameObject.Find("Canvas").transform.Find("ControlPanel").GetComponent<PlayerMoving>();
        skillManager = GameObject.Find("ObjectManager").transform.Find("Skil+item_lManager").GetComponent<SkillManager>();
        Skill_name[0] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_1").gameObject.transform.Find("Skill_Name_1").gameObject;
        Skill_Image[0] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_1").gameObject.transform.Find("Skill_Image_1").gameObject;
        Skill_Text[0] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_1").gameObject.transform.Find("Skill_Text_1").gameObject;
        Skill_Lv[0] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_1").gameObject.transform.Find("Skill_Lv_1").gameObject;
        Skill_name[1] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_2").gameObject.transform.Find("Skill_Name_2").gameObject;
        Skill_Image[1] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_2").gameObject.transform.Find("Skill_Image_2").gameObject;
        Skill_Text[1] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_2").gameObject.transform.Find("Skill_Text_2").gameObject;
        Skill_Lv[1] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_2").gameObject.transform.Find("Skill_Lv_2").gameObject;
        Skill_name[2] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_3").gameObject.transform.Find("Skill_Name_3").gameObject;
        Skill_Image[2] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_3").gameObject.transform.Find("Skill_Image_3").gameObject;
        Skill_Text[2] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_3").gameObject.transform.Find("Skill_Text_3").gameObject;
        Skill_Lv[2] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_3").gameObject.transform.Find("Skill_Lv_3").gameObject;
        LevelupUiOb[0] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_1").gameObject;
        LevelupUiOb[1] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_2").gameObject;
        LevelupUiOb[2] = GameObject.Find("Canvas").transform.Find("ItemUi").gameObject.transform.Find("Ski").gameObject.transform.Find("Skill_3").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ItemFunc();
            sil();
            Debug.Log("»óÀÚÈ¹µæ");            
        }
    }

    void itemupFunc()
    {                
        if (playerInfo.SkillCnt >= playerInfo.SkillMax)
        {
            for (int i = 0; i < skillManager.Skill_Active.Count; i++)
            {
                if (skillManager.Skill_Active[i].GetComponent<Skill_Info>().Lv < skillManager.Skill_Active[i].GetComponent<Skill_Info>().LvMax)
                {
                    num.Add(skillManager.Skill_Active[i]);
                }
            }
        }
        else
        {
            for (int i = 0; i < skillManager.Skills.Count; i++)
            {
                if (skillManager.Skills[i].GetComponent<Skill_Info>().Lv < skillManager.Skills[i].GetComponent<Skill_Info>().LvMax)
                {
                    num.Add(skillManager.Skills[i]);
                }
            }
        }
    }

    public void ItemFunc()
    {
        moving.stick.localPosition = Vector2.zero;
        moving.pad.gameObject.SetActive(false);
        moving.StopAllCoroutines();
        moving.move = Vector3.zero;
        testcheck = true;       
        ItemUiObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void sil()
    {
        if(playerInfo.SkillCnt == 0)
        {
            for (int i = 0; i < skillManager.Skills.Count; i++)
            {
                num.Add(skillManager.Skills[i]);
            }
            int ran;
            for (int i = 0; i < 1; i++)
            {
                ran = Random.Range(0, num.Count);
                num2.Add(num[ran]);
                num.RemoveAt(ran);
            }
        }
        else
        {
            itemupFunc();
        }

        if (num2[0] == true)
        {
            string name = "";
            int Lv = 0;
            int image = 0;
            string text = "";

            if (num2[0].GetComponent<Skill_item_Check>().Skill)
            {
                name = num2[0].GetComponent<Skill_Info>().Skill_Name;
                Lv = num2[0].GetComponent<Skill_Info>().Lv;
                image = num2[0].GetComponent<Skill_Info>().Skill_Icon;
                text = num2[0].GetComponent<Skill_Info>().Lv_Text[Lv];

                Skill_name[0].GetComponent<Text>().text = name;
                if (Lv == 0)
                {
                    Skill_Lv[0].GetComponent<Text>().text = csvData.GameText(460) + "!";
                }
                else
                {
                    Skill_Lv[0].GetComponent<Text>().text = csvData.GameText(461) + ": " + (Lv + 1);
                }

                Skill_Image[0].GetComponent<Image>().sprite = skillManager.Skill_icon[image];
                Skill_Text[0].GetComponent<Text>().text = text;
            }
        }    
    }

    public void ButonClick12(GameObject Ob)
    {
        int Lv = 0;
        Time.timeScale = 1f;
        testcheck = false;
        ItemUiObj.SetActive(false);        
        Lv = Ob.GetComponent<Skill_Info>().Lv;
        if (Lv == 0)
        {
            Ob.SetActive(true);
        }
        else
        {            
            Ob.GetComponent<Skill_Ori>().LevelUp();
        }     
    }

    public void ButtonClick_11()
    {
        GameObject ob = num2[0];        
        if (ob.GetComponent<Skill_item_Check>().Skill)
        {
            ButonClick12(ob);
        }            
    }
}
