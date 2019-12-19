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

        gameObject.transform.parent.GetComponent<ScoreTrack>().AddScore(1);
    }
}
