using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 startVelocity;
    private Rigidbody rb;
    private CharacterController cc;

    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;

        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        if (rb) startVelocity = rb.velocity;
    }

    public void ResetTransform()
    {
        transform.position = startPos;
        if (rb) rb.velocity = startVelocity;
        else if (cc) cc.SimpleMove(Vector3.zero);
    }
}
