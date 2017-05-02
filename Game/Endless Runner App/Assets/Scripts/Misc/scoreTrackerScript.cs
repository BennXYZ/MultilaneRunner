using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTrackerScript : MonoBehaviour {

    private int totalScore;
    private int currentScore;

    int doubleScore = 1;

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectsWithTag("ScoreTracker").Length > 1)
            GameObject.Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        totalScore = PlayerPrefs.GetInt("Score", 0);
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
        totalScore = PlayerPrefs.GetInt("Score", 0);
        return totalScore;
    }

    public void TransportScore()
    {
        totalScore = PlayerPrefs.GetInt("Score", 0);
        totalScore += currentScore;
        currentScore = 0;
        PlayerPrefs.SetInt("Score", totalScore);
    }

    public bool TrySpendingCoins(int amount)
    {
        totalScore = PlayerPrefs.GetInt("Score", 0);
        if (totalScore >= amount)
        {
            totalScore -= amount;
            PlayerPrefs.SetInt("Score", totalScore);
            return true;
        }
        return false;
    }

    public void CollectCoin(int amount)
    {
        currentScore += amount * doubleScore;
    }
}
