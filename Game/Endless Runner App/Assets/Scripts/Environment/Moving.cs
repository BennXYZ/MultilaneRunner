using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    MovementManager manager;

    [SerializeField]
    float speedMultiplicator;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("GroundParent").GetComponent<MovementManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        transform.Translate(manager.Direction * manager.Speed * speedMultiplicator * Time.deltaTime);
    }
}
