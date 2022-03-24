using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public LevelUp level;
    public SkillManager manager;
    public UIManager uimanager;
    public bool dead;
    public GameObject deadObject;
    public bool invin=false;

    public bool test=false;

    public int EnemyCnt;

    public int EnemyMax;
    public int EnemyCreateRan;
    public List<string> EnemyCreateName;
    [SerializeField] Slider hpbar;
    public List<int> XpCheck;

    public List<bool> EnemyDestory=new List<bool>();
    private void Start()
    {
        StartCoroutine(HpRegen());
        for (int i = 0; i < csvData.Exp.Count; i++)
        {
            XpCheck.Add(csvData.Exp[i]);
        }
        XpSet();
        //uimanager.XpSet();
    }

    IEnumerator HpRegen()
    {
        float f;
        while (true)
        {
            f=(GameInfo.HpRegenPlus+manager.HpRegen())*0.5f;
            if (f > 0)
            {
            HpPlus(f);

            }
        yield return new WaitForSeconds(0.5f);
        }
    }
    public void EnemyDes(string tag,int idx)
    {
        EnemyDestory[idx] = true;
        for (int i = 0; i < ObjectPooler.Enemy_Check[tag].Count; i++)
        {
            if (ObjectPooler.Enemy_Check[tag][i].activeSelf==false)
            {
                Destroy(ObjectPooler.Enemy_Check[tag][i]);
            }
        }
    }

    public void tiemtrigger(float t)
    {
        switch (t)
        {
            case 30:
                EnemyMax += 10;
                break;
            case 60:
                EnemyMax += 10;
                EnemyDes("Enemy_1", 0);
                EnemyCreateName[0] = "Enemy_2";
                break;
            case 90:
                EnemyMax += 10;
                EnemyCreateName[0] = "Enemy_2";
                break;
            case 120:
                EnemyMax += 20;
                EnemyDes("Enemy_2", 1);
                EnemyCreateName[0] = "Enemy_3";
                break;
            case 180:
                EnemyMax += 20;
                EnemyDes("Enemy_3", 2);
                EnemyCreateName[0] = "Enemy_4";
                break;
            case 240:
                EnemyMax += 20;
                EnemyDes("Enemy_4", 3);
                EnemyCreateName[0] = "Enemy_5";
                break;
            case 300:
                EnemyMax += 10;
                break;
            case 360:
                EnemyMax += 10;
                break;
            case 420:
                EnemyMax += 10;
                break;
            case 480:
                break;

            default:
                break;
        }
    }
    public void SliderUpdate()
    {
        //hpbar.value = playerInfo.Hp / MaxHp;
    }
    public void HpPlus(float _count)
    {
        playerInfo.Hp += _count;
        if (playerInfo.Hp >= playerInfo.MaxHp)
        {
            playerInfo.Hp = playerInfo.MaxHp;
            
        }
        hpbar.value = playerInfo.Hp / playerInfo.MaxHp;



    }

    public void Hp_Damage(float damage)
    {
        float f = damage;
        float D = GameInfo.DefencePlus + manager.Defence();
        f = f - D;

        if (f < 1)
        {
            f = 1f;
        }
        playerInfo.Hp = playerInfo.Hp - f;


        if (playerInfo.Hp < 1)
        {
            Dead();
            hpbar.value = 0;
            return;
        }
        hpbar.value = playerInfo.Hp / playerInfo.MaxHp;

    }
    public void Dead()
    {
        deadObject.SetActive(true);
        dead = true;
        Time.timeScale = 0f;

    }

    public void Replayer()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void XpPlus(int xp)
    {
        int i;
        float f = manager.XpPlus();
        f = xp * f * 0.01f;
        i = xp + (int)f;
        playerInfo.Xp += i;
        uimanager.XpSet();
        if (playerInfo.Xp >= playerInfo.MaxXp)
        {
            LevelUp();
        }
    }
    public void GoldPlus(int gold)
    {
        int i;
        float f = manager.GoldPlus();
        f = gold * f * 0.01f;
        i = gold + (int)f;
        uimanager.GoldUp(i);
    }
    public void LevelUp()
    {
        playerInfo.Xp = playerInfo.MaxXp-playerInfo.Xp;
        if (playerInfo.Xp <=0)
        {
            playerInfo.Xp = 0;
        }

        playerInfo.Lv++;
        XpSet();
        level.LevelFunc();
    }
    public void XpSet()
    {
        playerInfo.MaxXp = XpCheck[playerInfo.Lv-1];
        uimanager.XpSet();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log("È÷Æ®");
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        StartCoroutine(PlayerDamage());
    //        test = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
            
    //        test = false;
    //    }
    //}

    IEnumerator PlayerDamage()
    {
        if(!dead&&!invin)
        {
            HpPlus(-6);
            invin = true;
            yield return new WaitForSeconds(0.5f);
            if (test==true)
            {
                invin = false;

                StartCoroutine(PlayerDamage());
            }
            else
            {
            invin = false;

            }
        }
    }





}
