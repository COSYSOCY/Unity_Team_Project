using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyPooling enemyPooling;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform player;

    //시간 관련
    private float playTime;
    private float batTime = 20f;
    private float circleTime = 30f;

    private bool isGameOver;
    private float respawnTime = 0.3f;
    private int maxEnemy = 1000;
    void Start()
    {
        enemyPooling = GameObject.Find("EnemyMakePool").GetComponent<EnemyPooling>();
        StartCoroutine(CallEnemy());
    }
    private void Update()
    {
        playTime += Time.deltaTime;
    }
    //원형 리스폰 추가
    public Vector3 GetRandomPos()
    {
        float radius = 30f;
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
                GameObject enemy = enemyPooling.MakeEnemy("Enemy");
                //랜덤 위치에 플레이어 현재위치 추가(수정사항)
                enemy.transform.position = GetRandomPos();
                //박쥐 리스폰 추가
                if (playTime >= batTime)
                {
                    batTime *= 2;
                    Debug.Log(batTime);
                    Vector3 batPos = GetRandomPos();
                    for (int i = 0; i < 20; i++)
                    {
                        yield return new WaitForSeconds(0.03f);
                        GameObject bat = enemyPooling.MakeEnemy("Bat");
                        bat.transform.position = batPos;
                    }
                }
                //원형 리스폰 추가
                else if (playTime >= circleTime)
                {
                    circleTime *= 2;
                    for (int i = 0; i < 30; i++)
                    {
                        float x = Mathf.Cos(i) * 15f;
                        float z = Mathf.Sin(i) * 15f;
                        Vector3 circlePos = new Vector3(x, 0, z);
                        GameObject bat = enemyPooling.MakeEnemy("Enemy");
                        bat.transform.position = circlePos;
                    }

                }
            }

            else yield return null;
        }
    }
}