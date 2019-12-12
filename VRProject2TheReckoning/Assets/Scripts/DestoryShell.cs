using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryShell : MonoBehaviour
{
    float timer = 10f;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.time;

        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
