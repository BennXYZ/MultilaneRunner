﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour {

    [SerializeField]
    HealthManager Health;

    UnityEvent Death;

    // Use this for initialization
    void Start () {

        Death = new UnityEvent();
        Death.AddListener(GameObject.FindGameObjectWithTag("BossSpawner").GetComponent<BossSpawning>().BossKilled);

	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerProjectile")
        {
            Health.Damage(collision.gameObject.GetComponent<Projectile>().GetDamage());
        }
    }

    private void OnDestroy()
    {
        Death.Invoke();
    }
}
