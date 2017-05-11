using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundObject : MonoBehaviour {

    AudioSource sound;

    [SerializeField]
    float volume;

    enum State { Music,Sound};

    [SerializeField]
    State state;

    // Use this for initialization
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();

        if(sound != null)
        {
            switch (state)
            {
                case State.Music:
                    if ((PlayerPrefs.GetInt("Music", 1) == 1))
                        sound.volume = volume;
                    else
                        sound.volume = 0;
                    break;

                case State.Sound:
                    if ((PlayerPrefs.GetInt("Sound", 1) == 1))
                        sound.volume = volume;
                    else
                        sound.volume = 0;
                    break;
            }
        }
    }

    public void UpdateSound()
    {
        if (sound != null)
            switch (state)
            {
                case State.Music:
                    if ((PlayerPrefs.GetInt("Music", 1) == 1))
                        sound.volume = volume;
                    else
                        sound.volume = 0;
                    break;

                case State.Sound:
                    if ((PlayerPrefs.GetInt("Sound", 1) == 1))
                        sound.volume = volume;
                    else
                        sound.volume = 0;
                    break;
            }
    }
}
