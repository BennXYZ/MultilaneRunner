using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour {

    [SerializeField]
    scoreTrackerScript score;

    [SerializeField]
    int maxHealth;

    [SerializeField]
    int maxStrength;

    private int ShotStrength;
    private int HealthSize;

    [SerializeField]
    private int[] healthPrices;

    [SerializeField]
    private int[] shotPrices;

    // Use this for initialization
    void Start () {
        HealthSize = PlayerPrefs.GetInt("PlayerHealth", 1);
        ShotStrength = PlayerPrefs.GetInt("PlayerStrength", 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            TryUpgradeShot();
        if (Input.GetKeyDown(KeyCode.H))
            TryUpgradeHealth();
        if (Input.GetKeyDown(KeyCode.R))
            ResetPlayerPrefs();
    }

    public void TryUpgradeHealth()
    {
        HealthSize = PlayerPrefs.GetInt("PlayerHealth", 1);
        if (HealthSize < maxHealth)
        {
            if (score.TrySpendingCoins(healthPrices[HealthSize - 1]))
                UpgradeHealth();
        }
    }

    public string getHealthPrize()
    {
        if (HealthSize < maxHealth)
            return healthPrices[HealthSize - 1].ToString();
        else
            return "---";
    }

    public string getShotPrize()
    {
        if (ShotStrength < maxStrength)
            return shotPrices[ShotStrength - 1].ToString();
        else
            return "---";
    }

    public void TryUpgradeShot()
    {
        ShotStrength = PlayerPrefs.GetInt("PlayerStrength", 1);
        if (ShotStrength < maxStrength)
        {
            if (score.TrySpendingCoins(shotPrices[ShotStrength - 1]))
                UpgradeStrength();
        }
    }

    public int getHealth()
    {
        return HealthSize;
    }

    public int getStrength()
    {
        return ShotStrength;
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

    private void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        HealthSize = PlayerPrefs.GetInt("PlayerHealth", 1);
        ShotStrength = PlayerPrefs.GetInt("PlayerStrength", 1);
    }
}
