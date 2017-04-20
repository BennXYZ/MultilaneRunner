using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeButton: MonoBehaviour {

    UnityEvent buttonPressed;

    enum Status { Health, Strength}

    [SerializeField]
    Status currentStatus;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TryUpgrade()
    {
        switch (currentStatus)
        {
            case Status.Health:
                GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradeScript>().TryUpgradeHealth();
                break;
            case Status.Strength:
                GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradeScript>().TryUpgradeShot();
                break;
        }

    }
}
