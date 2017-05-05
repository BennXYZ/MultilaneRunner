using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    Animator animator;

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


    [Range(0, 1)]
    [SerializeField]
    float slideAmount;

    [SerializeField]
    GameObject[] projectiles;

    [SerializeField]
    float shootCooldown;
    float shootCooldownCounter;

    [SerializeField]
    Vector2 projectileOffset;

    [SerializeField]
    UnityEvent StartJumping;

    [SerializeField]
    UnityEvent StartDashing;

    [SerializeField]
    UnityEvent StartBackDashing;

    [SerializeField]
    UnityEvent StartSliding;

    [SerializeField]
    UnityEvent StartWalking;

    [SerializeField]
    UnityEvent ShootEvent;

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
        shootCooldownCounter = shootCooldown;
        dashCounter = dashDuration;
        previousState = States.Default;
        currentState = States.Walking;
        nextState = States.Walking;
        dashDirection = 0;
    }

    private void CompareStates()
    {
        if (previousState == States.Sliding && nextState != States.Sliding)
            RevertSliding();

        if (currentState == States.Sliding && previousState != States.Sliding)
            Shrink();

        //if (currentState == States.Dashing && previousState != States.Dashing)
        //    StartDashing.Invoke();
        if (currentState == States.Jumping && previousState != States.Jumping)
            StartJumping.Invoke();
        if (currentState == States.Sliding && previousState != States.Sliding)
            StartSliding.Invoke();
        if (currentState == States.Walking && previousState != States.Walking)
            StartWalking.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
            currentState = nextState;
        else
            nextState = currentState;

        CompareStates();

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

        UpdateCooldowns();

        previousState = currentState;
    }

    private void UpdateCooldowns()
    {
        if (dashCounter < dashDuration)
            dashCounter += Time.deltaTime;

        if (shootCooldownCounter < shootCooldown)
            shootCooldownCounter += Time.deltaTime;
    }

    private void Shrink()
    {
        float offset = collisionBox.size.y;
        collisionBox.size = new Vector2(collisionBox.size.x, collisionBox.size.y / (1 / slideAmount));
        offset = (offset - collisionBox.size.y) / 2;
        collisionBox.offset = new Vector2(collisionBox.offset.x, collisionBox.offset.y - offset);
    }

    private void RevertSliding()
    {
        slideCounter = slideDuration;
        float offset = collisionBox.size.y;
        collisionBox.size = new Vector2(collisionBox.size.x, collisionBox.size.y * (1 / slideAmount));
        offset = (collisionBox.size.y - offset) / 2;
        collisionBox.offset = new Vector2(collisionBox.offset.x, collisionBox.offset.y + offset);
    }

    #region StateUpdates

    private States JumpUpdate()
    {
        if (previousState != currentState)
        {
            rigid.AddForce(new Vector2(250 * forwardJump, Physics2D.gravity.y / Mathf.Abs(Physics2D.gravity.y) * -jumpForce *
     (rigid.gravityScale / Mathf.Abs(rigid.gravityScale)) * 200) * Time.timeScale);
        }

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
        {
            StartWalking.Invoke();
            return States.Walking;
        }
        return currentState;
    }

    private States DashUpdate()
    {
        if (previousState != currentState)
        {
            rigid.AddForce(new Vector2(dashForce * 100 * dashDirection, 0) * Time.timeScale);
        }

        if (dashCounter >= dashDuration)
        {
            if (rigid.velocity.y != 0)
                return States.Falling;
            else
                return States.Walking;
        }
        else
            return currentState;
    }

    private States WalkUpdate()
    {
        if (animator.GetBool("InAir"))
            animator.SetBool("InAir", false);

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
        {
            nextState = States.Jumping;
            animator.SetTrigger("Jump");
            animator.SetBool("InAir", true);
        }
    }

    public void DashRight()
    {
        if ((currentState == States.Walking || currentState == States.Jumping || currentState == States.Falling || currentState == States.Sliding) && dashCounter >= dashDuration)
        {
            StartDashing.Invoke();
            animator.SetTrigger("Dash");
            nextState = States.Dashing;
            dashCounter = 0;
            dashDirection = 1;
        }
    }

    public void DashLeft()
    {
        if ((currentState == States.Walking || currentState == States.Jumping || currentState == States.Falling || currentState == States.Sliding) && dashCounter >= dashDuration)
        {
            StartBackDashing.Invoke();
            animator.SetTrigger("DashB");
            nextState = States.Dashing;
            dashCounter = 0;
            dashDirection = -0.5f;
        }
    }

    public void Sneak()
    {
        if (currentState == States.Walking || currentState == States.Dashing)
        {
            rigid.velocity = rigid.velocity / 2;
            slideCounter = 0;
            StartSliding.Invoke();
            animator.SetTrigger("Slide");
            nextState = States.Sliding;
        }
    }

    public void Shoot()
    {
        if (Time.timeScale != 0 && shootCooldownCounter >= shootCooldown)
            if (currentState != States.Dashing && currentState != States.Sliding)
            {
                GameObject.Instantiate(projectiles[PlayerPrefs.GetInt("PlayerStrength", 0)], transform.position + new Vector3(projectileOffset.x, projectileOffset.y, 0), transform.rotation);
                ShootEvent.Invoke();
                shootCooldownCounter = 0;
            }
    }
}
