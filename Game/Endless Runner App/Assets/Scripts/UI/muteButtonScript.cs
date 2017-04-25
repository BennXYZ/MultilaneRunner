using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MuteSound()
    {
        GameObject.FindGameObjectWithTag("GameSettings").GetComponent<gameSettings>().SetSoundMute();
    }

    public void Mutemusic()
    {
        GameObject.FindGameObjectWithTag("GameSettings").GetComponent<gameSettings>().SetMusicMute();
    }
}
