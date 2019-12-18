using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private bool useLocalScale = true;
    private Vector3 startPos;
    private Quaternion startRotation;
    private Vector3 startScale;
    private Vector3 startVelocity;
    private Rigidbody rb;
    private CharacterController cc;

    void Awake()
    {
        startPos = transform.position;
        startRotation = transform.rotation;

        if (useLocalScale) startScale = transform.localScale;
        else startScale = transform.lossyScale;

        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        if (rb) startVelocity = rb.velocity;
        if (cc) startVelocity = cc.velocity;
    }

    public void ResetTransform()
    {
        transform.position = startPos;
        transform.rotation = startRotation;

        transform.localScale = startScale;

        if (rb) rb.velocity = startVelocity;
        else if (cc) cc.velocity.Set(startVelocity.x, startVelocity.y, startVelocity.z);
    }
}
