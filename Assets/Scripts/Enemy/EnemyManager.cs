using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    //EnemyPooling enemyPooling;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform player;

    //�ð� ����
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
    //���� ������ �߰�
    public Vector3 GetRandomPos()
    {
        float range = Random.Range(25f, 27f);
        int ran = Random.Range(0, 360);
        float x = Mathf.Cos(ran) * 1f;
        float z = Mathf.Sin(ran) * 1f;

        //float ranNum = Random.Range(-5f, 5f);
        //float x = Mathf.Cos(ranNum) * 30f;
        //float z = Mathf.Sin(ranNum) * 30f;
        Vector3 Pos = new Vector3(x, 0, z);
        Pos = player.position + (Pos * range);
        //Debug.Log((Pos - player.position).magnitude);
        return Pos;
    }

    public Vector3 RandomSphereInPoint()
    {
        float radius = Random.Range(60f, 70f);
        Vector3 getPoint = Random.onUnitSphere;
        getPoint.y = 0.0f;
        return (getPoint * radius) + player.transform.position;
    }

    IEnumerator CreateEnemyTrigger()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            if (playerstat.EnemyCnt < playerstat.EnemyMax)
            {
                int i = Random.Range(0, playerstat.EnemyCreateRan);
                GameObject enemy = ObjectPooler.SpawnFromPool(playerstat.EnemyCreateName[i], GetRandomPos(), Quaternion.LookRotation(player.transform.position));
                enemy.GetComponent<Enemy>().CreateStart();
                playerstat.EnemyCnt++;
            }
            //else
            //{
            //    yield return new WaitForSeconds(2f);
            //    int i = Random.Range(0, playerstat.EnemyCreateRan);
            //    GameObject enemy = ObjectPooler.SpawnFromPool(playerstat.EnemyCreateName[i], GetRandomPos(), Quaternion.LookRotation(player.transform.position));
            //    enemy.GetComponent<Enemy>().CreateStart();
            //    playerstat.EnemyCnt++;
            //}

            yield return new WaitForSeconds(0.1f);
        }
    }
    //---------------------------------
    IEnumerator CallEnemy()
    {
        yield return new WaitForSeconds(2f);
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
                //���� ��ġ�� �÷��̾� ������ġ �߰�(��������)
                //enemy.transform.position = GetRandomPos();
                //���� ������ �߰�
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
                        GameObject bat = ObjectPooler.SpawnFromPool("Enemy_Bat", batPos);
                        bat.GetComponent<EnemyBat>().CreateStart();
                    }
                }
                //���� ������ �߰�
                else if (playTime >= circleTime)
                {
                    circleTime *= 2;
                    //�÷��̾��� ��ġ
                    Vector3 playerPos = player.transform.position;
                    for (int i = 0; i < 30; i++)
                    {
                        float x = Mathf.Cos(i) * 15f;
                        float z = Mathf.Sin(i) * 15f;
                        Vector3 circlePos = new Vector3(x, 0, z);
                        //GameObject bat = enemyPooling.MakeEnemy("Enemy");
                        GameObject bat = ObjectPooler.SpawnFromPool("Enemy_6", playerPos + circlePos*1.6f);
                        bat.GetComponent<Enemy>().CreateStart();
                        //�÷��̾� ��ġ���� �������� ����
                        //bat.transform.position = playerPos + circlePos;
                    }
                }
            }
            else yield return null;
        }
    }
}