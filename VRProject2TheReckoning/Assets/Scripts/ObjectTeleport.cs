using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTeleport : MonoBehaviour
{
    Ball ballObject;
    Rigidbody objectRB;
    [SerializeField] GameObject start;
    [SerializeField] GameObject destination;
    bool inLocation = false;
    [SerializeField] bool teleport = false;

    void Start()
    {
        ballObject = FindObjectOfType<Ball>();
        objectRB = ballObject.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        start = other.gameObject;
        if (other.gameObject == ballObject.gameObject)
        {
            ballObject.gameObject.transform.position = destination.transform.position;
        }
    }
}
