using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdRotate : MonoBehaviour
{
    
        public GameObject circle;
        
        public float speed = 100;
        
    

        public void Start()
        {
        circle = GameObject.Find("SkillObject");
    }

        public void Update()
        {
            
            OrbitAround();
        }

        public void OrbitAround() // �÷��̾� ���� ����
        {            
            transform.RotateAround(circle.transform.position, Vector3.down, speed * Time.deltaTime);
        }
    
}
