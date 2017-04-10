﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossSpawning : MonoBehaviour {

    bool duringBoss;
    
    [SerializeField]
    UnityEvent BossStarted;

    [SerializeField]
    UnityEvent BossEnded;

    [SerializeField]
    GameObject[] Bosses;

    [SerializeField]
    Vector2 Offset;

    float nextBossTime;
    bool bossSpawned;

    [SerializeField]
    float minBosslessTimeInSeconds;

    [SerializeField]
    float maxBosslessTimeInSeconds;
    float bossCounter;

    [SerializeField]
    float bossSpawnDelay;
    float delayCounter;

    // Use this for initialization
    void Start () {
        bossCounter = 0;
        nextBossTime = Random.value * maxBosslessTimeInSeconds;
        bossSpawned = false;
        duringBoss = false;
    }

	// Update is called once per frame
	void Update () {
		if(!duringBoss)
        {
            bossCounter += Time.deltaTime;
            if(bossCounter > nextBossTime)
            {
                StartBoss();
            }
        }
        else if (duringBoss && delayCounter < bossSpawnDelay)
        {
            delayCounter += Time.deltaTime;
            bossSpawned = true;
        }
        else if(bossSpawned && delayCounter >= bossSpawnDelay)
        {
            GameObject.Instantiate(Bosses[Random.Range(0, Bosses.Length) ], Offset, transform.rotation);
            BossStarted.Invoke();
            bossSpawned = false;
        }

    }

    public void StartBoss()
    {
        Debug.Log("BOSS TIME!");
        GameObject[] groundTiles = GameObject.FindGameObjectsWithTag("Block");
        duringBoss = true;
        delayCounter = 0;
        for (int i = 0; i < groundTiles.Length; i++)
        {
            groundTiles[i].GetComponent<GroundSpawning>().SetBoss(true);
        }
    }

    public void BossKilled()
    {
        GameObject[] groundTiles = GameObject.FindGameObjectsWithTag("Block");
        duringBoss = false;
        bossSpawned = false;
        for (int i = 0; i < groundTiles.Length; i++)
        {
            groundTiles[i].GetComponent<GroundSpawning>().SetBoss(false);
        }
        nextBossTime = Random.Range(minBosslessTimeInSeconds,maxBosslessTimeInSeconds);
        bossCounter = 0;
        BossEnded.Invoke();
    }

    public bool GetBossState()
    {
        return duringBoss;
    }
}
