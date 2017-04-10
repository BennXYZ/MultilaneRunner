using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossAttacks : MonoBehaviour {

    [SerializeField]
    UnityEvent[] Attacks;

    [SerializeField]
    float initialDelay;
    float initialDelayTimer;
    float nextAttackTime;

    [SerializeField]
    float minAttackDelay;

    [SerializeField]
    float maxAttackDelay;
    float attackDelayTimer;

    bool startAttacking;

	// Use this for initialization
	void Start () {
        startAttacking = false;
        initialDelayTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(startAttacking)
        {
            if (attackDelayTimer >= nextAttackTime)
            {
                Attacks[Random.Range(0, Attacks.Length)].Invoke();
                attackDelayTimer = 0;
                nextAttackTime = Random.Range(minAttackDelay, maxAttackDelay);
            }
            else
                attackDelayTimer += Time.deltaTime;
        }
        else
        {
            if (initialDelayTimer >= initialDelay)
            {
                startAttacking = true;
                nextAttackTime = 0;
                attackDelayTimer = nextAttackTime;
            }
            else
                initialDelayTimer += Time.deltaTime;
        }
	}
}
