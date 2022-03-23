using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLockon : MonoBehaviour
{
    private PlayerMoving playerMoving;
    private Transform Target = null;
    public float Range;
    public LayerMask layerMask;
    private Vector3 targetPosition;
    void Start()
    {
        playerMoving = GetComponent<PlayerMoving>();
    }
    void Update()
    {
        UpdateTarget();
    }
    void UpdateTarget()
    {
            Collider[] colliders = Physics.OverlapSphere(transform.position, Range, layerMask);
            Transform nearTarget = null;
            if (colliders.Length > 0)
            {
                float shortDistance = Mathf.Infinity;
                foreach (Collider collider in colliders)
                {
                    float Distance = Vector3.SqrMagnitude(transform.position - collider.transform.position);
                    if (shortDistance > Distance)
                    {
                        shortDistance = Distance;
                        nearTarget = collider.transform;
                    }
                }
            }
            Target = nearTarget;
            if (Target != null)
            {
                targetPosition = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);
                gameObject.transform.LookAt(targetPosition);
            }
        }
    }
