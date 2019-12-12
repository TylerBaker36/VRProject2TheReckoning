using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beanbag : MonoBehaviour
{
    private Vector3 start_pos;
    public bool picked_up; // Set to true first time the beanbag is picked up
    public bool thrown; // Set to true first time the beanbag is thrown

    // Start is called before the first frame update
    void Start()
    {
        start_pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        picked_up = false;
        thrown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool getPickedUp() { return picked_up; }
    public bool getThrown() { return thrown; }

    public bool updatePickedUp()
    {
        if (this.GetComponent<OVRGrabbable>().isGrabbed)
            picked_up = true;
        else
            picked_up = false;
        return picked_up;
    }

    public bool updateThrown()
    {
        if (this.GetComponent<OVRGrabbable>().isGrabbed)
            thrown = false;
        else
            thrown = false;
        return thrown;
    }

    public void Respawn()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.position = start_pos;
        picked_up = false;
    }
}
