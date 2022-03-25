using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public SkillManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.Skills[DataBus.CharNum].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
