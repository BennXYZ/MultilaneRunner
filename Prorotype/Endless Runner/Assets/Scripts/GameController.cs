using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public enum Directions { Right = 1, Down = 2, Left = 3, Up = 4 }
    public Directions direction;
    public float rotation;
    float targetRotation;

    // Use this for initialization
    void Start ()
    {
        rotation = 0;
        direction = Directions.Right;
        rotation = 0;
        Physics2D.gravity = new Vector2(0, -1);
    }

    public Vector2 rotationAsVector()
    {
        return new Vector2(Mathf.Cos(Mathf.Deg2Rad * rotation), Mathf.Cos(Mathf.Deg2Rad * (rotation + 90)));
    }

    // Update is called once per frame
    void Update ()
    {

	}

    private void UpdateDirection()
    {
        if (rotation > 320 && rotation < 40)
            direction = Directions.Right;
        else if (rotation > 50 && rotation < 130)
            direction = Directions.Down;
        else if (rotation > 140 && rotation < 220)
            direction = Directions.Left;
        else if (rotation > 230 && rotation < 310)
            direction = Directions.Up;
    }

    public void RotateLeft()
    {
        switch(direction)
        {
            case Directions.Right:
                direction = Directions.Up;
                break;
            case Directions.Up:
                direction = Directions.Left;
                break;
            case Directions.Left:
                direction = Directions.Down;
                break;
            case Directions.Down:
                direction = Directions.Right;
                break;
        }
    }

    public void RotateRight()
    {
        switch (direction)
        {
            case Directions.Right:
                direction = Directions.Up;
                break;
            case Directions.Up:
                direction = Directions.Left;
                break;
            case Directions.Left:
                direction = Directions.Down;
                break;
            case Directions.Down:
                direction = Directions.Right;
                break;
        }
    }
}
