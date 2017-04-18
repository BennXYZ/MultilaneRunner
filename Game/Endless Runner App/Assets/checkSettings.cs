using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameSettings settings = GameObject.FindGameObjectWithTag("GameSettings").GetComponent<gameSettings>();
        if(settings != null)
        {
            settings.DoUpdate();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
