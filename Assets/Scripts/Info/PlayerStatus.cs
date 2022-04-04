using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerStatus : MonoBehaviour
{
    public List<int> Skillactive;
    public List<int> SkillItemactive;
    public PlayerInfo playerInfo;
    public LevelUp level;
    public SkillManager manager;
    public UIManager uimanager;
    public bool dead;
    public GameObject AdReOb;
    public GameObject AdReObpayBtn;
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
    public bool IsAdIn = false;

    public List<int> playingCard;
    public List<int> playingCard_Bonus;
    public bool Ishit;

    public GameObject XpBar;
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

        for (int i = 0; i < manager.All_Skill.Count; i++)
        {
            Skillactive.Add(0);
        }
        for (int i = 0; i < manager.All_Skill_Items.Count; i++)
        {
            SkillItemactive.Add(0);
        }
    }

    public void PlayerHpMax()
    {
        float f = 0;
        f = GameInfo.HpPlus + CardStat.inst.CardStat_HpC()+ manager.HpPlusC();
        f = f + (f * ((manager.HpPlusPer()+ CardStat.inst.CardStat_HpP()) * 0.01f));
        playerInfo.MaxHp = f;
    }
    IEnumerator HitDmg()
    {
        SoundManager.inst.SoundPlay(6);
        if (Ishit)
        {
            yield break;
        }
        Ishit = true;
        GameObject Effect = ObjectPooler.SpawnFromPool("Player_Hit", transform.position, Quaternion.identity);
        for (int i = 0; i < MainSingleton.instance.HitEffect.Count; i++)
        {
            MainSingleton.instance.HitEffect[i].color = Color.red;
        }
                yield return new WaitForSeconds(0.15f);

        for (int i = 0; i < MainSingleton.instance.HitEffect.Count; i++)
        {
            MainSingleton.instance.HitEffect[i].color = Color.white;
        }
        Ishit = false;
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

    public void CardDrop(int i)
    {
        playingCard.Add(i);
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
        if (IsAdIn)
        {
            return;
        }
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
        StartCoroutine(HitDmg());
        hpbar.value = playerInfo.Hp / playerInfo.MaxHp;
        SliderUpdate();
        if (Skillactive[13]>=1)
        {
        MainSingleton.instance.skill_13.Skill13Func();

        }
    }
    public void Dead()
    {
        dead = true;
        Time.timeScale = 0f;
        if (playerInfo.ADRe==0 )
        {
            AdReOb.SetActive(true);
            if (GameInfo.PlayerPoint >= 5)
            {
                AdReObpayBtn.SetActive(true);
            }
        }
        else
        {
            uimanager.EndGame();
        }



    }


    public void XpPlus(int xp)
    {
        int i;
        float f = manager.XpPlus()+GameInfo.XpPlus + CardStat.inst.CardStat_XpPlus();
        f = xp * f * 0.01f;
        i = xp + (int)f;
        playerInfo.Xp += i;
        uimanager.XpSet();

        //XpBar.transform.DOScale(1.1f, 0.1f);

        if (XpBar.transform.localScale.y <=1.6f)
        {
            XpBar.transform.localScale=new Vector3(2, 1.5f,2);
            XpBar.transform.DOPunchScale(new Vector3(2, 2.25f, 2), 0.5f,0,0 );
        }
        

        if (playerInfo.Xp >= playerInfo.MaxXp)
        {
            LevelUp();
        }
    }
    public void GoldPlus(int gold)
    {
        int i;
        float f = manager.GoldPlus()+ CardStat.inst.CardStat_GoldPlus();
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
        uimanager.Leveltext();
        XpSet();
        level.LevelFunc();
        charFunc();
    }
    public void XpSet()
    {
        playerInfo.MaxXp = XpCheck[playerInfo.Lv-1];
        uimanager.XpSet();
    }

    public IEnumerator AdIn()
    {
        IsAdIn = true;
        dead = false;
        AdReOb.SetActive(false);
        Time.timeScale = 1f;
        playerInfo.ADRe++;
        playerInfo.Hp=playerInfo.MaxHp;
        SliderUpdate();
        yield return new WaitForSeconds(3f);
        IsAdIn = false;
    }


    public void charFunc()
    {
        switch (GameInfo.inst.CharacterIdx)
        {
            case 0:
                if (playerInfo.Lv==10)
                {
                    GameInfo.DamagePlus += 10f;
                }
                else if(playerInfo.Lv == 20)
                {
                    GameInfo.DamagePlus += 10f;
                }
                else if (playerInfo.Lv == 30)
                {
                    GameInfo.DamagePlus += 10f;
                }
                else if (playerInfo.Lv == 40)
                {
                    GameInfo.DamagePlus += 10f;
                }
                else if (playerInfo.Lv == 50)
                {
                    GameInfo.DamagePlus += 10f;
                }
                break;
            default:
                break;
        }
    }





}
