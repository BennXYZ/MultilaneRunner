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
    float iFrames;
    float iFrameCounter;

    [SerializeField]
    bool showIFrames;

    [SerializeField]
    UnityEvent Death;

    [SerializeField]
    UnityEvent Hurt;

    [SerializeField]
    UnityEvent Healed;

    Rigidbody2D rigid;

    SpriteRenderer renderer;

    int health;

	// Use this for initialization
	void Start () {
        health = startHealth;
        iFrameCounter = iFrames;
        if (showIFrames)
            renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
            Debug.Log(health);
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
    }

    public void Damage(int damage)
    {
        if(iFrameCounter >= iFrames)
        {
            iFrameCounter = 0;
            health -= damage;
            rigid.AddForce(new Vector2(-300,0));
            if (health <= 0)
            {
                Death.Invoke();
                Debug.Log("Death");
            }
        }
    }

    private void ShowIFrames()
    {
        renderer.enabled = !renderer.enabled;
    }

    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
