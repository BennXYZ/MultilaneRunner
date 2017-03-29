using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotationTrigger : MonoBehaviour
{
    UnityEvent RotateRight;
    UnityEvent RotateLeft;

    RotationManager players;
    GroundMove groundmove;
    GameController game;

    bool triggered;

    // Use this for initialization
    void Start()
    {
        RotateLeft = new UnityEvent();
        RotateRight = new UnityEvent();
        triggered = false;
        players = GameObject.FindGameObjectWithTag("Players").GetComponent<RotationManager>();
        groundmove = gameObject.transform.parent.GetComponent<GroundMove>();
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<GameController>();
        RotateRight.AddListener(players.RotateRight);
        RotateRight.AddListener(groundmove.RotateRight);
        RotateRight.AddListener(game.RotateRight);
        RotateLeft.AddListener(players.RotateLeft);
        RotateLeft.AddListener(groundmove.RotateLeft);
        RotateLeft.AddListener(game.RotateLeft);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !triggered)
        {
            if (Random.Range(0, 0) == 1)
            {
                RotateRight.Invoke();
            }

            else
            {
                RotateLeft.Invoke();
            }

            triggered = true;
        }
    }
}
