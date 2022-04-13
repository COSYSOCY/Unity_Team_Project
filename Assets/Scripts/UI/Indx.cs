using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indx : MonoBehaviour
{
    public int Idx;
    public MissionManager manager;

    public void Func()
    {
        manager.Func(Idx);
    }


}
