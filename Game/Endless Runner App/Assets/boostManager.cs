using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class boostManager : MonoBehaviour {

    [SerializeField]
    int coinMultiplicator;
    bool coinBoost;

    bool SpeedBoost;

	// Use this for initialization
	void Start () {
        SpeedBoost = false;
        coinBoost = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CheckForSpeedBoost()
    {
        return SpeedBoost;
    }

    public int CheckForCoinBoost()
    {
        if (coinBoost)
            return coinMultiplicator;
        else
            return 1;
    }

    public void DoSpeedBoost()
    {
        SpeedBoost = true;
    }

    public void DoCoinBoost()
    {
        coinBoost = true;
    }
}
