using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {

    enum Directions { Right = 1, Down = 2, Left = 3, Up = 4}
    Directions direction;
    int rotating;
    float targetRotation;

	// Use this for initialization
	void Start () {
        direction = Directions.Right;
        rotating = 0;
        targetRotation = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && rotating == 0)
        {
            direction--;
            if ((int)direction < 1)
                direction = Directions.Up;
            rotating = -1;
            targetRotation = transform.rotation.eulerAngles.z + 90;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && rotating == 0)
        {
            direction++;
            if ((int)direction > 4)
                direction = Directions.Right;
            rotating = 1;
            targetRotation = transform.rotation.eulerAngles.z - 90;
        }

        if (rotating == -1)
            RotateLeft();
        if (rotating == 1)
            RotateRight();
    }

    public void RotateLeft()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
        if (transform.rotation.eulerAngles.z > targetRotation || (transform.rotation.eulerAngles.z < 10 && targetRotation >= 360))
        {
            transform.Rotate(0, 0, targetRotation - transform.rotation.eulerAngles.z);
            rotating = 0;
        }
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
    , -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));
    }

    public void RotateRight()
    {
        Debug.Log(targetRotation);

        transform.Rotate(0, 0, - 90 * Time.deltaTime);

        if (targetRotation < 0)
            targetRotation = 270;
        if (transform.rotation.eulerAngles.z < targetRotation || (transform.rotation.eulerAngles.z > 350 && targetRotation <= 0))
        {
            transform.Rotate(0, 0, targetRotation - transform.rotation.eulerAngles.z);
            rotating = 0;
        }
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
    , -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));
    }
}
