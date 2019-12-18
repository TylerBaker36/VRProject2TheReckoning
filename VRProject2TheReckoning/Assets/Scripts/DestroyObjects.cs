using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public ScoreTrack scoreTrack;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            //Destroy(this.gameObject);

            //Teleport the cube to the origin
            gameObject.transform.position = new Vector3(0,3,0);

            scoreTrack.AddScore(1);
        }
    }
}
