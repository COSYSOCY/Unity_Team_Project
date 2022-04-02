using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger1 : MonoBehaviour
{
    public PlayerInfo info;
    public UIManager ui;
    public PlayerStatus stat;
    public EnemyFunc enemyFunc;
    private void Start()
    {
        StartCoroutine(timecheck());
        
    }

    IEnumerator timecheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            info.timeplus++;
            info.timeS++;
            if (info.timeS >= 60)
            {
                info.timeM++;
                info.timeS = info.timeS - 60;
            }
            ui.TimeCheck();
            tiemtrigger(info.timeplus);
        }
    }
    public void startFunc()
    {
        
    }

    public void tiemtrigger(int t)
    {
        switch (t)
        {
            case 1:


                StartCoroutine(enemyFunc.EnemyCreateFunc1(180, 1, 1, 1, 1, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(3, "Enemy_2"));
                break;
            case 60:
                StartCoroutine(enemyFunc.BossCreate("Boss_1",enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(120, 1, 1, 1, 1, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(120, 1, 1, 1, 1, "Enemy_3", "Enemy_4", "Enemy_5"));
                break;
            case 120:
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3,15f,30f,"Enemy_Bat_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_1"));
                break;
            case 180:
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1"));
                StartCoroutine(enemyFunc.BossCreate("Boss_1", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(120,1f, 1f, 1, 1, "Enemy_6", "Enemy_7", "Enemy_8"));
                break;
            case 240:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, "Enemy_9"));
                break;
            case 300:
                StartCoroutine(enemyFunc.BossCreate("Boss_2", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFuncCircle("Enemy_Circle_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, "Enemy_10"));
                break;
            case 360:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, "Enemy_10"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_3", "Enemy_4", "Enemy_5"));
                break;
            case 420:
                StartCoroutine(enemyFunc.BossCreate("Boss_1", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1"));
                break;
            case 480:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1"));
                break;
            case 540:
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1"));
                StartCoroutine(enemyFunc.BossCreate("Boss_3", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_11"));
                break;
            case 600:
                StartCoroutine(enemyFunc.BossCreate("Boss_4", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFuncCircle("Enemy_Circle_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_3", "Enemy_4", "Enemy_5"));
                break;
            case 660:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, "Enemy_8"));
                break;
            case 720:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, "Enemy_9"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, "Enemy_6", "Enemy_7", "Enemy_8"));
                break;
            case 780:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, "Enemy_9"));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_2"));
                StartCoroutine(enemyFunc.BossCreate("Boss_5", enemyFunc.GetRandomPos()));
                break;
            case 840:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_12"));
                break;
            default:
                break;
        }
    }
}
