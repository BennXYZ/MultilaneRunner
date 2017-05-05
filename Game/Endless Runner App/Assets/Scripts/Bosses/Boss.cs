using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour {

    [SerializeField]
    HealthManager Health;

    [SerializeField]
    int scoreAdded;

    UnityEvent Death;

    // Use this for initialization
    void Start () {

        GameObject.Find("BossHealth").GetComponent<HealthDisplay>().CheckForBoss();

        Death = new UnityEvent();
        Death.AddListener(GameObject.FindGameObjectWithTag("BossSpawner").GetComponent<BossSpawning>().BossKilled);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void GetHurt()
    {
        GameObject.Find("BossHealth").GetComponent<HealthDisplay>().UpdateHealth();
    }

    public void AddPoints()
    {
        GameObject.Find("ScoreManager").GetComponent<acutalScoreScript>().addPoints(scoreAdded, 1, 0);
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
        if(GameObject.Find("BossHealth") != null)
        GameObject.Find("BossHealth").GetComponent<HealthDisplay>().CheckForBoss();
        Death.Invoke();
    }
}
