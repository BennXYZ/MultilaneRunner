﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenOrientation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
	}
	
}
