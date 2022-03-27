using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger5 : MonoBehaviour
{
    public PlayerInfo info;
    public UIManager ui;
    public PlayerStatus stat;
    public EnemyManager manager;
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
            case 30:
                stat.EnemyMax += 10;
                break;
            case 60:
                stat.EnemyMax += 10;
                stat.EnemyDes("Enemy_1", 0);
                stat.EnemyCreateName[0] = "Enemy_2";
                break;
            case 90:
                stat.EnemyMax += 10;
                stat.EnemyCreateName[0] = "Enemy_2";
                break;
            case 120:
                stat.EnemyMax += 20;
                stat.EnemyDes("Enemy_2", 1);
                stat.EnemyCreateName[0] = "Enemy_3";
                break;
            case 180:
                stat.EnemyMax += 20;
                stat.EnemyDes("Enemy_3", 2);
                stat.EnemyCreateName[0] = "Enemy_4";
                break;
            case 240:
                stat.EnemyMax += 20;
                stat.EnemyDes("Enemy_4", 3);
                stat.EnemyCreateName[0] = "Enemy_5";
                break;
            case 300:
                stat.EnemyMax += 10;
                break;
            case 360:
                stat.EnemyMax += 10;
                break;
            case 420:
                stat.EnemyMax += 10;
                break;
            case 480:
                break;

            default:
                break;
        }
    }
}
