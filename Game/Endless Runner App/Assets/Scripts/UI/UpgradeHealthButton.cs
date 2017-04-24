using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeHealthButton : MonoBehaviour {

    UnityEvent buttonPressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TryUpgrade()
    {
        GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradeScript>().TryUpgradeHealth();
    }
}
