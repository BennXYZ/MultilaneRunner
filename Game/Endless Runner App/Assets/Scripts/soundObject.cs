using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundObject : MonoBehaviour {

    AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();
	}
	
	public void UpdateSound(bool muted)
    {
        if (muted)
            sound.volume = 0;
        else
            sound.volume = 1;
    }
}
