using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGolfBall : MonoBehaviour
{
    public GameObject golfBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Instantiate(golfBall).transform.position = gameObject.transform.position;
        }
    }
}
