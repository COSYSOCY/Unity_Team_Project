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
        num.Add(1);
        num.Add(4);
        num.Add(0);


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
            testcheck = true;
            Time.timeScale = 0f;
            LevelUiObject.SetActive(true);
            //var a = GetComponent<Skill_1>();
            //var a = Skill_1;
            GameObject gameObject = skillManager.Skills[num[i]-1];
            string name="";
            int Lv=0 ;
            int image=0 ;
            string text ="" ;
            if (gameObject.name == "Skill1")
            {
                name = gameObject.GetComponent<Skill_1>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_1>().Lv;
                image = gameObject.GetComponent<Skill_1>().Skill_Icon;
                text = gameObject.GetComponent<Skill_1>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill2")
            {
                name = gameObject.GetComponent<Skill_2>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_2>().Lv;
                image = gameObject.GetComponent<Skill_2>().Skill_Icon;
                text = gameObject.GetComponent<Skill_2>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill3")
            {
                name = gameObject.GetComponent<Skill_3>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_3>().Lv;
                image = gameObject.GetComponent<Skill_3>().Skill_Icon;
                text = gameObject.GetComponent<Skill_3>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill4")
            {
                name = gameObject.GetComponent<Skill_4>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_4>().Lv;
                image = gameObject.GetComponent<Skill_4>().Skill_Icon;
                text = gameObject.GetComponent<Skill_4>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill5")
            {
                name = gameObject.GetComponent<Skill_5>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_5>().Lv;
                image = gameObject.GetComponent<Skill_5>().Skill_Icon;
                text = gameObject.GetComponent<Skill_5>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill6")
            {
                name = gameObject.GetComponent<Skill_6>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_6>().Lv;
                image = gameObject.GetComponent<Skill_6>().Skill_Icon;
                text = gameObject.GetComponent<Skill_6>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill7")
            {
                name = gameObject.GetComponent<Skill_7>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_7>().Lv;
                image = gameObject.GetComponent<Skill_7>().Skill_Icon;
                text = gameObject.GetComponent<Skill_7>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill8")
            {
                name = gameObject.GetComponent<Skill_8>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_8>().Lv;
                image = gameObject.GetComponent<Skill_8>().Skill_Icon;
                text = gameObject.GetComponent<Skill_8>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill9")
            {
                name = gameObject.GetComponent<Skill_9>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_9>().Lv;
                image = gameObject.GetComponent<Skill_9>().Skill_Icon;
                text = gameObject.GetComponent<Skill_9>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill10")
            {
                name = gameObject.GetComponent<Skill_10>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_10>().Lv;
                image = gameObject.GetComponent<Skill_10>().Skill_Icon;
                text = gameObject.GetComponent<Skill_10>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill11")
            {
                name = gameObject.GetComponent<Skill_11>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_11>().Lv;
                image = gameObject.GetComponent<Skill_11>().Skill_Icon;
                text = gameObject.GetComponent<Skill_11>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill12")
            {
                name = gameObject.GetComponent<Skill_12>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_12>().Lv;
                image = gameObject.GetComponent<Skill_12>().Skill_Icon;
                text = gameObject.GetComponent<Skill_12>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill13")
            {
                name = gameObject.GetComponent<Skill_13>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_13>().Lv;
                image = gameObject.GetComponent<Skill_13>().Skill_Icon;
                text = gameObject.GetComponent<Skill_13>().Lv_Text[Lv];
            }
            else if (gameObject.name == "Skill14")
            {
                name = gameObject.GetComponent<Skill_14>().Skill_Name;
                Lv = gameObject.GetComponent<Skill_14>().Lv;
                image = gameObject.GetComponent<Skill_14>().Skill_Icon;
                text = gameObject.GetComponent<Skill_14>().Lv_Text[Lv];
            }

            
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

        if (gameObject.name == "Skill1")
        {
            Lv = gameObject.GetComponent<Skill_1>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_1>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill2")
        {
            Lv = gameObject.GetComponent<Skill_2>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_2>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill3")
        {
            Lv = gameObject.GetComponent<Skill_3>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_3>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill4")
        {
            Lv = gameObject.GetComponent<Skill_4>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_4>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill5")
        {
            Lv = gameObject.GetComponent<Skill_5>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_6>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill6")
        {
            Lv = gameObject.GetComponent<Skill_6>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_7>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill7")
        {
            Lv = gameObject.GetComponent<Skill_7>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_8>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill8")
        {
            Lv = gameObject.GetComponent<Skill_8>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_8>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill9")
        {
            Lv = gameObject.GetComponent<Skill_9>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_9>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill10")
        {
            Lv = gameObject.GetComponent<Skill_10>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_10>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill11")
        {
            Lv = gameObject.GetComponent<Skill_11>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_11>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill12")
        {
            Lv = gameObject.GetComponent<Skill_12>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_12>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill13")
        {
            Lv = gameObject.GetComponent<Skill_13>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_13>().LevelUp();
            }
        }
        else if (gameObject.name == "Skill14")
        {
            Lv = gameObject.GetComponent<Skill_14>().Lv;
            if (Lv == 0)
            {
                gameObject.SetActive(true);

            }
            else
            {
                gameObject.GetComponent<Skill_14>().LevelUp();
            }
        }
    }


    public void ButtonClick_1()
    {
        GameObject gameObject = skillManager.Skills[num[0]-1];
        ButonClick(gameObject);
        


    }
    public void ButtonClick_2()
    {
        GameObject gameObject = skillManager.Skills[num[1]-1];
        ButonClick(gameObject);
    }
    public void ButtonClick_3()
    {
        GameObject gameObject = skillManager.Skills[num[2]-1];
        ButonClick(gameObject);
    }
}
