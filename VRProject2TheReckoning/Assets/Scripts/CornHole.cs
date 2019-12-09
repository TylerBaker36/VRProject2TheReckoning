using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornHole : MonoBehaviour
{
    private int beanbag_count = 4;
    private GameObject[] beanbags;

    [SerializeField] private GameObject scoreKeeper;

    // Handles reseting the beanbags on round end
    private void OnTriggerExit(Collider CheckBags)
    {
        if (CheckBags.gameObject.name == "StagingArea")
        {
            if (CheckBags.gameObject.CompareTag("Beanbag"))
            {
                beanbag_count--;
            }

            if (beanbag_count == 0)
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
    }

    private void OnTriggerEnter(Collider GoalTriggers)
    {
        if (GoalTriggers.gameObject.name == "Goal Trigger")
        {

        }
        else if (GoalTriggers.gameObject.name == "Board Trigger")
        {

        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
