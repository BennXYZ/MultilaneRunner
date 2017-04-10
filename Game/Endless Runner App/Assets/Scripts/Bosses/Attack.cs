using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    enum AttackTypes { Projectile, Laser, AOE, Vector}

    [SerializeField]
    AttackTypes AttackType;

    [SerializeField]
    GameObject Projectile;

    [SerializeField]
    bool rotateInDirection; // Up zeigt auf Player

    [SerializeField]
    GameObject[] SpawnPivots;

    [SerializeField]
    bool spawnAtPlayer;

    [SerializeField]
    Vector2 maxSpawndistance;

    [SerializeField]
    bool randomlySpawned;
    int n;

    [SerializeField]
    int numberOfAttacks;
    int attacksDone;

    [SerializeField]
    float bulletCooldown;
    float bulletCooldownCounter;

    [SerializeField]
    bool instantSpawning;

    [SerializeField]
    float instantSpawnDelay;
    float instantSpawnDelayTimer;

    bool attacking;

	// Use this for initialization
	void Start () {
        if (instantSpawning)
            instantSpawnDelayTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (instantSpawning)
        {
            InstantSpawn();
        }
        else if (attacking)
        {
            if (bulletCooldownCounter >= bulletCooldown)
            {
                if (spawnAtPlayer)
                {
                    GameObject.Instantiate(Projectile, GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(Random.value *
    maxSpawndistance.x * 2 - maxSpawndistance.x, Random.value * maxSpawndistance.y * 2 - maxSpawndistance.y, 0), transform.rotation);
                    bulletCooldownCounter = 0;
                    attacksDone++;
                }
                else if (SpawnPivots.Length == 0)
                {
                    GameObject projectile = GameObject.Instantiate(Projectile, transform.position, transform.rotation);

                    bulletCooldownCounter = 0;

                    attacksDone++;
                }
                else
                {
                    if (randomlySpawned)
                    {
                        GameObject projectile = GameObject.Instantiate(Projectile, SpawnPivots[Random.Range(0, (int)SpawnPivots.Length)].transform.position + new Vector3(Random.value * maxSpawndistance.x * 2 - maxSpawndistance.x, Random.value * maxSpawndistance.y * 2 - maxSpawndistance.y, 0), transform.rotation);

                        bulletCooldownCounter = 0;

                        attacksDone++;
                    }
                    else
                    {
                        GameObject projectile = GameObject.Instantiate(Projectile, SpawnPivots[n].transform.position + new Vector3(Random.value * maxSpawndistance.x * 2 - maxSpawndistance.x, Random.value * maxSpawndistance.y * 2 - maxSpawndistance.y, 0), transform.rotation);
                        if (n + 1 >= SpawnPivots.Length)
                            n = 0;
                        else
                            n++;
                        bulletCooldownCounter = 0;
                        attacksDone++;
                    }
                }
            }

            else
                bulletCooldownCounter += Time.deltaTime;
        }
        if(attacksDone >= numberOfAttacks)
        {
            attacksDone = 0;
            attacking = false;
        }
	}

    private void InstantSpawn()
    {
        if (instantSpawnDelayTimer >= instantSpawnDelay)
        {
            StartAttack();
            instantSpawning = false;
        }
        else
            instantSpawnDelayTimer += Time.deltaTime;
    }

    public void StartAttack()
    {
        attacking = true;
        bulletCooldownCounter = bulletCooldown;
        attacksDone = 0;
        n = 0;
    }
}
