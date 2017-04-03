using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    GameObject mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position != mainCamera.transform.position)
        {
            transform.position = new Vector3(transform.position.x + (mainCamera.transform.position.x - transform.position.x) * 0.2f,
                transform.position.y + (mainCamera.transform.position.y - transform.position.y) * 0.02f
                , 0);
        }
	}
}
