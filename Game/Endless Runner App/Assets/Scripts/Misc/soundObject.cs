using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundObject : MonoBehaviour {

    [SerializeField]
    AudioSource[] sound;

	// Use this for initialization
	void Start () {
	}
	
	public void UpdateSound(bool muted)
    {
        for(int i = 0; i < sound.Length; i++)
        {
            if (muted)
                sound[i].volume = 0;
            else
                sound[i].volume = 1;
        }

    }
}
