﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour {

    [SerializeField]
    scoreTrackerScript score;

    private int ShotStrength;
    private int HealthSize;
    private int CoinLvl;

    [SerializeField]
    private int[] healthPrices;

    [SerializeField]
    private int[] shotPrices;

    [SerializeField]
    private int[] coinPrices;

    // Use this for initialization
    void Start () {
        HealthSize = PlayerPrefs.GetInt("PlayerHealth", 1);
        ShotStrength = PlayerPrefs.GetInt("PlayerStrength", 0);
        CoinLvl = PlayerPrefs.GetInt("CoinLvl", 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            TryUpgradeShot();
        if (Input.GetKeyDown(KeyCode.H))
            TryUpgradeHealth();
        if (Input.GetKeyDown(KeyCode.C))
            TryUpgradeHealth();
        if (Input.GetKeyDown(KeyCode.R))
            ResetPlayerPrefs();
    }



    public void TryUpgradeHealth()
    {
        HealthSize = PlayerPrefs.GetInt("PlayerHealth", 1);
        if (HealthSize < healthPrices.Length)
        {
            if (score.TrySpendingCoins(healthPrices[HealthSize - 1]))
                UpgradeHealth();
        }
    }

    public void TryUpgradeShot()
    {
        ShotStrength = PlayerPrefs.GetInt("PlayerStrength", 0);
        if (ShotStrength < shotPrices.Length)
        {
            if (score.TrySpendingCoins(shotPrices[ShotStrength]))
                UpgradeStrength();
        }
    }

    public void TryUpgradeCoins()
    {
        CoinLvl = PlayerPrefs.GetInt("CoinLvl", 0);
        if(CoinLvl < coinPrices.Length)
        {
            if (score.TrySpendingCoins(coinPrices[CoinLvl]))
                UpgradeCoins();
        }
    }



    public string getHealthPrize()
    {
        if (HealthSize < healthPrices.Length)
            return healthPrices[HealthSize - 1].ToString();
        else
            return "---";
    }

    public string getShotPrize()
    {
        if (ShotStrength < shotPrices.Length)
            return shotPrices[ShotStrength].ToString();
        else
            return "---";
    }

    public string getCoinPrize()
    {
        if (CoinLvl < coinPrices.Length)
            return coinPrices[CoinLvl].ToString();
        else
            return "---";
    }



    public int getHealth()
    {
        return HealthSize;
    }

    public int getStrength()
    {
        return ShotStrength;
    }

    public int getCoins()
    {
        return CoinLvl;
    }



    public void UpgradeStrength()
    {
        ShotStrength += 1;
        PlayerPrefs.SetInt("PlayerStrength", ShotStrength);
    }

    public void UpgradeHealth()
    {
        HealthSize += 1;
        PlayerPrefs.SetInt("PlayerHealth", HealthSize);
    }

    public void UpgradeCoins()
    {
        CoinLvl += 1;
        PlayerPrefs.SetInt("CoinLvl", CoinLvl);
    }



    private void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        HealthSize = PlayerPrefs.GetInt("PlayerHealth", 1);
        ShotStrength = PlayerPrefs.GetInt("PlayerStrength", 0);
    }
}
