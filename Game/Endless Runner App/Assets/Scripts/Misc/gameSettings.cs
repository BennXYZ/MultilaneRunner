using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gameSettings : MonoBehaviour {

    private bool soundMuted = false;
    private bool musicMuted = false;

    UnityEvent SoundUpdated;

    public bool SoundMuted()
    {
        return soundMuted;
    }

    public bool MusicMuted()
    {
        return musicMuted;
    }

    // Use this for initialization
    void Start () {
        if (GameObject.FindGameObjectsWithTag("GameSettings").Length > 1)
            GameObject.Destroy(gameObject);
        GameObject.DontDestroyOnLoad(gameObject);
        SoundUpdated = new UnityEvent();
	}

    public void SetSoundMute()
    {
        soundMuted = !soundMuted;
        UpdateSound(false);
    }

    public void SetMusicMute()
    {
        musicMuted = !musicMuted;
        UpdateSound(true);
    }

    public void DoUpdate()
    {
        UpdateSound(true);
        UpdateSound(false);
    }

    private void UpdateSound(bool music)
    {

        if (!music)
        {
            soundObject sounds = GameObject.Find("SoundManager").GetComponent<soundObject>();
                sounds.UpdateSound(soundMuted);
        }

        else
        {
            soundObject musics = GameObject.Find("MusicManager").GetComponent<soundObject>();
                musics.UpdateSound(musicMuted);
        }

    }
}
