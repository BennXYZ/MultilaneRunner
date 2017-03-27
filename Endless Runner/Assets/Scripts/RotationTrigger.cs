using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotationTrigger : MonoBehaviour
{
    UnityEvent RotateRight;
    UnityEvent RotateLeft; 

    Players players;

    // Use this for initialization
    void Start()
    {
        RotateLeft = new UnityEvent();
        RotateRight = new UnityEvent();
        players = GameObject.FindGameObjectWithTag("Game").GetComponent<Players>();
        RotateRight.AddListener(players.RotateRight);
        RotateLeft.AddListener(players.RotateLeft);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Random.Range(0, 1) == 1)
            {
                RotateRight.Invoke();
            }

            else
            {
                RotateLeft.Invoke();
            }
        }
    }
}
