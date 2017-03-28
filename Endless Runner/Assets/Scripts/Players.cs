using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Players : MonoBehaviour
{

    [SerializeField]
    private UnityEvent UpdateHealth;

    [SerializeField]
    private UnityEvent Death;

    public enum Directions { Right = 1, Down = 2, Left = 3, Up = 4 }
    Directions direction;
    int rotating;
    float targetRotation;
    bool rotationChanged;

    [SerializeField]
    private int health;

    [SerializeField]
    float rotationTime;

    // Use this for initialization
    void Start()
    {
        rotationChanged = false;
        direction = Directions.Right;
        rotating = 0;
        targetRotation = 0;
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
, -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));


    }

    public int GetHealth()
    {
        return health;
    }

    public Directions Direction()
    {
        return direction;
    }

    public void TakeDamage()
    {
        health--;
        UpdateHealth.Invoke();
        if (health == 0)
            Death.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (rotating == 0)
        {
            rotating = 1;
            targetRotation = transform.rotation.eulerAngles.z - 90;
        }
    }

    public void RotateLeft()
    {
        if (rotating == 0)
        {
            rotating = -1;
            targetRotation = transform.rotation.eulerAngles.z + 90;
        }
    }

    private void RotatingLeft()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime / rotationTime);

        if (transform.rotation.eulerAngles.z + 45 > targetRotation && !rotationChanged)
        {
            direction--;
            if ((int)direction < 1)
                direction = Directions.Up;
            rotationChanged = true;
        }

        if (transform.rotation.eulerAngles.z > targetRotation || (transform.rotation.eulerAngles.z < 30 && targetRotation >= 330))
        {
            transform.Rotate(0, 0, targetRotation - transform.rotation.eulerAngles.z);
            rotating = 0;
            rotationChanged = false;
        }
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
    , -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI));
    }

    private void RotatingRight()
    {
        transform.Rotate(0, 0, -90 * Time.deltaTime / rotationTime);

        if (targetRotation < -10)
            targetRotation = 270;

        if (transform.rotation.eulerAngles.z - 45 < targetRotation && !rotationChanged)
        {
            direction++;
            if ((int)direction > 4)
                direction = Directions.Right;
            rotationChanged = true;
        }

        if (transform.rotation.eulerAngles.z < targetRotation || (transform.rotation.eulerAngles.z > 330 && targetRotation <= 30))
        {
            transform.Rotate(0, 0, targetRotation - transform.rotation.eulerAngles.z);
            rotating = 0;
            rotationChanged = false;
        }
        Physics2D.gravity = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z / 180 * Mathf.PI)
    , -Mathf.Cos(transform.rotation.eulerAngles.z / 180 * Mathf.PI))
;

    }
}
