using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGolfBall : MonoBehaviour
{
    public GameObject golfBall;

    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Instantiate(golfBall).transform.position = gameObject.transform.position;
        }
    }
}
