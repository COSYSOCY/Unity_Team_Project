using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    const float hp = 100;
    public PlayerInfo playerInfo;
    public LevelUp level;
    public UIManager uimanager;
    public bool dead;
    public GameObject deadObject;
    public bool invin=false;

    [SerializeField] Slider hpbar;


    void Start()
    {
        playerInfo.Hp = hp;
    }
    void Update()
    {
        SliderUpdate();
    }
    public void SliderUpdate()
    {
        hpbar.value = playerInfo.Hp / hp;
    }
    public void HpPlus(float _count)
    {
        if (playerInfo.Hp + _count <= hp)
        {
            playerInfo.Hp += _count;
        }
        else
        {
            playerInfo.Hp = hp;
        }
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
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("È÷Æ®");
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(PlayerDamage());
        }
    }

    IEnumerator PlayerDamage()
    {
        if(!dead&&!invin)
        {
            HpPlus(-6);
            invin = true;
            yield return new WaitForSeconds(0.5f);
            invin = false;
        }
    }





}
