using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour {

    [SerializeField]
    int startHealth;

    [SerializeField]
    int maxHealth;

    [SerializeField]
    UnityEvent Death;

    [SerializeField]
    UnityEvent Hurt;

    [SerializeField]
    UnityEvent Healed;

    int health;

	// Use this for initialization
	void Start () {
        health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Heal(int healing)
    {
        if (health + healing >= maxHealth)
            health = maxHealth;
        else
            health += healing;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death.Invoke();
        }
    }
}
