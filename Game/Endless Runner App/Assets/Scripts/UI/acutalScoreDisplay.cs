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
        text.text = "Score: " + script.Score().ToString();
	}
}
