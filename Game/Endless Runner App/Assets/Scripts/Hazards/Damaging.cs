using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damaging : MonoBehaviour {

    [SerializeField]
    int damage;

    UnityEvent hit;

	// Use this for initialization
	void Start () {
        hit.AddListener(delegate { GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>().Damage(1); });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hit.Invoke();
        }
    }
}
