using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public LevelUp level;
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

    public List<bool> EnemyDestory=new List<bool>();


    public void tiemtrigger(float t)
    {
        switch (t)
        {
            case 30:
                EnemyMax += 10;
                break;
            case 60:
                EnemyMax += 20;
                EnemyDestory[0] = true;
                EnemyCreateName[0] = "Enemy_2";
                break;
            case 90:
                EnemyMax += 10;
                EnemyCreateName[0] = "Enemy_2";
                break;
            case 120:
                EnemyMax += 30;
                EnemyDestory[1] = true;
                EnemyCreateName[0] = "Enemy_3";
                break;
            case 180:
                EnemyMax += 40;
                EnemyDestory[2] = true;
                EnemyCreateName[0] = "Enemy_4";
                break;
            case 240:
                EnemyMax += 50;
                EnemyDestory[3] = true;
                EnemyCreateName[0] = "Enemy_5";
                break;
            case 300:
                EnemyMax += 60;
                break;
            case 360:
                EnemyMax += 30;
                break;
            case 420:
                EnemyMax += 30;
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


        if (playerInfo.Hp < 1)
        {
            Dead();
        }

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
        playerInfo.Xp += xp;
        uimanager.XpSet();
        if (playerInfo.Xp >= playerInfo.MaxXp)
        {
            LevelUp();
        }
    }
    public void GoldPlus(int gold)
    {
        uimanager.GoldUp(gold);
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
        switch (playerInfo.Lv)
        {
            case 1:
                playerInfo.MaxXp = 4;
                break;
            case 2:
                playerInfo.MaxXp = 6;
                break;
            case 3:
                playerInfo.MaxXp = 8;
                break;
            case 4:
                playerInfo.MaxXp = 20;
                break;
            case 5:
                playerInfo.MaxXp = 30;
                break;
            case 6:
                playerInfo.MaxXp = 40;
                break;
            case 7:
                playerInfo.MaxXp = 50;
                break;
            case 8:
                playerInfo.MaxXp = 60;
                break;
            case 9:
                playerInfo.MaxXp = 70;
                break;
            case 10:
                playerInfo.MaxXp = 80;
                break;
            case 11:
                playerInfo.MaxXp = 90;
                break;
            case 12:
                playerInfo.MaxXp = 100;
                break;
            case 13:
                playerInfo.MaxXp = 110;
                break;
            case 14:
                playerInfo.MaxXp = 120;
                break;
            case 15:
                playerInfo.MaxXp = 9999;
                break;
            default:
                break;
        }
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
