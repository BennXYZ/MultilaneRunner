using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplayScript : MonoBehaviour {

    scoreTrackerScript tracker;
    [SerializeField]
    Text text;

    [SerializeField]
    bool totalScore;

    int score;
    

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("ScoreTracker") != null)
        {
            tracker = GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<scoreTrackerScript>();
            UpdateScore();
            text.text = score.ToString();
        }
    }

    private void UpdateScore()
    {
        if (tracker != null)
        {
            if (totalScore)
            {
                if (score != tracker.TotalScore())
                {
                    score = tracker.TotalScore();
                    text.text = score.ToString();
                }
            }
            else
            {
                if (score != tracker.CurrentScore())
                {
                    score = tracker.CurrentScore();
                    text.text = score.ToString();
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        UpdateScore();
	}
}
