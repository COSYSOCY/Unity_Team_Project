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
                StartCoroutine(enemyFunc.EnemyCreateFunc2(15, "Boss_1"));
                StartCoroutine(enemyFunc.EnemyCreateFunc2(1, "Enemy_Test"));
                StartCoroutine(enemyFunc.BossCreate("Boss_Test", enemyFunc.GetRandomPos()));
                break;
            default:
                break;
        }
    }
}
