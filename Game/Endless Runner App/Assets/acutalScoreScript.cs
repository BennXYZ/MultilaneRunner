using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class acutalScoreScript : MonoBehaviour
{

    float score;
    bool outOfBoss;

    [SerializeField]
    float ScoreMultiplicator;

    [SerializeField]
    UnityEvent newHighscore;

    // Use this for initialization
    void Start()
    {
        outOfBoss = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!outOfBoss)
        {
            score += Time.deltaTime * ScoreMultiplicator;
        }
    }

    public int Score()
    {
        return (int)score;
    }

    public void setBossBool(bool bossState)
    {
        outOfBoss = bossState;
    }

    public void addPoints(int points)
    {
        score += points;
    }

    public void CheckHighscore()
    {
        if (PlayerPrefs.GetInt("HighScorePoints3", 0) < (int)score)
        {
            if (PlayerPrefs.GetInt("HighScorePoints2", 0) < (int)score)
            {
                if (PlayerPrefs.GetInt("HighScorePoints1", 0) < (int)score)
                {
                    newHighscore.Invoke();
                    PlayerPrefs.SetInt("HighScorePoints3", PlayerPrefs.GetInt("HighScorePoints2", 0));
                    PlayerPrefs.SetInt("HighScorePoints2", PlayerPrefs.GetInt("HighScorePoints1", 0));
                    PlayerPrefs.SetInt("HighScorePoints1", (int)score);
                }
                else
                {
                    newHighscore.Invoke();
                    PlayerPrefs.SetInt("HighScorePoints3", PlayerPrefs.GetInt("HighScorePoints2", 0));
                    PlayerPrefs.SetInt("HighScorePoints2", (int)score);
                }
            }
            else
            {
                newHighscore.Invoke();
                PlayerPrefs.SetInt("HighScorePoints3", (int)score);
            }
        }

        Debug.Log("Highscore1: " + PlayerPrefs.GetInt("HighScorePoints1", 0));
        Debug.Log("Highscore2: " + PlayerPrefs.GetInt("HighScorePoints2", 0));
        Debug.Log("Highscore3: " + PlayerPrefs.GetInt("HighScorePoints3", 0));
    }
}
