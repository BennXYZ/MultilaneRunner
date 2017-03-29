using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject players;

	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectWithTag("Players");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + (players.transform.position.x - transform.position.x) * Time.deltaTime * 2, transform.position.y +( players.transform.position.y - transform.position.y) * Time.deltaTime * 2, -10);
	}
}
