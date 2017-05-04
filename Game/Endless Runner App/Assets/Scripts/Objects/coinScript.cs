using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {

    [SerializeField]
    int coins;

    [SerializeField]
    int score;

    [SerializeField]
    int requiredCoinLVL;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("CoinLvl", 0) < requiredCoinLVL)
            GameObject.Destroy(gameObject);
        else
            coins = GameObject.Find("BoostManager").GetComponent<boostManager>().CheckForCoinBoost() * coins;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(GameObject.FindGameObjectWithTag("ScoreTracker") != null)
            GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<scoreTrackerScript>().CollectCoin(coins);
            if (GameObject.Find("ScoreManager") != null)
                GameObject.Find("ScoreManager").GetComponent<acutalScoreScript>().addPoints(score,0,coins);
            GameObject.Destroy(gameObject);
        }
    }


}
