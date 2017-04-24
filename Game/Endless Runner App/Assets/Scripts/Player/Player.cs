using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [SerializeField]
    float jumpForce;

    [Range(0, 5)]
    [SerializeField]
    float moveSpeed;

    [Range(0, 1)]
    [SerializeField]
    float forwardJump;

    [Range(0,10)]
    [SerializeField]
    float dashForce;

    [Range(0, 5)]
    [SerializeField]
    float dashDuration;
    float dashCounter;

    [Range(0, 5)]
    [SerializeField]
    float slideDuration;
    float slideCounter;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Vector2 projectileOffset;

    Vector2 velocity;

    GameObject playerPositioner;

    Rigidbody2D rigid;

    BoxCollider2D collisionBox;

    enum States { Default, Walking, Jumping, Falling, Dashing, Sliding}
    States previousState;
    States currentState;
    States nextState;

    float dashDirection;

    private bool grounded;
    private float previousFallSpeed;
    private bool dashing;
    private bool sneaking;

    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        playerPositioner = GameObject.FindGameObjectWithTag("PlayerPosition");
        collisionBox = gameObject.GetComponent<BoxCollider2D>();
        velocity = Vector2.zero;
        slideCounter = slideDuration;
        dashCounter = dashDuration;
        previousState = States.Default;
        currentState = States.Walking;
        nextState = States.Walking;
        dashDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(Vector2.zero, Vector2.zero + (Vector2)(Quaternion.Euler(0, 0, (Random.value * 180) - (180 / 2)) * new Vector2(0,-1)).normalized);

        if (Time.timeScale != 0)
            currentState = nextState;
        else
            nextState = currentState;

        if (previousState == States.Sliding && nextState != States.Sliding)
            RevertSliding();

        switch(currentState)
        {
            case States.Walking:
                nextState = WalkUpdate();
                break;
            case States.Jumping:
                nextState = JumpUpdate();
                break;
            case States.Dashing:
                nextState = DashUpdate();
                break;
            case States.Sliding:
                nextState = SlideUpdate();
                break;
            case States.Falling:
                nextState = FallUpdate();
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log(currentState);

        previousState = currentState;
    }

    private void RevertSliding()
    {
        slideCounter = slideDuration;
        float offset = collisionBox.size.y / 2;
        collisionBox.size = new Vector2(collisionBox.size.x, collisionBox.size.y * 2);
        collisionBox.offset = new Vector2(collisionBox.offset.x, collisionBox.offset.y + offset);
    }

    #region StateUpdates

    private States JumpUpdate()
    {
        if (previousState != currentState)
            rigid.AddForce(new Vector2(250 * forwardJump, Physics2D.gravity.y / Mathf.Abs(Physics2D.gravity.y) * -jumpForce *
                 (rigid.gravityScale / Mathf.Abs(rigid.gravityScale)) * 200) * Time.timeScale);
        if (rigid.velocity.y < 0)
            return States.Falling;
        return currentState;
    }

    private States FallUpdate()
    {
        if (transform.position.x <= playerPositioner.transform.position.x)
        {
            rigid.velocity = rigid.velocity * 0.9f;
        }

        rigid.AddForce(new Vector2(-8, 0) * Time.timeScale);

        if (rigid.velocity.y == 0)
            return States.Walking;
        return currentState;
    }

    private States DashUpdate()
    {
        if (previousState != currentState)
            rigid.AddForce(new Vector2(dashForce * 100 * dashDirection, 0) * Time.timeScale);

        if (rigid.velocity.y != 0)
            return States.Falling;
        else
            return States.Walking;
    }

    private States WalkUpdate()
    {
        if (transform.position.x <= playerPositioner.transform.position.x)
        {
            rigid.velocity = rigid.velocity * 0.9f;
        }

        rigid.AddForce(new Vector2(-8 , 0) * Time.timeScale);

        if (rigid.velocity.y < 0)
            return States.Falling;
        return currentState;
    }

    private States SlideUpdate()
    {
        if (previousState != currentState)
        {
            rigid.velocity = rigid.velocity / 2;
            slideCounter = 0;
            float offset = collisionBox.size.y / 4;
            collisionBox.size = new Vector2(collisionBox.size.x, collisionBox.size.y / 2);
            collisionBox.offset = new Vector2(collisionBox.offset.x, collisionBox.offset.y - offset);
        }

        slideCounter += Time.deltaTime;

        if (slideCounter >= slideDuration)
        {
            if (rigid.velocity.y < 0)
                return States.Falling;
            else
                return States.Walking;
        }
        return currentState;
    }

    #endregion

    public void Jump()
    {
        if (currentState == States.Walking || currentState == States.Dashing || currentState == States.Sliding)
            nextState = States.Jumping;
    }

    public void DashRight()
    {
        if (currentState == States.Walking || currentState == States.Jumping || currentState == States.Falling)
        {
            nextState = States.Dashing;
            dashCounter = 0;
            dashDirection = 1;
        }
    }

    public void DashLeft()
    {
        if (currentState == States.Walking || currentState == States.Jumping || currentState == States.Falling)
        {
            nextState = States.Dashing;
            dashCounter = 0;
            dashDirection = -0.5f;
        }
    }

    public void Sneak()
    {
        if (currentState == States.Walking || currentState == States.Dashing)
            nextState = States.Sliding;
    }

    public void Shoot()
    {
        if(Time.timeScale != 0)
        GameObject.Instantiate(projectile, transform.position + new Vector3(projectileOffset.x, projectileOffset.y, 0), transform.rotation);
    }
}
