using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {

    public enum Directions { Right = 1, Down = 2, Left = 3, Up = 4}
    Directions direction;
    int rotating;
    float targetRotation;

    [SerializeField]
    float rotationTime;

	// Use this for initialization
	void Start () {
        direction = Directions.Right;
        rotating = 0;
        targetRotation = 0;
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
, -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));


    }

    public Directions Direction()
    {
        return direction;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q) && rotating == 0)
        {
            rotating = -1;
            targetRotation = transform.rotation.eulerAngles.z + 90;
        }

        if (Input.GetKeyDown(KeyCode.E) && rotating == 0)
        {

        }

        if (rotating == -1)
            RotatingLeft();
        if (rotating == 1)
            RotatingRight();
        
        transform.position = new Vector3(-7 * Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI), transform.position.y, transform.position.z);
    }

    public void RotateRight()
    {
        rotating = 1;
        targetRotation = transform.rotation.eulerAngles.z - 90;
    }

    public void RotateLeft()
    {
        rotating = -1;
        targetRotation = transform.rotation.eulerAngles.z + 90;
    }

    private void RotatingLeft()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime / rotationTime);
        if (transform.rotation.eulerAngles.z > targetRotation || (transform.rotation.eulerAngles.z < 30 && targetRotation >= 330))
        {
            direction--;
            if ((int)direction < 1)
                direction = Directions.Up;
            transform.Rotate(0, 0, targetRotation - transform.rotation.eulerAngles.z);
            rotating = 0;
        }
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
    , -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));
    }

    private void RotatingRight()
    {
        transform.Rotate(0, 0, - 90 * Time.deltaTime / rotationTime);

        if (targetRotation < 0)
            targetRotation = 270;
        if (transform.rotation.eulerAngles.z < targetRotation || (transform.rotation.eulerAngles.z > 330 && targetRotation <= 30))
        {
            direction++;
            if ((int)direction > 4)
                direction = Directions.Right;
            transform.Rotate(0, 0, targetRotation - transform.rotation.eulerAngles.z);
            rotating = 0;
        }
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
    , -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));
    }
}
