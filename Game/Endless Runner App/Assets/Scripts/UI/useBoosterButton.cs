using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class useBoosterButton : MonoBehaviour {

    [SerializeField]
    UnityEvent used;

    [SerializeField]
    string PrefsName;

    [SerializeField]
    Text text;
    string initialText;

	// Use this for initialization
	void Start () {
        initialText = text.text;
        UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateText()
    {
        text.text = initialText + " " + PlayerPrefs.GetInt(PrefsName, 0) + "x";
    }

    public void TryUsingBoost()
    {
        if(PlayerPrefs.GetInt(PrefsName,0) > 0)
        {
            PlayerPrefs.SetInt(PrefsName, PlayerPrefs.GetInt(PrefsName, 0) - 1);
            used.Invoke();
        }
    }
}
