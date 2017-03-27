using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erasable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Eraser")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
