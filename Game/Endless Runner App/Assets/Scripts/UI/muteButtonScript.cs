using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteButtonScript : MonoBehaviour {

    [SerializeField]
    Image renderer;

    [SerializeField]
    Sprite playSprite;

    [SerializeField]
    Sprite muteSprite;

    enum States { Sound,Music};

    [SerializeField]
    States state;


	// Use this for initialization
	void Start () {
        gameSettings settings = GameObject.FindGameObjectWithTag("GameSettings").GetComponent<gameSettings>();
        UpdateImage(settings);
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void MuteSound()
    {
        gameSettings settings = GameObject.FindGameObjectWithTag("GameSettings").GetComponent<gameSettings>();
        settings.SetSoundMute();
        UpdateImage(settings);

    }

    public void Mutemusic()
    {
        gameSettings settings = GameObject.FindGameObjectWithTag("GameSettings").GetComponent<gameSettings>();
        //settings.SetMusicMute();

        if (state == States.Music)
        {
            if (PlayerPrefs.GetInt("Music", 1) == 0)
                PlayerPrefs.SetInt("Music", 1);
            else
                PlayerPrefs.SetInt("Music", 0);
        }

        else if (state == States.Sound)
        {
            if (PlayerPrefs.GetInt("Sound", 1) == 0)
                PlayerPrefs.SetInt("Sound", 1);
            else
                PlayerPrefs.SetInt("Sound", 0);
        }

        UpdateImage(settings);
    }

    private void UpdateImage(gameSettings settings)
    {
        if(state == States.Music)
        {
            if (PlayerPrefs.GetInt("Music",1) == 0)
                renderer.sprite = muteSprite;
            else
                renderer.sprite = playSprite;
        }

        else if(state == States.Sound)
        {
            if (PlayerPrefs.GetInt("Sound", 1) == 0)
                renderer.sprite = muteSprite;
            else
                renderer.sprite = playSprite;
        }
    }
}
