using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AniamtedUI : MonoBehaviour {

    [SerializeField]
    Sprite[] sprites;
    int currentSprite;

    [SerializeField]
    float timePerFrame;
    float counter;

    Image ui;

	// Use this for initialization
	void Start () {
        ui = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(UpdateTimer())
        {
            currentSprite++;
            if (currentSprite >= sprites.Length)
                currentSprite = 0;
            ui.sprite = sprites[currentSprite];
        }
	}

    bool UpdateTimer()
    {
        if(counter >= timePerFrame)
        {
            counter = 0;
            return true;
        }
        counter += Time.deltaTime;
        return false;
    }
}
