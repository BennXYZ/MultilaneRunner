using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayHighscore : MonoBehaviour {

    [SerializeField]
    Text text;

    [SerializeField]
    int highscore;

	// Use this for initialization
	void Start () {
        text.text = text.text + PlayerPrefs.GetInt("HighScorePoints" + highscore.ToString(), 0).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
