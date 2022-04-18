using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdRotate : MonoBehaviour
{
        public void Update()
        {

        transform.Rotate(0, 200f * Time.deltaTime, 0);
        }

}
