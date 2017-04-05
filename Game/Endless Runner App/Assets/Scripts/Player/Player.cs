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

    Vector2 velocity;

    GameObject playerPositioner;

    Rigidbody2D rigid;

    private bool grounded;
    private bool falling;
    private bool dashing;

    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        playerPositioner = GameObject.FindGameObjectWithTag("PlayerPosition");
        velocity = Vector2.zero;
        dashing = false;
        falling = false;
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.y < 0 && !grounded)
            falling = true;
        if (!grounded)
            CeckJumpState();
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

    private void CeckJumpState()
    {
        if (!falling && rigid.velocity.y < 0)
            falling = true;
        else if(falling && rigid.velocity.y == 0)
        {
            falling = false;
            grounded = true;
        }
    }

    public void Jump()
    {
        if(grounded)
        {
            rigid.AddForce(new Vector2(250 * forwardJump, Physics2D.gravity.y / Mathf.Abs(Physics2D.gravity.y) * -jumpForce *
                (rigid.gravityScale / Mathf.Abs(rigid.gravityScale)) * 200));
            grounded = false;
        }
    }

    public void DashRight()
    {
        if(!dashing)
        {
            velocity += new Vector2(dashForce * dashRange, 0);
            dashing = true;
        }
    }

    public void DashLeft()
    {
        if (!dashing)
        {
            velocity += new Vector2(-dashForce * dashRange / 2, 0);
            dashing = true;
        }
    }
}
