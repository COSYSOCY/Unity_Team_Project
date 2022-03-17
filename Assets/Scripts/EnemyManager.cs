using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyPooling enemyPooling;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform player;

    private bool isGameOver;
    private float respawnTime = 1f;
    private int maxEnemy = 50;
    void Start()
    {
        enemyPooling = GameObject.Find("EnemyMakePool").GetComponent<EnemyPooling>();
        StartCoroutine(CallEnemy());
    }
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

        Vector3 randomPos = new Vector3(x, 1, z);
        return randomPos;
    }
    IEnumerator CallEnemy()
    {
        while(!isGameOver)
        {
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (enemyCount < maxEnemy)
            {
                yield return new WaitForSeconds(respawnTime);
                GameObject enemy = enemyPooling.MakeEnemy("Enemy");
                enemy.transform.position = GetRandomPos();
            }
            else yield return null;
        }
    }
}
