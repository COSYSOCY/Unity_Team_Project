using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start_00 : MonoBehaviour
{


    void Update()
    {
        if (Input.GetMouseButtonUp(0)&&GameInfo.inst.GameStart)
        {
            StartCoroutine(ServerDataSystem.inst.LoadData());
            
        }
    }

}
