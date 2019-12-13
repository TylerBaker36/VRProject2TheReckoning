using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfRespawner : MonoBehaviour
{
    public Transform target;
    public Transform respawner;

    public void TeleportBall(GameObject gameObject)
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.position = respawner.position;
        rigidbody.velocity = new Vector3(0, 0, 0);
    }
}
