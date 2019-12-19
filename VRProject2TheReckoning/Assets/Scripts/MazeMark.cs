using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMark : MonoBehaviour
{
    public GameObject mark;

    // Start is called before the first frame update
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown("z"))
        {
            Vector3 spawnPosition = transform.position;
            Vector3 direction = Quaternion.Euler(0, 180, 10) * Vector3.right;
            spawnPosition = transform.position + direction * 2;
            Instantiate(mark, spawnPosition, Quaternion.identity);
            }

    }
}


