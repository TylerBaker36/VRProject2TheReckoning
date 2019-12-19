using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveTo : MonoBehaviour
{
    [SerializeField] Transform nextLocation;
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;
    [SerializeField] bool alwaysOn;
    [SerializeField] bool completed;

    float startTime = 0;
    [SerializeField] float speed;
    [SerializeField] float deltaTime = 0;
    [SerializeField] float lerpAmount;

    [SerializeField] float delay = 1;
    float waitTimer = 1;

    float pointDistance;
    [SerializeField] float objectDistance;


    // Start is called before the first frame update
    void Start()
    {
        deltaTime = startTime;
        nextLocation = PointB;
        waitTimer = delay;
    }

    // Update is called once per frame
    void Update()
    {

        pointDistance = Vector3.Distance(PointA.position, PointB.position);
        objectDistance = Vector3.Distance(transform.position, nextLocation.position);

        deltaTime += Time.deltaTime;

        lerpAmount = (speed * deltaTime) / pointDistance;

        if(objectDistance <= .01f)
        {
            transform.position = nextLocation.position;
        }
        if (transform.position == nextLocation.position)
        {
            completed = true;
        }

        if (completed)
        {
            waitTimer -= Time.deltaTime;
            deltaTime = 0;
        }
        if (transform.position == PointB.position  && waitTimer <= startTime)
        {
            completed = false;
            nextLocation = PointA;
            waitTimer = delay;
        }

        if (alwaysOn && transform.position == PointA.position && waitTimer <= startTime)
        {
            completed = false;
            nextLocation = PointB;
            waitTimer = delay;
        }
        MoveToLocation();
    }

    void MoveToLocation()
    {
        transform.position = Vector3.Lerp(transform.position, nextLocation.position, lerpAmount);
    }
}
