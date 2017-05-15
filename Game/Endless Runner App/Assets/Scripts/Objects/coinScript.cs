using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class coinScript : MonoBehaviour {

    [SerializeField]
    int coins;

    [SerializeField]
    int score;

    [SerializeField]
    int requiredCoinLVL;

    [SerializeField]
    UnityEvent collected;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("CoinLvl", 0) < requiredCoinLVL)
            GameObject.Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(GameObject.FindGameObjectWithTag("ScoreTracker") != null)
            GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<scoreTrackerScript>().CollectCoin(GameObject.Find("BoostManager").GetComponent<boostManager>().CheckForCoinBoost() * coins);
            if (GameObject.Find("ScoreManager") != null)
                GameObject.Find("ScoreManager").GetComponent<acutalScoreScript>().addPoints(score,0, GameObject.Find("BoostManager").GetComponent<boostManager>().CheckForCoinBoost() * coins);
            GameObject.FindGameObjectWithTag("MissionManager").GetComponent<MissionManager>().MissionProgress(1, GameObject.Find("BoostManager").GetComponent<boostManager>().CheckForCoinBoost() * coins);
            GameObject.FindGameObjectWithTag("MissionManager").GetComponent<MissionManager>().MissionProgress(2, GameObject.Find("BoostManager").GetComponent<boostManager>().CheckForCoinBoost() * coins);
            collected.Invoke();
            GameObject.Destroy(gameObject);
        }
    }


}
