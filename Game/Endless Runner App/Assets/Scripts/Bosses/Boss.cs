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

    bool PlayerIsChamp;

    // Use this for initialization
    void Start () {

        GameObject.Find("BossHealth").GetComponent<HealthDisplay>().CheckForBoss();
        PlayerIsChamp = true;

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

    public void PlayerIsNoob()
    {
        Debug.Log("ROFL");
        PlayerIsChamp = false;
    }

    public void OnDeath()
    {
        MissionManager missions = GameObject.FindGameObjectWithTag("MissionManager").GetComponent<MissionManager>();
        missions.MissionProgress(3,1);
        missions.MissionProgress(4, 1);
        if (PlayerIsChamp)
        {
            Debug.Log("LOL");
            missions.MissionProgress(5, 1);
        }
    }

    private void OnDestroy()
    {
        if(GameObject.Find("BossHealth") != null)
        GameObject.Find("BossHealth").GetComponent<HealthDisplay>().CheckForBoss();
        Death.Invoke();
    }
}
