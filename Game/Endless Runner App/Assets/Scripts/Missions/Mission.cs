using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mission : MonoBehaviour {

    [SerializeField]
    bool resetsOnLevelEnd;

    public int index;

    bool getPrize = false;

    int progress;

    [SerializeField]
    int goal;

    [SerializeField]
    int prize;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void CheckProgress()
    {
        if(progress >= goal)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + prize);
            Destroy(gameObject);
        }
    }

    public void ResetProgress()
    {
        progress = 0;
    }
}
