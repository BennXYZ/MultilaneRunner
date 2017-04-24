﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnContact : MonoBehaviour {

    [SerializeField]
    UnityEvent OnDestroy;

    [SerializeField]
    string destroyTag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == destroyTag)
        {
            OnDestroy.Invoke();
            GameObject.Destroy(gameObject);
        }
    }
}
