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
        settings.SetMusicMute();
        UpdateImage(settings);
    }

    private void UpdateImage(gameSettings settings)
    {
        if(state == States.Music)
        {
            if (settings.MusicMuted())
                renderer.sprite = muteSprite;
            else
                renderer.sprite = playSprite;
        }

        else if(state == States.Sound)
        {
            if (settings.SoundMuted())
                renderer.sprite = muteSprite;
            else
                renderer.sprite = playSprite;
        }
    }
}
