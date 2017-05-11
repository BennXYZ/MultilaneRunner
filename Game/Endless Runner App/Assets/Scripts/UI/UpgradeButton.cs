﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeButton: MonoBehaviour {

    UnityEvent buttonPressed;

    [SerializeField]
    Text text;
    int prize;

    UpgradeScript upgrader;

    enum Status { Health, Strength, Coins}

    [SerializeField]
    Status currentStatus;

	// Use this for initialization
	void Start () {
        upgrader = GameObject.FindGameObjectWithTag("UpgradeManager").GetComponent<UpgradeScript>();
        UpdateText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateText()
    {
        switch (currentStatus)
        {
            case Status.Health:

                text.text = upgrader.getHealthPrize().ToString() + "\nCoins";
                break;
            case Status.Strength:
                text.text = upgrader.getShotPrize().ToString() + "\nCoins";
                break;

            case Status.Coins:
                text.text = upgrader.getCoinPrize().ToString() + "\nCoins";
                break;
        }
    }

    public void TryUpgrade()
    {
        switch (currentStatus)
        {
            case Status.Health:
                upgrader.TryUpgradeHealth();
                UpdateText();
                break;
            case Status.Strength:
                upgrader.TryUpgradeShot();
                UpdateText();
                break;
            case Status.Coins:
                upgrader.TryUpgradeCoins();
                UpdateText();
                break;
        }

    }
}
