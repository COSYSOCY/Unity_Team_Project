using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject[] enemy;

    public GameObject[] ObjectPool;

    private void Awake()
    {
        enemy = new GameObject[50];
        Generate();
    }
    void Generate()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = Instantiate(enemyPrefab);
            enemy[i].SetActive(false);
        }
    }
    public GameObject MakeEnemy(string type)
    {
        switch (type)
        {
            case "Enemy":
                ObjectPool = enemy;
                break;
            default:
                break;
        }
        for (int i = 0; i < ObjectPool.Length; i++)
        {
            if (!ObjectPool[i].activeSelf)
            {
                ObjectPool[i].SetActive(true);
                return ObjectPool[i];
            }
        }
        return null;
    }
}
