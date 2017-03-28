using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayers : MonoBehaviour {

    Rigidbody2D rigid;

    [SerializeField]
    float jumpForce;

    // Use this for initialization
    void Start () {

        rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
    public void Jump()
    {
        rigid.AddForce(new Vector2(Physics2D.gravity.x * jumpForce * 100 * -rigid.gravityScale, Physics2D.gravity.y * jumpForce * 100 * -rigid.gravityScale));
    }

	// Update is called once per frame
	void Update () {
        if (transform.localPosition.x > 0.01f)
            transform.localPosition = new Vector3(transform.localPosition.x - 0.8f * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
        else if (transform.localPosition.x < -0.01f)
            transform.localPosition = new Vector3(transform.localPosition.x + 0.8f * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
        else
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spikes")
        {
            transform.parent.parent.gameObject.GetComponent<Players>().TakeDamage();
            rigid.AddForce(new Vector2(Physics2D.gravity.y * jumpForce * 50 * rigid.gravityScale, Physics2D.gravity.x * jumpForce * 50 * rigid.gravityScale));
        }
    }
}
