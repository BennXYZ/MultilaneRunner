using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mission : MonoBehaviour {

    public string name;

    public string description;

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

    public int getGoal()
    {
        return goal;
    }

    public int getProgress()
    {
        return progress;
    }

    public void AddProgress(int value)
    {
        progress += value;
    }

    public bool CheckProgress()
    {
        if(progress >= goal)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + prize);
            return true;
        }
        return false;
    }

    public void ResetProgress()
    {
        progress = 0;
    }

    public void ResetOnLevelEnd()
    {
        if (resetsOnLevelEnd)
            progress = 0;
    }
}
