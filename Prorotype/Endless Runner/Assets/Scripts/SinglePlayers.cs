using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayers : MonoBehaviour {

    Rigidbody2D rigid;

    GameController game;

    [SerializeField]
    float jumpForce;

    // Use this for initialization
    void Start () {

        game = GameObject.FindGameObjectWithTag("Game").GetComponent<GameController>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
    public void Jump(int direction)
    {
        if(game.direction == GameController.Directions.Right && direction == 4)
        rigid.AddForce(new Vector2(Physics2D.gravity.x * jumpForce * 100 * -rigid.gravityScale, Physics2D.gravity.y * jumpForce * 100 * -rigid.gravityScale));

        if (game.direction == GameController.Directions.Down && direction == 1)
            rigid.AddForce(new Vector2(Physics2D.gravity.x * jumpForce * 100 * -rigid.gravityScale, Physics2D.gravity.y * jumpForce * 100 * -rigid.gravityScale));

        if (game.direction == GameController.Directions.Left && direction == 2)
            rigid.AddForce(new Vector2(Physics2D.gravity.x * jumpForce * 100 * -rigid.gravityScale, Physics2D.gravity.y * jumpForce * 100 * -rigid.gravityScale));

        if (game.direction == GameController.Directions.Up && direction == 3)
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
            GameObject.FindGameObjectWithTag("Game").GetComponent<HealthController>().TakeDamage();
        }
    }
}
