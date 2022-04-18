using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger4 : MonoBehaviour
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
        //switch (t)
        //{
        //    case 1:

        //        //StartCoroutine(enemyFunc.EnemyCreateFunc2(5, 0, 0, "Enemy_Test"));
        //        break;
        //    case 15:

        //        MainSingleton.instance.playerstat.BossCreate();
        //        StartCoroutine(enemyFunc.BossCreate("Boss_15", 0, 0, enemyFunc.GetRandomPos()));
        //        StartCoroutine(enemyFunc.EnemyCreateFunc1(600, 1f, 1f, 1, 3, 0, 0, "Enemy_15", "Enemy_16", "Enemy_17"));
        //        break;


        //    default:
        //        break;
        //}
        //return;
        switch (t)
        {
            case 1:
                enemyFunc.HpP_Plus = 0.5f;
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 1, 0, 0, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_2"));
                break;
            case 15:

                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_2"));
                break;
            case 30:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(30, 1f, 1f, 1, 1, 0, 0, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_2"));
                break;
            case 60:
                StartCoroutine(enemyFunc.BossCreate("Boss_1", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_2"));

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_5"));
                break;
            case 90:
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_5"));
                break;
            case 120:
                StartCoroutine(enemyFunc.BossCreate("Boss_2", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1", 0, 0));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_5"));
                break;
            case 150:
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_5"));
                break;
            case 180:
                StartCoroutine(enemyFunc.BossCreate("Boss_3", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1", 0, 0));

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 2, 0, 0, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_8"));
                break;
            case 240:
                StartCoroutine(enemyFunc.BossCreate("Boss_4", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_9"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(7, 0, 0, "Enemy_8"));
                break;
            case 300:
                StartCoroutine(enemyFunc.BossCreate("Boss_5", 0, 0, enemyFunc.GetRandomPos()));

                StartCoroutine(enemyFunc.EnemyCreateFuncCircle("Enemy_Circle_1", 0, 0));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_10"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(5, 3f, 3f, 10, 10, 0, 0, "Enemy_10"));

                break;
            case 360:
                StartCoroutine(enemyFunc.BossCreate("Boss_6", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_10"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_5"));
                break;
            case 420:
                StartCoroutine(enemyFunc.BossCreate("Boss_7", 0, 0, enemyFunc.GetRandomPos()));

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 1, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 1, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_6", "Enemy_7", "Enemy_8"));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1", 0, 0));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_5"));
                break;
            case 480:
                StartCoroutine(enemyFunc.BossCreate("Boss_8", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_9"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 1, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1", 0, 0));
                break;
            case 540:
                StartCoroutine(enemyFunc.BossCreate("Boss_9", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1", 0, 0));

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_9"));
                break;
            case 600:
                StartCoroutine(enemyFunc.BossCreate("Boss_10", 0, 0, enemyFunc.GetRandomPos()));

                StartCoroutine(enemyFunc.EnemyCreateFuncCircle("Enemy_Circle_1", 0, 0));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 1, "Enemy_3", "Enemy_4", "Enemy_5"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(5, 3f, 3f, 10, 10, 0, 0, "Enemy_10"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_10"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 1, "Enemy_3"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 1, "Enemy_4"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 1, "Enemy_5"));
                break;
            case 660:
                StartCoroutine(enemyFunc.BossCreate("Boss_11", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_6", "Enemy_7", "Enemy_8"));

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_11"));

                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, 0, 0, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, 0, 0, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(30, 0, 0, "Enemy_8"));
                break;
            case 720:
                StartCoroutine(enemyFunc.BossCreate("Boss_12", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_9"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_15", "Enemy_16", "Enemy_17"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(15, 0, 0, "Enemy_6"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(15, 0, 0, "Enemy_7"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(15, 0, 0, "Enemy_8"));
                break;
            case 780:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_13"));
                StartCoroutine(enemyFunc.BossCreate("Boss_13", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_9"));
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_2", 100, 0));

                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_15", "Enemy_16", "Enemy_17"));
                break;
            case 840:
                StartCoroutine(enemyFunc.BossCreate("Boss_14", 0, 0, enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_14"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1f, 1f, 1, 3, 0, 0, "Enemy_15", "Enemy_16", "Enemy_17"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(20, 0, 0, "Enemy_14"));
                break;
            case 900:
                MainSingleton.instance.playerstat.BossCreate();
                StartCoroutine(enemyFunc.BossCreate("Boss_15", 0, 0, enemyFunc.GetRandomPos()));

                StartCoroutine(enemyFunc.EnemyCreateFuncBat(10, 15f, 30f, "Enemy_Bat_2", 100, 0));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(600, 1f, 1f, 1, 3, 0, 0, "Enemy_15", "Enemy_16", "Enemy_17"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(600, 1f, 1f, 1, 3, 0, 0, "Enemy_11"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(600, 1f, 1f, 1, 3, 0, 0, "Enemy_12"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(600, 1f, 1f, 1, 1, 0, 0, "Enemy_14"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(600, 1f, 1f, 1, 1, 0, 0, "Enemy_13"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(600, 30f, 30f, 30, 30, 0, 0, "Enemy_15", "Enemy_16", "Enemy_17"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_15"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_16"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, 0, 0, "Enemy_17"));
                break;
            default:
                break;
        }
    }
}
