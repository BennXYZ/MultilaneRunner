using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Range(0, 2)]
    [SerializeField]
    float dashRange;

    [Range(0, 5)]
    [SerializeField]
    float sneakTime;
    float sneakCounter;

    Vector2 velocity;

    GameObject playerPositioner;

    Rigidbody2D rigid;

    BoxCollider2D collisionBox;

    enum States { Default, Walking, Jumping, Falling, Dashing, Sliding}
    States previousState;
    States currentState;
    States nextState;

    int dashDirection;

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
        sneakCounter = sneakTime;
        previousState = States.Default;
        currentState = States.Walking;
        nextState = States.Walking;
        dashDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rigid.velocity.y < 0 && !grounded)
        //    falling = true;
        //if (!grounded || sneaking)
        //    CheckStates();
        currentState = nextState;

        switch(currentState)
        {
            case States.Walking:
                WalkUpdate();
                break;
            case States.Jumping:
                JumpUpdate();
                break;
            case States.Dashing:
                DashUpdate();
                break;
            case States.Sliding:
                SlideUpdate();
                break;
            case States.Falling:
                FallUpdate();
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log(currentState);

        previousState = currentState;
    }

    private void FixedUpdate()
    {

    }

    private void RevertSneaking()
    {
        sneaking = false;
        sneakCounter = sneakTime;
        float offset = collisionBox.size.y / 2;
        collisionBox.size = new Vector2(collisionBox.size.x, collisionBox.size.y * 2);
        collisionBox.offset = new Vector2(collisionBox.offset.x, collisionBox.offset.y + offset);
    }

    #region StateUpdates

    private void JumpUpdate()
    {
        if (previousState != currentState)
            rigid.AddForce(new Vector2(250 * forwardJump, Physics2D.gravity.y / Mathf.Abs(Physics2D.gravity.y) * -jumpForce *
                 (rigid.gravityScale / Mathf.Abs(rigid.gravityScale)) * 200));
        if (rigid.velocity.y < 0)
            nextState = States.Falling;
    }

    private void FallUpdate()
    {
        if (rigid.velocity.y == 0)
            nextState = States.Walking;
    }

    private void DashUpdate()
    {

    }

    private void WalkUpdate()
    {
        if (transform.position.x >= playerPositioner.transform.position.x + 0.05f)
        {
            rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y);
        }
        else if (transform.position.x <= playerPositioner.transform.position.x - 0.05f)
        {
            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
        }
        else if (transform.position.x != playerPositioner.transform.position.x)
        {
            transform.position = new Vector3(playerPositioner.transform.position.x, transform.position.y, transform.position.z);
            rigid.velocity = Vector2.zero;
        }
        if (rigid.velocity.y < 0)
            nextState = States.Falling;
    }

    private void SlideUpdate()
    {
        
    }

    #endregion

    public void Jump()
    {
        //if(grounded)
        //{
        //    rigid.AddForce(new Vector2(250 * forwardJump, Physics2D.gravity.y / Mathf.Abs(Physics2D.gravity.y) * -jumpForce *
        //        (rigid.gravityScale / Mathf.Abs(rigid.gravityScale)) * 200));
        //    grounded = false;
        //    if (sneaking)
        //        RevertSneaking();
        //}

        if (currentState == States.Walking || currentState == States.Dashing || currentState == States.Sliding)
            nextState = States.Jumping;
    }

    public void DashRight()
    {
        //if(!dashing && !sneaking)
        //{
        //    velocity += new Vector2(dashForce * dashRange, 0);
        //    dashing = true;
        //}

        if (currentState == States.Walking || currentState == States.Jumping || currentState == States.Falling)
        {
            nextState = States.Dashing;
            dashDirection = 1;
        }
    }

    public void DashLeft()
    {
        //if (!dashing && !sneaking)
        //{
        //    velocity += new Vector2(-dashForce * dashRange / 2, 0);
        //    dashing = true;
        //}

        if (currentState == States.Walking || currentState == States.Jumping || currentState == States.Falling)
        {
            nextState = States.Dashing;
            dashDirection = -1;
        }
    }

    public void Sneak()
    {
        //if(!sneaking && grounded)
        //{
        //    velocity += new Vector2(dashForce * dashRange * 0.75f, 0);
        //    dashing = true;
        //    sneaking = true;
        //    sneakCounter = 0;
        //    float offset = collisionBox.size.y / 4;
        //    collisionBox.size = new Vector2(collisionBox.size.x, collisionBox.size.y / 2);
        //    collisionBox.offset = new Vector2(collisionBox.offset.x, collisionBox.offset.y - offset);
        //}

        if (currentState == States.Walking || currentState == States.Dashing)
            nextState = States.Sliding;
    }

    public void GetHurt()
    {
        rigid.AddForce(new Vector2(-200, 0));
    }
}
