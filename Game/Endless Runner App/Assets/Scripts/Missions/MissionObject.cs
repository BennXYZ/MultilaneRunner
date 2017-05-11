using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionObject : MonoBehaviour {

    [SerializeField]
    int missionIndex;

    [SerializeField]
    int defaultValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger(int value)
    {
        if (value == 0)
            value = defaultValue;
        GameObject.FindGameObjectWithTag("MissionManager").GetComponent<MissionManager>().MissionProgress(missionIndex, value);
    }
}
