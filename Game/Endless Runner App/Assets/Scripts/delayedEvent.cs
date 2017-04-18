using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class delayedEvent : MonoBehaviour {

    [SerializeField]
    float[] times;
    float[] counters;

    [SerializeField]
    UnityEvent[] events;

	// Use this for initialization
	void Start () {
        counters = new float[times.Length];
		for(int i = 0; i < times.Length; i++)
        {
            counters[i] = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void UpdateTimers()
    {

    }

    private void ChecktTimers()
    {

    }
}
