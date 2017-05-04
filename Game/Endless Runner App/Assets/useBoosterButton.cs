using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class useBoosterButton : MonoBehaviour {

    [SerializeField]
    UnityEvent used;

    [SerializeField]
    string PrefsName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
