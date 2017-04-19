using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(GameObject.FindGameObjectWithTag("GameSettings") != null)
        {
            GameObject.FindGameObjectWithTag("GameSettings").GetComponent<gameSettings>().DoUpdate();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
