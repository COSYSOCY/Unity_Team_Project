using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunc : MonoBehaviour
{

    public Vector3 GetRandomPos()
    {
        float range = Random.Range(30f, 31f);
        int ran = Random.Range(0, 360);
        float x = Mathf.Cos(ran) * 1f;
        float z = Mathf.Sin(ran) * 1f;

        //float ranNum = Random.Range(-5f, 5f);
        //float x = Mathf.Cos(ranNum) * 30f;
        //float z = Mathf.Sin(ranNum) * 30f;
        Vector3 Pos = new Vector3(x, 0, z);
        Pos = MainSingleton.instance.Player.transform.position + (Pos * range);
        Pos.y = 0;
        //Debug.Log((Pos - player.position).magnitude);
        return Pos;
    }

    //횟수 ,스폰시간최소,스폰시간최대,최소몹,최대몹,에너미몹,
    public IEnumerator EnemyCreateFunc1(int cnt, float sMin, float sMax, int cMin, int cMax, params string[] g)
    {
        
        if (g.Length <= 0)
        {
            yield break;
        }

        for (int i = 0; i < cnt; i++)
        {
            int r = Random.Range(0, g.Length-1);
            int randomcnt = Random.Range(cMin, cMax);
            for (int z = 0; z < randomcnt; z++)
            {
            GameObject enemy = ObjectPooler.SpawnFromPool(g[r], GetRandomPos(), Quaternion.LookRotation(MainSingleton.instance.Player.transform.position));
                enemy.GetComponent<Enemy>().CreateStart();
            }
            yield return new WaitForSeconds(Random.Range(sMin, sMax));
        }
    }

    public IEnumerator EnemyCreateFunc2(int cnt, params string[] g)
    {
        yield return null;
        for (int z = 0; z < cnt; z++)
        {
            int r = Random.Range(0, g.Length - 1);
            GameObject enemy = ObjectPooler.SpawnFromPool(g[r], GetRandomPos(), Quaternion.LookRotation(MainSingleton.instance.Player.transform.position));
            enemy.GetComponent<Enemy>().CreateStart();
        }
    }

    public IEnumerator EnemyCreateFuncCircle(string g)
    {
        yield return null;
        Vector3 playerPos = MainSingleton.instance.Player.transform.position;
        for (int i = 0; i < 30; i++)
        {
            float x = Mathf.Cos(i) * 15f;
            float z = Mathf.Sin(i) * 15f;
            Vector3 circlePos = new Vector3(x, 0, z);
            //GameObject bat = enemyPooling.MakeEnemy("Enemy");
            Vector3 pos = playerPos + circlePos * 1.6f;
            pos.y = 0;
            GameObject bat = ObjectPooler.SpawnFromPool(g, pos);
            bat.GetComponent<Enemy>().CreateStart();
            //플레이어 위치에서 원형으로 생성
            //bat.transform.position = playerPos + circlePos;
        }
    }

    public IEnumerator EnemyCreateFuncBat(int cnt,float min,float max,string g)
    {
        //Vector3 batPos = GetRandomPos();
        Vector3 batPos = GetRandomPos() * 1.5f;
        for (int a = 0; a < cnt; a++)
        {
            for (int i = 0; i < 20; i++)
            {
                yield return null;
                //GameObject bat = enemyPooling.MakeEnemy("Bat");
                //bat.transform.position = batPos;
                GameObject bat = ObjectPooler.SpawnFromPool(g, batPos);
                bat.GetComponent<EnemyBat>().CreateStart();
            }

            yield return new WaitForSeconds(Random.Range(min,max));
        }

    }

    public IEnumerator BossCreate(string g,Vector3 pos)
    {
        yield return null;
        GameObject enemy = ObjectPooler.SpawnFromPool(g, pos, Quaternion.LookRotation(MainSingleton.instance.Player.transform.position));
        enemy.GetComponent<Enemy>().CreateStart();
    }

}
