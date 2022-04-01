using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger2 : MonoBehaviour
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

    public void tiemtrigger(float t)
    {
        switch (t)
        {
            case 1:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_2"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(10, "Enemy_2"));
                break;
            case 60:
                StartCoroutine(enemyFunc.BossCreate("Boss_1", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(120, 1, 1, 1, 1, "Enemy_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(120, 1, 1, 1, 1, "Enemy_3", "Enemy_4", "Enemy_5"));
                break;
            case 120:
                StartCoroutine(enemyFunc.EnemyCreateFuncBat(3, 15f, 30f, "Enemy_Bat_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(60, 1, 1, 1, 1, "Enemy_1"));
                break;
            case 130:
                stat.EnemyDes("Enemy_3", 2);
                stat.EnemyDes("Enemy_4", 3);
                stat.EnemyDes("Enemy_5", 4);
                break;
            case 180:
                StartCoroutine(enemyFunc.BossCreate("Boss_1", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFunc1(120, 0.5f, 0.5f, 1, 1, "Enemy_6", "Enemy_7", "Enemy_8"));
                break;
            case 240:
                StartCoroutine(enemyFunc.EnemyCreateFunc1(120, 0.5f, 0.5f, 1, 1, "Enemy_9"));
                break;
            case 300:
                StartCoroutine(enemyFunc.BossCreate("Boss_2", enemyFunc.GetRandomPos()));
                StartCoroutine(enemyFunc.EnemyCreateFuncCircle("Enemy_Circle_1"));
                break;
            case 360:

                break;
            default:
                break;
        }
    }
}
