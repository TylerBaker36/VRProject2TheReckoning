using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornHole : MonoBehaviour
{
    private int beanbag_count = 8;
    private GameObject[] beanbags;
    private GameObject last_bag_held;
    //private bool all_thrown;

    [SerializeField] private GameObject scoreKeeper;

    /*private void Start()
    {
        all_thrown = false;
    }*/

    private void Update()
    {
        /*if (last_bag_held != null)
        {
            if (last_bag_held.GetComponent<Beanbag>().getPickedUp())
                last_bag_held.GetComponent<Beanbag>().updateThrown(); // if the bag has been held, now check if it's been thrown
        }*/
        if (beanbag_count == 0)
        {
            /*all_thrown = true;
            foreach (GameObject b in beanbags)
            {
                if ((!b.GetComponent<Beanbag>().getThrown()) || (!b.GetComponent<Beanbag>().getPickedUp()))
                {
                    all_thrown = false; // if we find one that hasn't been thrown or picked up, all_thrown set to false
                }
            }
            if (all_thrown)*/
            if (!last_bag_held.GetComponent<OVRGrabbable>().isGrabbed)
                StartCoroutine(wait_then_reset(5.0f)); // reset positions in coroutine
        }
    }

    // Each time something exits the stagingarea, check if it's a beanbag
    private void OnTriggerExit(Collider CheckBags)
    {
        if (this.name == "StagingArea")
        {
            //Debug.Log(this.name);
            if (CheckBags.gameObject.CompareTag("Beanbag"))
            {
                beanbag_count--;
                last_bag_held = CheckBags.gameObject;
                //last_bag_held.GetComponent<Beanbag>().updatePickedUp();
            }
        }
    }

    private void OnTriggerEnter(Collider GoalTriggers)
    {
        if (GoalTriggers.gameObject.CompareTag("Beanbag"))
        {
            if (this.name == "GoalTrigger")
            {
                // We scored! Only give 2 points here (out of the full 3) because passing through the board trigger will always yield a point
                scoreKeeper.GetComponent<ScoreKeeper>().Score(2);
            }
            else if (this.name == "BoardTrigger")
            {
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
        //while (last_bag_held.gameObject.GetComponent<Beanbag>().updatePickedUp() != false)
        //{
            // block until the last bag has left player's hands
        //}
        foreach (GameObject b in beanbags)
        {
            b.GetComponent<Beanbag>().Respawn();
        }
        beanbag_count = 4;
        //all_thrown = false;
        scoreKeeper.GetComponent<ScoreKeeper>().RoundReset(); // Reset round but not overall score
    }
}
