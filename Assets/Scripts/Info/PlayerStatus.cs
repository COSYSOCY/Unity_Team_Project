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
    public float shakeduration;
    public float shakestr;
    public bool invin=false;
    public GameObject camer;

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


    public int ReCnt = 0;
    public int In = 0;
    public int shield = 0;
    public GameObject shiledOb;
    public GameObject shiledOb2;




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
        f = GameInfo.HpPlus + CardStat.inst.CardStat_HpC()+ manager.HpPlusC()+ PowerUpInfo.instance._Hp()+ playerInfo.Bonus_HpC;
        f = f + (f * ((manager.HpPlusPer()+ playerInfo.Bonus_HpP+CardStat.inst.CardStat_HpP()) * 0.01f));
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
        camerashake();
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
            f=(GameInfo.HpRegenPlus+manager.HpRegen()+ cardHpRegen+ PowerUpInfo.instance._HpRegen()) *0.5f;
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
        if (MainSingleton.instance.playerstat.SkillItemactive[17] >= 1)
        {
            MainSingleton.instance.item17.Func();
        }
        if (IsAdIn)
        {
            return;
        }
        if (In != 0)
        {
            return;
        }
        if (shield >=1)
        {
            shield--;
            shiledOb2.SetActive(false);
            return;
        }
        float f = damage;
        float D = GameInfo.DefencePlus + manager.Defence()+ cardDefecne+ PowerUpInfo.instance._Defence()+playerInfo.Bonus_Defence;
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
        camerashake();
        StartCoroutine(HitDmg());
        hpbar.value = playerInfo.Hp / playerInfo.MaxHp;
        SliderUpdate();

    }
    IEnumerator ReFunc()
    {
        MainSingleton.instance.nav.radius += 3;
        yield return null;
        hpbar.value = 1f;
        yield return new WaitForSeconds(2f);
        MainSingleton.instance.nav.radius -= 3;
        SliderUpdate();
        shiledOb.SetActive(false);
        In--;
    }
    public void Shiled()
    {
        shield = 1;
        shiledOb2.SetActive(true);
    }
    public void Dead()
    {
        if (ReCnt >0)
        {
            ReCnt--;
            In++;
            playerInfo.Hp = playerInfo.MaxHp;
            shiledOb.SetActive(true);
            SliderUpdate();
            SoundManager.inst.SoundPlay(22);
            StartCoroutine(ReFunc());
            return;
        }
        dead = true;
        Time.timeScale = 0f;
        
        if (playerInfo.ADRe==0 )
        {
            AdReOb.SetActive(true);
            //if (GameInfo.PlayerPoint >= 5)
            //{
            //    AdReObpayBtn.SetActive(true);
            //}
        }
        else
        {
            uimanager.EndGame();
        }



    }


    public void XpPlus(int xp)
    {
        if (xp !=0)
        {

        int i;
        float f = manager.XpPlus()+GameInfo.XpPlus + CardStat.inst.CardStat_XpPlus()+ PowerUpInfo.instance._XpPlus()+playerInfo.Bonus_XpPuls;
        f = xp * f * 0.01f;
        i = xp + (int)f;
        playerInfo.Xp += i;
        uimanager.XpSet();

        //XpBar.transform.DOScale(1.1f, 0.1f);
        XpBar.transform.DOKill();
            XpBar.transform.localScale=new Vector3(2, 1.5f,2);
        if (XpBar.transform.localScale.y <=1.6f)
        {
            XpBar.transform.DOPunchScale(new Vector3(2, 2.25f, 2), 0.5f,0,0 );
        }
        }
        

        if (playerInfo.Xp >= playerInfo.MaxXp)
        {
            LevelUp();
        }
    }
    public void GoldPlus(int gold)
    {
        int i;
        //float f = manager.GoldPlus()+ CardStat.inst.CardStat_GoldPlus()+ PowerUpInfo.instance._Gold();
        //f = gold * f * 0.01f;
        //i = gold + (int)f;
        i = gold;
        uimanager.GoldUp(i);
    }
    public void LevelUp()
    {
        playerInfo.Xp = playerInfo.Xp- playerInfo.MaxXp;
        
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
        shiledOb.SetActive(true);
        MainSingleton.instance.nav.radius += 3;
        yield return null;
        SliderUpdate();
        SoundManager.inst.SoundPlay(22);
        yield return new WaitForSeconds(2f);
        MainSingleton.instance.nav.radius -= 3;
        shiledOb.SetActive(false);
        IsAdIn = false;
    }


    public void charFunc()
    {
        switch (GameInfo.inst.CharacterIdx)
        {
            case 0:
                if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_Cri += 5f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_Cri += 5f;
                }
                else if (playerInfo.Lv == 90)
                {
                    playerInfo.Bonus_Cri += 5f;
                }
                break;

            case 1:
                if (playerInfo.Lv == 15)
                {
                    playerInfo.Bonus_Defence += 1f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_Defence += 1f;
                }
                else if (playerInfo.Lv == 45)
                {
                    playerInfo.Bonus_Defence += 1f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_Defence += 1f;
                }
                else if (playerInfo.Lv == 75)
                {
                    playerInfo.Bonus_Defence += 1f;
                }
                break;
            case 2:
                if (playerInfo.Lv == 15)
                {
                    playerInfo.Bonus_BtSpeed += 10f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_BtSpeed += 10f;
                }
                else if (playerInfo.Lv == 45)
                {
                    playerInfo.Bonus_BtSpeed += 10f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_BtSpeed += 10f;
                }
                else if (playerInfo.Lv == 75)
                {
                    playerInfo.Bonus_BtSpeed += 10f;
                }
                break;
            case 3:
                if (playerInfo.Lv == 10)
                {
                    playerInfo.Bonus_XpPuls += 5f;
                }
                else if (playerInfo.Lv == 20)
                {
                    playerInfo.Bonus_XpPuls += 5f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_XpPuls += 5f;
                }
                else if (playerInfo.Lv == 40)
                {
                    playerInfo.Bonus_XpPuls += 5f;
                }
                else if (playerInfo.Lv == 50)
                {
                    playerInfo.Bonus_XpPuls += 5f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_XpPuls += 5f;
                }
                break;
            case 4:
                if (playerInfo.Lv == 10)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 20)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 40)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 50)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 70)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 80)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 90)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                else if (playerInfo.Lv == 100)
                {
                    playerInfo.Bonus_Cri += 3f;
                }
                break;
            case 5:
                if (playerInfo.Lv == 15)
                {
                    playerInfo.Bonus_AtRange += 10f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_AtRange += 10f;
                }
                else if (playerInfo.Lv == 45)
                {
                    playerInfo.Bonus_AtRange += 10f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_AtRange += 10f;
                }
                else if (playerInfo.Lv == 75)
                {
                    playerInfo.Bonus_AtRange += 10f;
                }
               
                break;
            case 6:
                if (playerInfo.Lv == 15)
                {
                    playerInfo.Bonus_Dmg += 10f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_Dmg += 10f;
                }
                else if (playerInfo.Lv == 45)
                {
                    playerInfo.Bonus_Dmg += 10f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_Dmg += 10f;
                }
                else if (playerInfo.Lv == 75)
                {
                    playerInfo.Bonus_Dmg += 10f;
                }
                break;
            case 7:
                if (playerInfo.Lv == 15)
                {
                    playerInfo.Bonus_BtTime += 10f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_BtTime += 10f;
                }
                else if (playerInfo.Lv == 45)
                {
                    playerInfo.Bonus_BtTime += 10f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_BtTime += 10f;
                }
                else if (playerInfo.Lv == 75)
                {
                    playerInfo.Bonus_BtTime += 10f;
                }
                break;
            case 8:
                if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_BtCnt += 1;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_BtCnt += 1;
                }
                else if (playerInfo.Lv == 90)
                {
                    playerInfo.Bonus_BtCnt += 1;
                }

                break;
            case 9:
                if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_Cri += 5f;
                }
                else if (playerInfo.Lv == 60)
                {
                    playerInfo.Bonus_Cri += 5f;
                }
                else if (playerInfo.Lv == 90)
                {
                    playerInfo.Bonus_Cri += 5f;
                }
                break;
            case 10:
                if (playerInfo.Lv == 15)
                {
                    playerInfo.Bonus_Dmg += 5f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_Dmg += 5f;
                }
                else if (playerInfo.Lv == 40)
                {
                    playerInfo.Bonus_Dmg += 5f;
                }
                else if (playerInfo.Lv == 55)
                {
                    playerInfo.Bonus_Dmg += 5f;
                }
                else if (playerInfo.Lv == 70)
                {
                    playerInfo.Bonus_Dmg += 5f;
                }
                break;
            case 11:
                if (playerInfo.Lv == 15)
                {
                    playerInfo.Bonus_Cool += 3f;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_Cool += 3f;
                }
                else if (playerInfo.Lv == 40)
                {
                    playerInfo.Bonus_Cool += 3f;
                }
                else if (playerInfo.Lv == 55)
                {
                    playerInfo.Bonus_Cool += 3f;
                }
                else if (playerInfo.Lv == 70)
                {
                    playerInfo.Bonus_Cool += 3f;
                }
                break;
            case 12:
                if (playerInfo.Lv == 15)
                {
                    playerInfo.Bonus_HpC += 20;
                }
                else if (playerInfo.Lv == 30)
                {
                    playerInfo.Bonus_HpC += 20;
                }
                else if (playerInfo.Lv == 40)
                {
                    playerInfo.Bonus_HpC += 20;
                }
                else if (playerInfo.Lv == 55)
                {
                    playerInfo.Bonus_HpC += 20;
                }
                else if (playerInfo.Lv == 70)
                {
                    playerInfo.Bonus_HpC += 20;
                }
                break;
            default:
                break;
        }
    }


    public void camerashake()
    {
        if(Ishit == true)
        {
            camer.transform.DOShakePosition(0.5f, 1.5f);
        }        
    }

    public void TimeIn(float t)
    {
        StartCoroutine(ITimein(t));
    }
    IEnumerator ITimein(float t)
    {
        In++;
        yield return new WaitForSeconds(1);
        In--;
    }
}
