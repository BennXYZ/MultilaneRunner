using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisions : MonoBehaviour {

    [SerializeField]
    UnityEvent GetHurt;

    [SerializeField]
    UnityEvent CollectPowerup;

    [SerializeField]
    UnityEvent CollectCoin;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Hazard":
                GetHurt.Invoke();
                break;
            case "Coin":
                CollectPowerup.Invoke();
                break;
            case "PowerUp":
                CollectCoin.Invoke();
                break;
        }
    }
}
