using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    ScoreTracker score;
    Text text;

	// Use this for initialization
	void Start () {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreTracker>();
        text = gameObject.GetComponent<Text>();
        text.text = score.Score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void UpdateText()
    {
        text.text = score.Score.ToString();
    }
}
