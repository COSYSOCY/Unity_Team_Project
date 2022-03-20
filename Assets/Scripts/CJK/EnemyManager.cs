using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //EnemyPooling enemyPooling;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform player;

    //시간 관련
    private float playTime;
    [SerializeField] private float batTime;
    [SerializeField] private float circleTime;
    [SerializeField] private float respawnTime;

    public PlayerStatus playerstat;
    private bool isGameOver;

    private int maxEnemy = 1000;
    void Start()
    {
       // enemyPooling = GameObject.Find("EnemyMakePool").GetComponent<EnemyPooling>();
        StartCoroutine(CallEnemy());
        StartCoroutine(CreateEnemyTrigger());

    }
    private void Update()
    {
        playTime += Time.deltaTime;
    }
    //원형 리스폰 추가
    public Vector3 GetRandomPos()
    {
        float radius = Random.Range(30f,40f);
        Vector3 playerPos = player.transform.position;

        float a = playerPos.x;
        float b = playerPos.y;

        float x = Random.Range(-radius + a, radius + a);
        float z_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));
        z_b *= Random.Range(0, 2) == 0 ? -1 : 1;
        float z = z_b + b;

        Vector3 randomPos = new Vector3(x, 0, z);
        return randomPos;
    }

    IEnumerator CreateEnemyTrigger()
    {
        while (true)
        {
            if (playerstat.EnemyCnt < playerstat.EnemyMax)
            {
                int i = Random.Range(0, playerstat.EnemyCreateRan);
                GameObject enemy = ObjectPooler.SpawnFromPool(playerstat.EnemyCreateName[i], GetRandomPos(), Quaternion.LookRotation(player.transform.position));
                playerstat.EnemyCnt++;
                
            }
            else
            {
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
    //---------------------------------
    IEnumerator CallEnemy()
    {
        yield return new WaitForSeconds(1f);
        while (!isGameOver)
        {
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemyCount < maxEnemy)
            {
                yield return new WaitForSeconds(respawnTime);
                //GameObject enemy = enemyPooling.MakeEnemy("Enemy");
                //Vector3 enemypos = Vector3.
                //enemy.transform.Translate(Vector3.forward * 33f);
                //enemy.transform.LookAt(player.transform);
                //랜덤 위치에 플레이어 현재위치 추가(수정사항)
                //enemy.transform.position = GetRandomPos();
                //박쥐 리스폰 추가
                if (playTime >= batTime)
                {
                    batTime *= 2;
                    //Debug.Log(batTime);
                    Vector3 batPos = GetRandomPos();
                    for (int i = 0; i < 20; i++)
                    {
                        yield return new WaitForSeconds(0.03f);
                        //GameObject bat = enemyPooling.MakeEnemy("Bat");
                        //bat.transform.position = batPos;
                        GameObject bat = ObjectPooler.SpawnFromPool("Enemy_Bat", GetRandomPos());
                    }
                }
                //원형 리스폰 추가
                else if (playTime >= circleTime)
                {
                    circleTime *= 2;
                    //플레이어의 위치
                    Vector3 playerPos = player.transform.position;
                    for (int i = 0; i < 30; i++)
                    {
                        float x = Mathf.Cos(i) * 15f;
                        float z = Mathf.Sin(i) * 15f;
                        Vector3 circlePos = new Vector3(x, 0, z);
                        //GameObject bat = enemyPooling.MakeEnemy("Enemy");
                        GameObject bat = ObjectPooler.SpawnFromPool("Enemy_1", playerPos + circlePos*1.6f);
                        //플레이어 위치에서 원형으로 생성
                        //bat.transform.position = playerPos + circlePos;
                    }
                }
            }

            else yield return null;
        }
    }
}