using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erasable : MonoBehaviour {

    [SerializeField]
    float despawnDistance;

    GameObject MainCamera;

	// Use this for initialization
	void Start () {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, MainCamera.transform.position) > despawnDistance)
            GameObject.Destroy(gameObject);

    }
}
