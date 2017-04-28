using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class acutalScoreScript : MonoBehaviour
{

    float score;

    int bosses;

    int coins;

    bool outOfBoss;

    [SerializeField]
    float ScoreMultiplicator;

    [SerializeField]
    float BossMultiplicator;

    [SerializeField]
    UnityEvent newHighscore;

    [SerializeField]
    MovementManager movement;

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
            score += Time.deltaTime * movement.Speed * ScoreMultiplicator * Mathf.Pow(BossMultiplicator, bosses);
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

    public void addPoints(int points, int bosses, int coins)
    {
        score += points;
        this.bosses += bosses;
        this.coins += coins;
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
                    PlayerPrefs.SetInt("HighScoreBosses3", PlayerPrefs.GetInt("HighScoreBosses2", 0));
                    PlayerPrefs.SetInt("HighScoreCoins3", PlayerPrefs.GetInt("HighScoreCoins2", 0));
                    PlayerPrefs.SetInt("HighScorePoints2", PlayerPrefs.GetInt("HighScorePoints1", 0));
                    PlayerPrefs.SetInt("HighScoreBosses2", PlayerPrefs.GetInt("HighScoreBosses1", 0));
                    PlayerPrefs.SetInt("HighScoreCoins2", PlayerPrefs.GetInt("HighScoreCoins1", 0));
                    PlayerPrefs.SetInt("HighScorePoints1", (int)score);
                    PlayerPrefs.SetInt("HighScoreBosses1", bosses);
                    PlayerPrefs.SetInt("HighScoreCoins1", coins);
                }
                else
                {
                    newHighscore.Invoke();
                    PlayerPrefs.SetInt("HighScorePoints3", PlayerPrefs.GetInt("HighScorePoints2", 0));
                    PlayerPrefs.SetInt("HighScoreBosses3", PlayerPrefs.GetInt("HighScoreBosses2", 0));
                    PlayerPrefs.SetInt("HighScoreCoins3", PlayerPrefs.GetInt("HighScoreCoins2", 0));
                    PlayerPrefs.SetInt("HighScorePoints2", (int)score);
                    PlayerPrefs.SetInt("HighScoreBosses2", bosses);
                    PlayerPrefs.SetInt("HighScoreCoins2", coins);
                }
            }
            else
            {
                newHighscore.Invoke();
                PlayerPrefs.SetInt("HighScorePoints3", (int)score);
                PlayerPrefs.SetInt("HighScoreBosses3", bosses);
                PlayerPrefs.SetInt("HighScoreCoins3", coins);
            }
        }
    }
}
