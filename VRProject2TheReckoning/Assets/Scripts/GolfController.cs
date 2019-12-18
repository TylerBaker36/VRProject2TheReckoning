using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "Target")
        {
            //GolfRespawner golfRespawner = gameObject.transform.parent.GetComponent<GolfRespawner>();
            //this.transform.position = golfRespawner.respawner.position;

            gameObject.transform.parent.GetComponent<GolfRespawner>().TeleportBall(this.gameObject);
        }
    }
}
