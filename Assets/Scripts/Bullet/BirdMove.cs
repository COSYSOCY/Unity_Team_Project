using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        transform.position = Player.transform.position;
    }
}
