using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {

    private int score;
    private int multiplier;

	// Use this for initialization
	void Start () {
        multiplier = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMultiplier(int multiplier)
    {
        this.multiplier = multiplier;
    }

    public void coinCollected()
    {
        score += multiplier;
        GameObject.Find("ScoreDisplay").GetComponent<ScoreDisplay>().UpdateText();
    }

    public int Score
    {
        get
        {
            return score;
        }
    }
}
