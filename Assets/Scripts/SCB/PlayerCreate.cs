using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour
{
    public GameObject[] charaPrefab;
    public GameObject Player;//������ġ

    void Start()
    {
        Player = Instantiate(charaPrefab[(int)DataMGR.instance.currentChara]);
        Player.transform.position = transform.position;
    }


    void Update()
    {

    }


}
