using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour {

    bool paused = false;

    [SerializeField]
    UnityEvent StartPause;

    [SerializeField]
    UnityEvent EndPause;

    public void SwitchPause()
    {
        if(!paused)
        {
            Time.timeScale = 0;
            StartPause.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            EndPause.Invoke();
        }
        paused = !paused;
    }
}
