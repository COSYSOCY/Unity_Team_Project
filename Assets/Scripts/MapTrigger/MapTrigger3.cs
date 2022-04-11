using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger3 : MonoBehaviour
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
                MainSingleton.instance.playerinfo.Min1Func();
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

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_2"));
                break;
            case 15:

                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_2"));
                break;
            case 30:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(30, 1f, 1f, 1, 1, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_2"));
                break;
            case 60:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_2"));
                StartCoroutine(enemyFunc.BossCreate("Boss_1", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_5"));
                break;
            case 90:
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_5"));
                break;
            case 120:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_2"));

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_5"));
                break;
            case 150:
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_5"));
                break;
            case 180:

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_2"));

                StartCoroutine(enemyFunc.BossCreate("Boss_1", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_8"));
                break;
            case 240:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_9"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, "Enemy_8"));
                break;
            case 300:
                StartCoroutine(enemyFunc.BossCreate("Boss_2", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFuncCircle("Enemy_Circle_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_10"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(5, 3f, 3f, 10, 10, "Enemy_10"));

                break;
            case 360:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_10"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_5"));
                break;
            case 420:
                StartCoroutine(enemyFunc.BossCreate("Boss_1", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_3", "Enemy_4", "Enemy_5"));

                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_5"));
                break;
            case 480:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_3", "Enemy_4", "Enemy_5"));

                break;
            case 540:

                StartCoroutine(enemyFunc.BossCreate("Boss_3", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_11"));
                break;
            case 600:
                StartCoroutine(enemyFunc.BossCreate("Boss_4", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFuncCircle("Enemy_Circle_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(5, 3f, 3f, 10, 10, "Enemy_10"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_5"));
                break;
            case 660:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, "Enemy_8"));
                break;
            case 720:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_9"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(15, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(15, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(15, "Enemy_8"));
                break;
            case 780:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_9"));

                StartCoroutine(enemyFunc.BossCreate("Boss_5", enemyFunc.GetRandomPos()));
                break;
            case 840:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(20, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(20, "Enemy_12"));
                break;
            case 900:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(25, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(25, "Enemy_12"));
                break;
            case 960:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, "Enemy_12"));
                break;
            case 1020:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(40, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(40, "Enemy_12"));
                break;
            case 1080:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(40, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(40, "Enemy_12"));
                break;
            case 1140:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(40, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(40, "Enemy_12"));
                break;
            case 1200:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 3, 5, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(20, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(20, "Enemy_12"));
                break;
            default:
                break;
        }
    }
}
