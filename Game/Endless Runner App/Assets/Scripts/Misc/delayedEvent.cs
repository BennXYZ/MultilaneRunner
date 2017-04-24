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
    bool[] performedEvents;
    int numberOfEvents;

	// Use this for initialization
	void Start () {
        counters = new float[times.Length];
        performedEvents = new bool[events.Length];
        numberOfEvents = 0;
		for(int i = 0; i < times.Length; i++)
        {
            counters[i] = 0;
            performedEvents[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(numberOfEvents < events.Length)
        {
            ChecktTimers();
            UpdateTimers();
        }
	}

    private void UpdateTimers()
    {
        for (int i = 0; i < events.Length; i++)
        {
            if (!performedEvents[i])
            {
                counters[i] += Time.deltaTime;
            }
        }
    }

    private void ChecktTimers()
    {
        for(int i = 0; i < events.Length; i++)
        {
            if(!performedEvents[i])
            {
                if(counters[i] >= times[i])
                {
                    events[i].Invoke();
                    performedEvents[i] = true;
                    numberOfEvents++;
                }
            }
        }
    }
}
