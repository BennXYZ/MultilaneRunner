﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTrackerScript : MonoBehaviour {

    private int totalScore;
    private int currentScore;

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectsWithTag("ScoreTracker").Length > 1)
            GameObject.Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnLevelWasLoaded(int level)
    {
        TransportScore();
    }

    public int CurrentScore()
    {
        return currentScore;
    }

    public int TotalScore()
    {
        return totalScore;
    }

    public void TransportScore()
    {
        totalScore += currentScore;
        currentScore = 0;
    }

    public bool TrySpendingCoins(int amount)
    {
        if(totalScore >= amount)
        {
            totalScore -= amount;
            return true;
        }
        return false;
    }

    public void CollectCoin(int amount)
    {
        currentScore += amount;
    }
}
