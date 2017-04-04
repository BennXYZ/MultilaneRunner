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

    [Range(0,10)]
    [SerializeField]
    float dashForce;

    Vector2 velocity;

    GameObject playerPositioner;

    Rigidbody2D rigid;

    private bool grounded;
    private bool falling;

    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        playerPositioner = GameObject.FindGameObjectWithTag("PlayerPosition");
        velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.y < 0 && !grounded)
            falling = true;
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
        }
    }

    public void Jump()
    {
        if (Physics2D.gravity.x != 0)
        {
            rigid.AddForce(new Vector2((Physics2D.gravity.x / Mathf.Abs(Physics2D.gravity.x)) * -jumpForce *
                (rigid.gravityScale / Mathf.Abs(rigid.gravityScale)) * 200, 0));
            grounded = false;
        }
        else
        {
            rigid.AddForce(new Vector2(0, Physics2D.gravity.y / Mathf.Abs(Physics2D.gravity.y) * -jumpForce *
                (rigid.gravityScale / Mathf.Abs(rigid.gravityScale)) * 200));
            grounded = false;
        }
    }

    public void DashRight()
    {
        velocity += new Vector2(dashForce, 0);
    }
}
