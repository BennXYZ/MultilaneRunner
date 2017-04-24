using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Healing : MonoBehaviour {

    [SerializeField]
    int strength;

    UnityEvent heal;

    // Use this for initialization
    void Start () {
        heal = new UnityEvent();
        heal.AddListener(delegate { GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>().Heal(strength); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            heal.Invoke();
        }
    }
}
