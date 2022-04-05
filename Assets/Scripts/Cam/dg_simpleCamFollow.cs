//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class dg_simpleCamFollow : MonoBehaviour
{
    public Transform target;
    //[Range(1f,100f)] public float laziness = 10f;
    public bool lookAtTarget = true;
    public bool takeOffsetFromInitialPos = true;
    public Vector3 generalOffset;
    Vector3 whereCameraShouldBe;
    bool warningAlreadyShown = false;
    public float camspeed;

    private void Start() {
        if (takeOffsetFromInitialPos && target != null) generalOffset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (target != null) {
            whereCameraShouldBe = target.position + generalOffset;
            transform.DOMove(whereCameraShouldBe, camspeed);
            //transform.position = Vector3.Lerp(transform.position, whereCameraShouldBe, (1 / laziness)*Time.deltaTime);

            if (lookAtTarget) transform.LookAt(target);
        } else {
            if (!warningAlreadyShown) {
                Debug.Log("Warning: You should specify a target in the simpleCamFollow script.", gameObject);
                warningAlreadyShown = true;
            }
        }
    }
}
