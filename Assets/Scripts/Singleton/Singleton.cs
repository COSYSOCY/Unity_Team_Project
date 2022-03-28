using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ca-app-pub-9521969151385232~5659420556
public class Singleton : MonoBehaviour
{
    private static Singleton instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public static Singleton Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
}
