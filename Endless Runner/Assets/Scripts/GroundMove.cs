using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {

    public Vector2 direction;

	// Use this for initialization
	void Start () {
        direction = new Vector2(1, 0);
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void RotateLeft()
    {
        if (direction.x == 1 && direction.y == 0)
            direction.Set(0, 1);
        else if (direction.x == 0 && direction.y == -1)
            direction.Set(1, 0);
        else if (direction.x == -1 && direction.y == 0)
            direction.Set(0, -1);
        else if (direction.x == 0 && direction.y == 1)
            direction.Set(-1, 0);
    }

    public void RotateRight()
    {
        if (direction.x == 1 && direction.y == 0)
            direction.Set(0, -1);
        else if (direction.x == 0 && direction.y == -1)
            direction.Set(-1, 0);
        else if (direction.x == -1 && direction.y == 0)
            direction.Set(0, 1);
        else if (direction.x == 0 && direction.y == 1)
            direction.Set(1, 0);
    }
}
