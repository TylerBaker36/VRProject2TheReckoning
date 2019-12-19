using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfRespawner : MonoBehaviour
{
    public Transform target;
    public Transform respawner;

    public void TeleportBall(GameObject gameObject)
    {
        gameObject.transform.position = respawner.position;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    public void GenerateBall(GameObject gameObject)
    {
        Instantiate(gameObject, respawner.transform);
    }
}
