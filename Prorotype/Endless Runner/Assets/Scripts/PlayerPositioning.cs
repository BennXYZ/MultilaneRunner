using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositioning : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
    , -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));
    }

    void ChangeGravity()
    {
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
    , -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));
    }
}
