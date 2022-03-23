using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdRotate : MonoBehaviour
{
    
        public GameObject circle;
        
        public float speed = 100;
        
    

        public void Start()
        {
                      
        }

        public void Update()
        {
            circle = GameObject.Find("Player");
            OrbitAround();
        }

        public void OrbitAround()
        {            
            transform.RotateAround(circle.transform.position, Vector3.down, speed * Time.deltaTime);
        }
    
}
