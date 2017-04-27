using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayHighscore : MonoBehaviour {

    enum ScoreTypes { Points, Coins, Bosses}

    [SerializeField]
    ScoreTypes scoreType;

    [SerializeField]
    Text text;

    [SerializeField]
    int highscore;

	// Use this for initialization
	void Start () {
        if(scoreType == ScoreTypes.Points)
            text.text = text.text + PlayerPrefs.GetInt("HighScorePoints" + highscore.ToString(), 0).ToString();
        else if (scoreType == ScoreTypes.Coins)
            text.text = text.text + PlayerPrefs.GetInt("HighScoreCoins" + highscore.ToString(), 0).ToString();
        else if (scoreType == ScoreTypes.Bosses)
            text.text = text.text + PlayerPrefs.GetInt("HighScoreBosses" + highscore.ToString(), 0).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
