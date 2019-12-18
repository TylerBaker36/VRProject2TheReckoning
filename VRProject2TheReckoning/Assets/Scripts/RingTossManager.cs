using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RingTossManager : MonoBehaviour
{
    /// <summary>
    /// The number of tries, opportunities, or throws before the round is reset.
    /// </summary>
    [SerializeField] private int numTries = 3;
    [SerializeField] private int pointsPerLine = 1;
    [SerializeField] private ScoreKeeper scoreKeeper;
    [SerializeField] private Transform[] throwingLines = null;
    [SerializeField] private GameObject player;

    private static int countMoved;
    private static int countStill;
    private bool reset = false;

    private RingManager[] rings;
    private DetectThrow[] throwers;

    // Start is called before the first frame update
    private void Awake()
    {
        rings = FindObjectsOfType<RingManager>();
        if (scoreKeeper == null)
        {
            scoreKeeper = FindObjectOfType<ScoreKeeper>();
            if (scoreKeeper == null)
            {
                Debug.LogWarning("Scorekeeper is unable to be found in scene.");
            }
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) Debug.LogWarning("Player not found.");
        }
        //throwers = FindObjectsOfType<DetectThrow>();
        //for (int i = 0; i < throwers.Length; i++)
        //{
        //    if(throwers[i].ThrowEvent == null)
        //    {
        //        throwers[i].ThrowEvent = new myGameObjectEvent();
        //    }
        //    throwers[i].ThrowEvent.AddListener(CheckThrowingLines);
        //}
    }

    public void IncrementMovedCount()
    {
        countMoved++;
    }

    // Update is called once per frame
    void Update()
    {
        countStill = 0;
        foreach( RingManager ring in rings)
        {
            if (ring.isStill)
            {
                countStill++;
            }
        }

        reset = (countMoved >= numTries) && (countStill >= countMoved);
        if (reset) StartCoroutine(LazyCheckForReset(0.1f));
    }

    private IEnumerator LazyCheckForReset(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        CheckForReset();
    }

    public void CheckForReset(bool overRide = false)
    {
        if (reset || overRide)
        {
            countMoved = 0;
            rings = FindObjectsOfType<RingManager>();
            if (rings != null)
            {
                for (int i = 0; i < rings.Length; i++)
                {
                    rings[i].ResetRingData();
                }
            }
            SceneReset sceneReset = FindObjectOfType<SceneReset>();
            if (sceneReset != null)
                sceneReset.ResetAllTransforms();
            scoreKeeper.RoundReset();
        }
    }

    public void CheckThrowingLines(GameObject obj)
    {
        float objZ = player.transform.position.z;
        RingManager ringManager = obj.GetComponent<RingManager>();
        if (ringManager == null) return;
        if (throwingLines != null)
        {
            for (int i = 0; i < throwingLines.Length; i++)
            {
                if(throwingLines[i].position.z > objZ)
                {
                    ringManager.addPoints(pointsPerLine);
                }
            }
        }
    }

    public void Score(int points)
    {
        scoreKeeper.Score(points);
    }
}
