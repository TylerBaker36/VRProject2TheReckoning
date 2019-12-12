using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ShootableObj")
        {
            Destroy(this.gameObject);
        }
    }

    float timeLeft = 10f;
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
