using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementManager : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    Vector3 direction;

    [SerializeField]
    float boostStrength;

    [SerializeField]
    float boostDuration;
    float boostDurationCounter;

    [SerializeField]
    bool manualSpeedBoost;

    [SerializeField]
    UnityEvent startBoost;

    [SerializeField]
    UnityEvent endBoost;

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public Vector3 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    // Use this for initialization
    void Start () {
        boostDurationCounter = -1;
	}

    public void CheckForBoost()
    {
        if(GameObject.Find("BoostManager").GetComponent<boostManager>().CheckForSpeedBoost() || manualSpeedBoost)
        {
            GameObject[] groundTiles = GameObject.FindGameObjectsWithTag("Block");
            for (int i = 0; i < groundTiles.Length; i++)
            {
                groundTiles[i].GetComponent<GroundSpawning>().SetFirstGround(true);
            }
            startBoost.Invoke();
            manualSpeedBoost = false;
            speed = boostStrength * speed;
            boostDurationCounter = 0;
        }
    }

    private void ResetSpeed()
    {
        speed = speed / boostStrength;
    }
	
	// Update is called once per frame
	void Update () {
        if (manualSpeedBoost)
            CheckForBoost();
        if (boostDurationCounter < boostDuration && boostDurationCounter >= 0)
            boostDurationCounter += Time.deltaTime;
        if(boostDurationCounter >= boostDuration)
        {
            GameObject[] groundTiles = GameObject.FindGameObjectsWithTag("Block");
            for (int i = 0; i < groundTiles.Length; i++)
            {
                groundTiles[i].GetComponent<GroundSpawning>().SetFirstGround(false);
            }
            endBoost.Invoke();
            ResetSpeed();
            boostDurationCounter = -1;
        }
	}
}
