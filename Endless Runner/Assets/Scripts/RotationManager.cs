using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour {

    public float targetrotation;

	// Use this for initialization
	void Start () {
        targetrotation = 0;
	}
	
	// Update is called once per frame
	void Update () {

        Physics2D.gravity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * (transform.localRotation.eulerAngles.z - 90)), Mathf.Cos(Mathf.Deg2Rad * (transform.localRotation.eulerAngles.z + 180)));

    }

    public void RotateLeft()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        transform.localPosition = new Vector3(transform.localPosition.x + Mathf.Cos(Mathf.Deg2Rad * transform.localRotation.eulerAngles.z) * 8, transform.localPosition.y + Mathf.Cos(Mathf.Deg2Rad * (transform.localRotation.eulerAngles.z - 90)) * 8, transform.localPosition.z);
    }

    public void RotateRight()
    {

    }
}
