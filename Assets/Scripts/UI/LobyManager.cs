using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobyManager : MonoBehaviour
{
    
    public void gamestart()
    {
        SceneManager.LoadScene("Main");
    }

    public void popupChara()//ĳ���� ����â �˾�����ִ¹�ư�Լ�
    {
        SceneManager.LoadScene("Main");
    }

    
}
