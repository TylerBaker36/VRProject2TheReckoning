using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    [SerializeField] GameObject blinkObj;
    [SerializeField] float activeTime;
    [SerializeField] float inactiveTime;
    [SerializeField] float objTime;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        objTime = activeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (objTime <= 0)
        {
            objTime = 0;
            if (active)
            {
                active = false;
            }
            else
            {
                active = true;
            }
        }

        if (active)
        {
            blinkObj.SetActive(true);
            objTime = activeTime;
            objTime = activeTime - Time.deltaTime;
        }
        else
        {
            blinkObj.SetActive(false);
            objTime = inactiveTime;
            objTime = inactiveTime - Time.deltaTime;
        }


    }
}
 