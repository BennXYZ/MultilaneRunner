using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class tutorialScript : MonoBehaviour {

    [SerializeField]
    UnityEvent[] events;

    int currentEvent;

    // Use this for initialization
    void Start () {
        currentEvent = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TryNextEvent(int action)
    {
        if(action == currentEvent && currentEvent < events.Length)
        {
            events[currentEvent].Invoke();
            currentEvent++;
        }
    }

}
