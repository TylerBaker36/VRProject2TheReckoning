using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class ColliderEvent : UnityEvent<Collider>
{

}

public class ButtonScript : MonoBehaviour
{
    public ColliderEvent buttonPress;
    public ColliderEvent buttonStay;
    public ColliderEvent buttonRelease;

    private Button uiButton;

    // Start is called before the first frame update
    void Start()
    {
        if (buttonPress == null) buttonPress = new ColliderEvent();
        if (buttonStay == null) buttonStay = new ColliderEvent();
        if (buttonRelease == null) buttonRelease = new ColliderEvent();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //If the button has moved less than a threshold distance, move the button in the direction Vector3.down such that it's top surface is touching the collision point.
        buttonPress.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        //Else if the collision with actors is still occuring, do nothing.
        buttonStay.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        //Else if the collision is no longer occuring, move the button back to it's default position.
        buttonRelease.Invoke(other);
    }
}
