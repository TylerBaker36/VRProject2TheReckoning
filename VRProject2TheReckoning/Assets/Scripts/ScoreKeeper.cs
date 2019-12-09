using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private int rscore, oscore; // round and overall scores
    [SerializeField] private Text roundScore;
    [SerializeField] private Text overallScore;

    // Start is called before the first frame update
    void Start()
    {
        rscore = 0;
        oscore = 0;
        InitializeTextField(ref roundScore, "00");
        InitializeTextField(ref overallScore, "00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score(int val)
    {
        rscore+=val;
        oscore+=val;
        roundScore.text = string.Format("{0:00}", rscore.ToString().PadLeft(2, '0'));
        overallScore.text = string.Format("{0:00}", oscore.ToString().PadLeft(2, '0'));
    }

    public bool RoundReset()
    {
        rscore = 0;
        roundScore.text = "00";
        return (roundScore.text == "00");
    }

    public bool ScoreReset()
    {
        oscore = 0;
        overallScore.text = "00";
        return (overallScore.text == "00");
    }

    private void InitializeTextField(ref Text component, string textName)
    {
        if (component == null)
        {
            Text[] Texts = Resources.FindObjectsOfTypeAll<Text>();
            foreach (Text item in Texts)
            {
                if (item.name == textName)
                {
                    component = item;
                }
            }
        }
    }
}
