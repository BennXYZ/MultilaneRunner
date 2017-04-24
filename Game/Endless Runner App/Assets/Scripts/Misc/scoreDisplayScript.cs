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
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(tracker != null)
        if (score != tracker.TotalScore())
        {
            score = tracker.TotalScore();
            text.text = score.ToString();
        }
	}
}
