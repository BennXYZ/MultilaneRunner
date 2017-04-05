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

    enum States { Walking, Jumping, Dashing, Sliding}
    States currentState;
    States nextState;

    private bool grounded;
    private bool falling;
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
        currentState = States.Walking;
        nextState = States.Walking;
        dashing = false;
        falling = false;
        grounded = false;
        sneaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.y < 0 && !grounded)
            falling = true;
        if (!grounded || sneaking)
            CheckStates();
    }

    private void FixedUpdate()
    {
        if (playerPositioner != null)
        {
            if (transform.position.x >= playerPositioner.transform.position.x + 0.05f)
            {
                transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
            }
            else if(transform.position.x <= playerPositioner.transform.position.x - 0.05f)
            {
                transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            }
            else if (transform.position.x != playerPositioner.transform.position.x && playerPositioner != null)
            {
                transform.position = new Vector3(playerPositioner.transform.position.x, transform.position.y, transform.position.z);
                velocity = Vector2.zero;
            }
            transform.Translate(velocity.x, velocity.y, 0);
            velocity = velocity * (1 - dashForce * 0.1f);
            if(velocity.x <= 0.1f)
                dashing = false;
        }
    }

    private void CheckStates()
    {

        if (!falling && rigid.velocity.y < 0)
        {
            falling = true;
            grounded = false;
            if(sneaking)
                RevertSneaking();
        }
        else if(falling && !grounded && rigid.velocity.y == 0)
        {
            falling = false;
            grounded = true;
        }
        if (sneaking)
            Debug.Log(sneakCounter);
        if (sneakCounter < sneakTime)
            sneakCounter += Time.deltaTime;
        else if (sneakCounter >= sneakTime && sneaking)
        {
            RevertSneaking();
        }
    }

    private void RevertSneaking()
    {
        sneaking = false;
        sneakCounter = sneakTime;
        float offset = collisionBox.size.y / 2;
        collisionBox.size = new Vector2(collisionBox.size.x, collisionBox.size.y * 2);
        collisionBox.offset = new Vector2(collisionBox.offset.x, collisionBox.offset.y + offset);
    }

    public void Jump()
    {
        if(grounded)
        {
            rigid.AddForce(new Vector2(250 * forwardJump, Physics2D.gravity.y / Mathf.Abs(Physics2D.gravity.y) * -jumpForce *
                (rigid.gravityScale / Mathf.Abs(rigid.gravityScale)) * 200));
            grounded = false;
            if (sneaking)
                RevertSneaking();
        }
    }

    public void DashRight()
    {
        if(!dashing && !sneaking)
        {
            velocity += new Vector2(dashForce * dashRange, 0);
            dashing = true;
        }
    }

    public void DashLeft()
    {
        if (!dashing && !sneaking)
        {
            velocity += new Vector2(-dashForce * dashRange / 2, 0);
            dashing = true;
        }
    }

    public void Sneak()
    {
        if(!sneaking && grounded)
        {
            velocity += new Vector2(dashForce * dashRange * 0.75f, 0);
            dashing = true;
            sneaking = true;
            sneakCounter = 0;
            float offset = collisionBox.size.y / 4;
            collisionBox.size = new Vector2(collisionBox.size.x, collisionBox.size.y / 2);
            collisionBox.offset = new Vector2(collisionBox.offset.x, collisionBox.offset.y - offset);
        }
    }
}
