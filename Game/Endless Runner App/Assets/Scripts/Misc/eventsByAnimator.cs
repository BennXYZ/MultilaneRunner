using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventsByAnimator : MonoBehaviour {

    [SerializeField]
    UnityEvent[] events;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoEvent(int index)
    {
        events[index].Invoke();
    }
}
