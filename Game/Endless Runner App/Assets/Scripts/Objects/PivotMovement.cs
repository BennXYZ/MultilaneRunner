using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMovement : MonoBehaviour {

    [SerializeField]
    GameObject[] Pivots;

    [SerializeField]
    float speed;

    [SerializeField]
    bool backtrackMovement;
    bool backtracking;

    Vector2 velocity;

    int nextPivot;

	// Use this for initialization
	void Start () {
        nextPivot = 0;
	}
	
	// Update is called once per frame
	void Update () {
        velocity += (new Vector2(Pivots[nextPivot].transform.position.x - transform.position.x, Pivots[nextPivot].transform.position.y - transform.position.y).normalized);
        transform.Translate(velocity * Time.deltaTime * speed);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovementPivot" && collision.gameObject == Pivots[nextPivot])
        {
            if (!backtrackMovement)
            {
                if (nextPivot + 1 >= Pivots.Length)
                    nextPivot = 0;
                else
                    nextPivot++;
            }
            else
            {
                if (backtracking)
                {
                    if (nextPivot - 1 < 0)
                    {
                        backtracking = false;
                        nextPivot++;
                    }
                    else
                        nextPivot--;
                }
                else
                {
                    if (nextPivot + 1 == Pivots.Length)
                    {
                        backtracking = true;
                        nextPivot--;
                    }
                    else
                        nextPivot++;
                }
            }
        }
    }
}
