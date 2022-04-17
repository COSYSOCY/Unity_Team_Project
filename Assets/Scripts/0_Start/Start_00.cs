using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start_00 : MonoBehaviour
{
    bool check = false;

    void Update()
    {
        return;
        if (Input.GetMouseButtonUp(0)&&GameInfo.inst.GameStart&&!check)
        {
            check = true;
            //StartCoroutine(ServerDataSystem.inst.LoadData());
            ServerDataSystem.inst.LoadData2();
           // Destroy(gameObject);    
        }
    }

}
