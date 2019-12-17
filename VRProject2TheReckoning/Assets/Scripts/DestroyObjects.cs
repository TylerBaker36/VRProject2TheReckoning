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
            Destroy(this.gameObject);
            scoreTrack.AddScore(1);
        }
    }
}
