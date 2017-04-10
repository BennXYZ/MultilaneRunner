using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCorrection : MonoBehaviour {

    GameObject BossSpawner;

    // Use this for initialization
    void Start () {
        BossSpawner = GameObject.FindGameObjectWithTag("BossSpawner");
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > BossSpawner.transform.position.x)
            transform.Translate(new Vector3((BossSpawner.transform.position.x - transform.position.x) * Time.deltaTime, 0, 0));
    }
}
