using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{

    enum AttackTypes { Projectile, Laser, AOE, Vector }

    [SerializeField]
    AttackTypes ProjectileType;

    [SerializeField]
    Vector2 shootDirection;
    Vector2 velocity;

    [Range(0,360)]
    [SerializeField]
    float sprayAngle;

    [SerializeField]
    bool aimingAtPlayer;

    [SerializeField]
    bool rotateInDirection;

    [SerializeField]
    float speedUpPerSecond;

    [SerializeField]
    float speed;

    [SerializeField]
    float hitDelay;
    float hitDelayCounter;

    [SerializeField]
    float endDelay;
    float endDelayCounter;

    [SerializeField]
    float destroyDelay;
    float destroyDelayCounter;

    Collider2D hitBox;

    // Use this for initialization
    void Start()
    {
        hitBox = gameObject.GetComponent<Collider2D>();
        if (shootDirection != Vector2.zero && !aimingAtPlayer)
            velocity = (Quaternion.Euler(0, 0, (Random.value * sprayAngle) - (sprayAngle / 2)) * shootDirection).normalized * speed;
        else if (!aimingAtPlayer)
            velocity = Vector2.zero;
        else if (aimingAtPlayer)
            velocity = (Quaternion.Euler(0, 0, (Random.value * sprayAngle) - (sprayAngle / 2)) * (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position)).normalized * speed;
        if (rotateInDirection)
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), velocity);
        hitDelayCounter = 0;
        destroyDelayCounter = 0;
    }

    public Vector2 GetVelocity()
    {
        return velocity;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3((velocity * Time.deltaTime).x, (velocity * Time.deltaTime).y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, (Vector2)transform.position + velocity);

        if (speedUpPerSecond != 0)
            velocity += velocity * speedUpPerSecond * Time.deltaTime;

        if (hitDelayCounter >= hitDelay)
        {
            hitBox.enabled = true;
        }
        else
            hitDelayCounter += Time.deltaTime;

        if (endDelayCounter >= endDelay)
        {
            hitBox.enabled = false;
        }
        else
            endDelayCounter += Time.deltaTime;

        if (destroyDelayCounter >= destroyDelay)
        {
            GameObject.Destroy(gameObject);
        }
        else
            destroyDelayCounter += Time.deltaTime;
    }
}
