using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    public bool testcheck=false;
    public GameObject LevelUiObject;
    public SkillManager skillManager;
    public List<int> num;
    public List<int> num2;

    public GameObject[] Skill_name;
    public GameObject[] Skill_Lv;
    public GameObject[] Skill_Text;
    public GameObject[] Skill_Image;





    
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && testcheck ==false)
        {
            num.Clear();
            num2.Clear();
            test();
            
        }

    }

    void test()
    {
        testcheck = true;
        for (int i = 0; i < skillManager.Skills.Count; i++)
        {
            num2.Add(i);
        }
        for (int i = 0; i < 3; i++)
        {
            int a = Random.Range(0, num2.Count);
            num.Add(num2[a]);
            num2.RemoveAt(a);
        }


        for (int i = 0; i < 3; i++)
        {
            
            Time.timeScale = 0f;
            LevelUiObject.SetActive(true);
            //var a = GetComponent<Skill_1>();
            //var a = Skill_1;
            GameObject gameObject;

             gameObject = skillManager.Skills[num[i]];

            string name="";
            int Lv=0 ;
            int image=0 ;
            string text ="" ;

            name = gameObject.GetComponent<Skill_Info>().Skill_Name;
            Lv = gameObject.GetComponent<Skill_Info>().Lv;
            image = gameObject.GetComponent<Skill_Info>().Skill_Icon;
            text = gameObject.GetComponent<Skill_Info>().Lv_Text[Lv];


            
            Skill_name[i].GetComponent<Text>().text = name;
            if (Lv == 0)
            {
                Skill_Lv[i].GetComponent<Text>().text = "신규!";
            }
            else
            {
                Skill_Lv[i].GetComponent<Text>().text = "레벨: " + (Lv + 1);
            }

            Skill_Image[i].GetComponent<Image>().sprite = skillManager.Skill_icon[image];
            Skill_Text[i].GetComponent<Text>().text = text;
            
        }



    }


    void ButonClick(GameObject gameObject)
    {
        int Lv = 0;
        Time.timeScale = 1f;
        LevelUiObject.SetActive(false);
        testcheck = false;
        Lv = gameObject.GetComponent<Skill_Info>().Lv;
        if (Lv == 0)
        {
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.GetComponent<Skill_Info>().LevelUpCheck();
        }
    }


    public void ButtonClick_1()
    {
        GameObject gameObject = skillManager.Skills[num[0]];
        ButonClick(gameObject);
        


    }
    public void ButtonClick_2()
    {
        GameObject gameObject = skillManager.Skills[num[1]];
        ButonClick(gameObject);
    }
    public void ButtonClick_3()
    {
        GameObject gameObject = skillManager.Skills[num[2]];
        ButonClick(gameObject);
    }
}
