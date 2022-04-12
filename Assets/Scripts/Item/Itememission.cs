using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Itememission : MonoBehaviour
{
    public Material itemObj;
    public void Start()
    {
        //itemObj.SetColor("_EmissionColor", new Color(87,56,56) * -5);
    }

    IEnumerator ItemLed()
    {        
        yield return null;
    }
}
