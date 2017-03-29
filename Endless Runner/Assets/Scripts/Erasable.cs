using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erasable : MonoBehaviour {

    GameObject mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, mainCamera.transform.position) > 40)
            GameObject.Destroy(gameObject);
    }
    
}
