using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{

    [SerializeField]
    UnityEvent JumpPlayer1 = new UnityEvent();

    [SerializeField]
    UnityEvent JumpPlayer2 = new UnityEvent();

    Players players;

    // Use this for initialization
    void Start()
    {
        players = gameObject.GetComponent<Players>();
    }

    // Update is called once per frame
    void Update()
    {
        Left();
        Right();
        Up();
        Down();
    }

    int Left()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            if(players.Direction() == Players.Directions.Up)
            {
                JumpPlayer1.Invoke();
                return 1;
            }
            else if (players.Direction() == Players.Directions.Down)
            {
                JumpPlayer2.Invoke();
                return 2;
            }
        return 0;
    }

    int Right()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            if (players.Direction() == Players.Directions.Up)
            {
                JumpPlayer2.Invoke();
                return 2;
            }
            else if (players.Direction() == Players.Directions.Down)
            {
                JumpPlayer1.Invoke();
                return 1;
            }
        return 0;
    }

    int Up()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            if (players.Direction() == Players.Directions.Right)
            {
                JumpPlayer1.Invoke();
                return 1;
            }
            else if (players.Direction() == Players.Directions.Left)
            {
                JumpPlayer2.Invoke();
                return 2;
            }
        return 0;
    }

    int Down()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            if(players.Direction() == Players.Directions.Left)
            {
                JumpPlayer1.Invoke();
                return 1;
            }
            else if (players.Direction() == Players.Directions.Right)
            {
                JumpPlayer2.Invoke();
                return 2;
            }

        return 0;
    }
}
