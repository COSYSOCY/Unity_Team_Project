using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class admobTest : MonoBehaviour
{

   static public string log;


    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * 2);



        if (GUILayout.Button("��ʺ���"))
            AdmobManager.instance.go3(true);

        if (GUILayout.Button("��ʲ���"))
            AdmobManager.instance.go3(false);


        if (GUILayout.Button("����Ʈ"))
            AdmobManager.instance.go1();


        if (GUILayout.Button("������"))
            AdmobManager.instance.go2();




        GUILayout.Label(log);
    }
}
