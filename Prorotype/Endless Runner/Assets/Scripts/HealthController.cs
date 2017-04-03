using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {

    [SerializeField]
    int health;

    [SerializeField]
    int Maxhealth;

    [SerializeField]
    float invincibilityCooldown;

    [SerializeField]
    float iFramesCooldown;
    float invincibilityCounter;

    [SerializeField]
    UnityEvent UpdateHealth = new UnityEvent();

    bool invincibility;

    public int Health
    {
        get
        {
            return health;
        }
    }

    // Use this for initialization
    void Start () {
        invincibility = false;
        invincibilityCounter = iFramesCooldown;
	}
	
	// Update is called once per frame
	void Update () {
        if ((invincibilityCounter < invincibilityCooldown && invincibility) || (invincibilityCounter < iFramesCooldown && !invincibility))
            invincibilityCounter += Time.deltaTime;
        if (invincibilityCounter > invincibilityCooldown && invincibility)
            invincibility = false;
	}

    public void TakeDamage()
    {
        if (invincibilityCounter >= iFramesCooldown && !invincibility)
        {
            health--;
            if(health <= 0)
            {
                SceneManager.LoadScene("FortuneWheel");
            }
            invincibilityCounter = 0;
            UpdateHealth.Invoke();
        }
    }

    public void Heal()
    {
        if(Health <= Maxhealth)
        {
            health++;
            UpdateHealth.Invoke();
        }
    }

    public void ToggleInvincibility()
    {
        invincibility = true;
        invincibilityCounter = 0;
    }
}
