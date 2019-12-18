using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour
{
    private int scoreValue = 0;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + scoreValue;
    }

    public void AddScore(int value)
    {
        scoreValue += value;
    }
}
