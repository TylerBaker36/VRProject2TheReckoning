using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRotation;
    private Vector3 startVelocity;
    private Rigidbody rb;
    private CharacterController cc;

    void Awake()
    {
        startPos = transform.position;
        startRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        if (rb) startVelocity = rb.velocity;
        if (cc) startVelocity = cc.velocity;
    }

    public void ResetTransform()
    {
        transform.position = startPos;
        transform.rotation = startRotation;
        if (rb) rb.velocity = startVelocity;
        else if (cc) cc.velocity.Set(startVelocity.x, startVelocity.y, startVelocity.z);
    }
}
