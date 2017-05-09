using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betterFalling : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rigid;

    [SerializeField]
    float fallMultiplicator = 2.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rigid.velocity.y < 0)
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplicator - 1) * Time.deltaTime;
	}
}
