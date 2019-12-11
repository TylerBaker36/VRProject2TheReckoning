using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveTo : MonoBehaviour
{
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;
    [SerializeField] bool alwaysOn;
    [SerializeField] float moveTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (transform.position == PointA.position)
        {
            transform.position = Vector3.MoveTowards(PointA.position, PointB.position, moveTime * Time.deltaTime);
        }
        else if (transform.position == PointB.position)
        {
            transform.position = Vector3.MoveTowards(PointB.position, PointA.position, moveTime * Time.deltaTime);
        }
    }
}
