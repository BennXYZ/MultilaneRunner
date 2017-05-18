using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeSizeOverTime : MonoBehaviour {

    [SerializeField]
    float scaling;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += transform.localScale * Time.deltaTime * scaling;
	}
}
