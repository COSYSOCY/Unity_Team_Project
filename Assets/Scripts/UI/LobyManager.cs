using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobyManager : MonoBehaviour
{

    public void gamestart()
    {
        Debug.Log("zx");
        SceneManager.LoadScene("Main");
    }

}
