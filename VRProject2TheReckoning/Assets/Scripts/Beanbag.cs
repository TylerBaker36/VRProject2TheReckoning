using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beanbag : MonoBehaviour
{
    private Vector3 start_pos;

    // Start is called before the first frame update
    void Start()
    {
         start_pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        gameObject.transform.position = start_pos;
    }
}
