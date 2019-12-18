using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent buttonPress;
    public UnityEvent buttonStay;
    public UnityEvent buttonRelease;

    // Start is called before the first frame update
    void Start()
    {
        if (buttonPress == null)
        {
            buttonPress = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //If the button has moved less than a threshold distance, move the button in the direction Vector3.down such that it's top surface is touching the collision point.
        //Else if the collision with actors is still occuring, do nothing
        //Else if the collision is no longer occuring, move the button back to it's default position.
        buttonPress.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        buttonStay.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        buttonRelease.Invoke();
    }
}
