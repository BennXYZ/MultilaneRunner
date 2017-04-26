﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpritePicker : MonoBehaviour {

    [SerializeField]
    float spawnChance;

    [SerializeField]
    SpriteRenderer renderer;

    [SerializeField]
    Sprite[] sprites;

	// Use this for initialization
	void Start () {
        if (Random.Range(0.0f, 1.0f) < spawnChance || spawnChance == 1)
        {
            renderer.enabled = true;
            if (sprites.Length > 0)
                renderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
        else
            renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}