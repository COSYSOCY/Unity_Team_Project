using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRanObj : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject[] objPos;
    private float createTime = 1;
    void Start()
    {
        StartCoroutine(CreatObj());
    }

    IEnumerator CreatObj()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            objPos = GameObject.FindGameObjectsWithTag("MapRanObj");
            if (objPos.Length > 0)
            {
                Debug.Log("ÃâÇö");
                int ranPoint = Random.Range(1, objPos.Length);
                GameObject ranObj = Instantiate(obj, objPos[ranPoint].transform.position, objPos[ranPoint].transform.rotation);
                yield return new WaitForSeconds(createTime);
            }
        }
    }
}

