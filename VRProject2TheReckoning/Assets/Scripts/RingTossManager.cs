using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossManager : MonoBehaviour
{
    /// <summary>
    /// The number of tries, opportunities, or throws before the round is reset.
    /// </summary>
    [SerializeField] private int numTries = 3;
    [SerializeField] private ScoreKeeper scoreKeeper;

    private static int countMoved;
    private static int countStill;
    private bool reset = false;

    private RingManager[] rings;

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
        }
    }

    public void Score(int points)
    {
        scoreKeeper.Score(points);
    }
}
