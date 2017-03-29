using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour {

    UnityEvent ScoreUp;

	// Use this for initialization
	void Start () {
        ScoreUp.AddListener(GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreTracker>().coinCollected);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreUp.Invoke();
            GameObject.Destroy(gameObject);
        }
    }
}
