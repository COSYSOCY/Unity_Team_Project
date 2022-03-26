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
    public float cardHpRegen=0;
    public float cardDefecne=0;
    private void Start()
    {
        StartCoroutine(HpRegen());
        for (int i = 0; i < csvData.Exp.Count; i++)
        {
            XpCheck.Add(csvData.Exp[i]);
        }
        XpSet();
        //uimanager.XpSet();
        cardHpRegen = CardStat.inst.CardStat_HpRegen();
        cardDefecne = CardStat.inst.CardStat_Defence();
    }

    public void PlayerHpMax()
    {
        float f = 0;
        f = GameInfo.HpPlus + CardStat.inst.CardStat_HpC()+ manager.HpPlusC();
        f = f + (f * ((manager.HpPlusPer()+ CardStat.inst.CardStat_HpP()) * 0.01f));
        playerInfo.MaxHp = f;
    }
    IEnumerator HpRegen()
    {
        float f;
        while (true)
        {
            f=(GameInfo.HpRegenPlus+manager.HpRegen()+ cardHpRegen) *0.5f;
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


    public void SliderUpdate()
    {
        if (playerInfo.Hp == 0 || playerInfo.MaxHp == 0)
        {
            return;
        }
        hpbar.value = playerInfo.Hp / playerInfo.MaxHp;
    }
    public void HpPlus(float _count)
    {
        playerInfo.Hp += _count;
        if (playerInfo.Hp >= playerInfo.MaxHp)
        {
            playerInfo.Hp = playerInfo.MaxHp;
            
        }
        hpbar.value = playerInfo.Hp / playerInfo.MaxHp;
        SliderUpdate();


    }

    public void Hp_Damage(float damage)
    {
        float f = damage;
        float D = GameInfo.DefencePlus + manager.Defence()+ cardDefecne;
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
        SliderUpdate();
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
        float f = manager.XpPlus()+GameInfo.XpPlus + CardStat.inst.CardStat_XpPlus();
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
