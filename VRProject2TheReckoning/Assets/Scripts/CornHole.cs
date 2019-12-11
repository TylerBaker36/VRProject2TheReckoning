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
        if (this.name == "StagingArea")
        {
            //Debug.Log(this.name);
            if (CheckBags.gameObject.CompareTag("Beanbag"))
            {
                beanbag_count--;
                //Debug.Log("Beanbag count: " + beanbag_count);
            }

            if (beanbag_count == 0)
            {
                Debug.Log("STARTING CO-ROUTINE - Beanbag count: " + beanbag_count);
                StartCoroutine(wait_then_reset(3.0f)); // reset positions in coroutine
            }
        }
    }

    private void OnTriggerEnter(Collider GoalTriggers)
    {
        if (this.name == "GoalTrigger")
        {
            if (GoalTriggers.gameObject.CompareTag("Beanbag"))
            {
                Debug.Log("GOAL!!! SCORE: " + scoreKeeper.GetComponent<ScoreKeeper>().getRoundScore() + " " + GoalTriggers.gameObject.name);
                // We scored! Only give 2 points here (out of the full 3) because passing through the board trigger will always yield a point
                scoreKeeper.GetComponent<ScoreKeeper>().Score(2);
            }
        }
        else if (this.name == "BoardTrigger")
        {
            if (GoalTriggers.gameObject.CompareTag("Beanbag"))
            {
                Debug.Log("BOARD. SCORE: " + scoreKeeper.GetComponent<ScoreKeeper>().getRoundScore() + " " + GoalTriggers.gameObject.name);
                // Since it is impossible to score in the goal without passing through the board trigger, always award 1 point even to those who just pass through (for now)
                scoreKeeper.GetComponent<ScoreKeeper>().Score(1);
            }
        }
    }

    private IEnumerator wait_then_reset(float f)
    {
        yield return new WaitForSeconds(f);
        if (beanbags == null)
            beanbags = GameObject.FindGameObjectsWithTag("Beanbag");
        foreach (GameObject b in beanbags)
        {
            b.GetComponent<Beanbag>().Respawn();
        }
        beanbag_count = 4;
        scoreKeeper.GetComponent<ScoreKeeper>().RoundReset(); // Reset round but not overall score
    }
}
