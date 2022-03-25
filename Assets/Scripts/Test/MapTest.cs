using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class mapcheck
{
    public string Name;
    public string info;
    public Sprite image;

}
public class MapTest : MonoBehaviour
{
    public List<mapcheck> map;
    public int mapIdx = 0;
    public Image mapimage;
    public Text 제목;
    public Text 설명;



    public void 입장()
    {
        Debug.Log("다음씬");

    }

    public void 화살표()
    {

    }
}
