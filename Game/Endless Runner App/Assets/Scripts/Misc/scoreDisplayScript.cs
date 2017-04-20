using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplayScript : MonoBehaviour {

    scoreTrackerScript tracker;
    [SerializeField]
    Text text;

    int score;
    

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("ScoreTracker") != null)
        {
            tracker = GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<scoreTrackerScript>();
            score = 0;
            text.text = "Coins: "  + score.ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(tracker != null)
        if (score != tracker.CurrentScore())
        {
            score = tracker.CurrentScore();
            text.text = "Coins: " + score.ToString();
        }
	}
}
