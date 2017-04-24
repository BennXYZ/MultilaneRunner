using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {
    
    [SerializeField]
    int score;

    [SerializeField]
    int coinLVL;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("CoinLvl", 0) < coinLVL)
            GameObject.Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag("ScoreTracker") != null)
        {
            GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<scoreTrackerScript>().CollectCoin(score);
            GameObject.Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player")
            GameObject.Destroy(gameObject);
    }


}
