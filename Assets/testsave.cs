using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testsave : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().text = PlayerPrefs.GetString("Save");
    }
}
