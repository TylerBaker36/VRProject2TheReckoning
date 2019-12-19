using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGolfBall : MonoBehaviour
{
    public GameObject golfBall;

    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            Instantiate(golfBall).transform.position = gameObject.transform.position;
        }

        //Remove all the balls and regenerate the ball to the origins
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in balls)
            {
                Destroy(ball);
            }

            GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
            foreach (GameObject target in targets)
            {
                target.transform.parent.GetComponent<GolfRespawner>().GenerateBall(golfBall);
            }
        }
    }
}
