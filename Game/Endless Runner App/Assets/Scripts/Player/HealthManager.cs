using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour {


    int maxHealth;

    [SerializeField]
    int startHealth;

    [SerializeField]
    float iFrames;
    float iFrameCounter;

    [SerializeField]
    bool showIFrames;

    [SerializeField]
    UnityEvent Beginning;

    [SerializeField]
    UnityEvent Death;

    [SerializeField]
    UnityEvent Hurt;

    [SerializeField]
    UnityEvent Healed;

    [SerializeField]
    GameObject DestroyObject;

    SpriteRenderer renderer;

    int health;

	// Use this for initialization
	void Start () {
        if(startHealth == 0)
        {
            maxHealth = PlayerPrefs.GetInt("PlayerHealth", 1);
            health = maxHealth;
        }
        else
        {
            maxHealth = startHealth;
            health = maxHealth;
        }
        Beginning.Invoke();
        iFrameCounter = iFrames;
        if (showIFrames)
            renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (iFrameCounter < iFrames)
        {
            if (showIFrames)
                ShowIFrames();
            iFrameCounter += Time.deltaTime;
        }
        else if (showIFrames)
            if (!renderer.enabled)
                renderer.enabled = true;
    }

    public void Heal(int healing)
    {
        if (health + healing >= maxHealth)
            health = maxHealth;
        else
            health += healing;
        Healed.Invoke();
    }

    public void Damage(int damage)
    {
        if(iFrameCounter >= iFrames)
        {
            iFrameCounter = 0;
            health -= damage;
            Hurt.Invoke();
            if (health <= 0)
            {
                Death.Invoke();
                Debug.Log("Death");
            }
        }
    }

    public int Health()
    {
        return health;
    }

    private void ShowIFrames()
    {
        renderer.enabled = !renderer.enabled;
    }

    public void Destroy()
    {
        if (DestroyObject == null)
            GameObject.Destroy(gameObject);
        else
            GameObject.Destroy(DestroyObject);
    }
}
