using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class tutorialScene : MonoBehaviour {

    [SerializeField]
    UnityEvent Tutorial;

    [SerializeField]
    UnityEvent Menu;

        public void tryNextAction()
    {
        if (PlayerPrefs.GetInt("Tutorial", 0) == 0)
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            Tutorial.Invoke();
        }
        else
            Menu.Invoke();
    }
}
