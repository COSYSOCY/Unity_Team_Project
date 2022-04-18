using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBus : MonoBehaviour
{
    static DataBus inst;
    public static int MapNum=0;
    public static int CharNum=0;
    void Awake()
    {
        inst = this;
    }
}
