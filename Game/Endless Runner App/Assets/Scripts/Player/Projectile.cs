using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    float speed;

    int damage;

	// Use this for initialization
	void Start () {
        damage = PlayerPrefs.GetInt("PlayerStrength", 1);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
	}

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
