using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        transform.LookAt(target);
        transform.Rotate(Vector3.up, 180.0f);
    }
}
