using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private int rscore, oscore; // round and overall scores
    [SerializeField] private TMP_Text roundScore;
    [SerializeField] private TMP_Text overallScore;

    // Start is called before the first frame update
    void Start()
    {
        rscore = 0;
        oscore = 0;
        roundScore.SetText("00");
        overallScore.SetText("00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getRoundScore() { return rscore; }
    public int getOverallScore() { return oscore; }

    public void Score(int val)
    {
        rscore+=val;
        oscore+=val;
        roundScore.text = string.Format("{0:00}", rscore.ToString().PadLeft(2, '0'));
        overallScore.text = string.Format("{0:00}", oscore.ToString().PadLeft(2, '0'));
    }

    public void RoundReset()
    {
        rscore = 0;
        roundScore.text = "00";
        //return (roundScore.text == "00");
    }

    public void ScoreReset()
    {
        oscore = 0;
        overallScore.text = "00";
        //return (overallScore.text == "00");
    }
}
