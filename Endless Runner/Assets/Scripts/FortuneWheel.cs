using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.iOS;

public class FortuneWheel : MonoBehaviour {

    Vector3 mouseReference;
    Vector3 mouseOffset;

    public float sensitivity;
    public float deadZone;
    public float rotationDecrease;

    bool isClicking;
    bool locked;
    bool hasRotated = false;


    Vector3 rotation;

    // Use this for initialization
    void Start()
    {
        isClicking = false;
        rotation = Vector3.zero;
        locked = false;
    }


    void Update()
    {
        //If is dragging for rotation
        if (isClicking && !locked)
        {
            //Calculate the mouse offset in relation to its drag position, calculate the rotation amount and apply it
            mouseOffset = Input.mousePosition - mouseReference;

            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity;

            transform.Rotate(rotation);

            mouseReference = Input.mousePosition;
        }
        //If klicking for drag stopped
        if (!isClicking)
        {
            //If rotation was applied, let the wheel spin
            if (!(rotation.z < deadZone) || !(rotation.z > -deadZone))
            {
                locked = true;
                rotation = rotation / rotationDecrease;
                transform.Rotate(rotation);

                //Flag that the wheel spinned one time for result
                hasRotated = true;
            }
            //If not rotating and not clicking unlock the wheel
            else
            {
                locked = false;

                if (hasRotated) Result();
            }
        }


    }

    //Mouse klick (Rotation drag starts)
    private void OnMouseDown()
    {
        if (!locked) isClicking = true;
        mouseReference = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        isClicking = false;
    }

    private void Result()
    {
        SceneManager.LoadScene("FortuneWheel");
    }
    
}


