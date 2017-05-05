using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class acutalScoreDisplay : MonoBehaviour {

    [SerializeField]
    Text text;

    [SerializeField]
    acutalScoreScript script;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (script.Score() > 5)
            text.text = script.Score().ToString();
        else
            text.text = "Score";
	}
}
