using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyBoosterButton : MonoBehaviour {

    [SerializeField]
    Text text;

    [SerializeField]
    int prize;

    [SerializeField]
    int maxAmount;

    enum States { CoinBoost, SpeedBoost}

    [SerializeField]
    States boostState;

	// Use this for initialization
	void Start () {
        text.text = prize + "\nCoins";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TryBuyBooster()
    {
        switch(boostState)
        {
            case States.CoinBoost:
                if(PlayerPrefs.GetInt("CoinBoosts",0) < maxAmount && PlayerPrefs.GetInt("Score",0) >= prize)
                {
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) - prize);
                    PlayerPrefs.SetInt("CoinBoosts", PlayerPrefs.GetInt("CoinBoosts", 0) + 1);
                    Debug.Log("Bought");
                }
                break;
            case States.SpeedBoost:
                if (PlayerPrefs.GetInt("SpeedBoosts", 0) < maxAmount && PlayerPrefs.GetInt("Score", 0) >= prize)
                {
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) - prize);
                    PlayerPrefs.SetInt("SpeedBoosts", PlayerPrefs.GetInt("SpeedBoosts", 0) + 1);
                    Debug.Log("Bought");
                }
                break;
        }
    }
}
