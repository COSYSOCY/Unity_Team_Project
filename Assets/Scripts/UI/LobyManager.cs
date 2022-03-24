using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobyManager : MonoBehaviour
{
    
    public void gamestart()
    {
        Debug.Log("zx");
        SceneManager.LoadScene("Main _Test");
    }

    public void popupChara()//캐릭터 선택창 팝업시켜주는버튼함수
    {
        SceneManager.LoadScene(1);
    }

    
}
