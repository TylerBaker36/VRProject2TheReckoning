using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornHole : MonoBehaviour
{
    private int beanbag_count = 4;
    private GameObject[] beanbags;

    private void OnTriggerExit(Collider CheckBags)
    {
        if(CheckBags.gameObject.CompareTag("Beanbag"))
        {
            beanbag_count--;
        }

        if(beanbag_count == 0)
        {
            StartCoroutine(wait());
            // reset positions
            if (beanbags == null)
                beanbags = GameObject.FindGameObjectsWithTag("Beanbag");
            foreach (GameObject b in beanbags)
            {
                b.GetComponent<Beanbag>().Respawn();
            }
            beanbag_count = 4;
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
