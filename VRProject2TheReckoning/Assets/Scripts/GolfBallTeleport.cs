using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallTeleport : MonoBehaviour
{
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;
    Ball ballScipt;
    bool inTeleport;

    // Start is called before the first frame update
    void Start()
    {
        PointA = GetComponent<GameObject>().transform;
        ballScipt = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inTeleport)
        {
            ballScipt.transform.position = PointB.position;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GetComponent<Ball>().gameObject)
        {
            inTeleport = true;
        }
        else
        {
            inTeleport = false;
        }
            
    }
}
