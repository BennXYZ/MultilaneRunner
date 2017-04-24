using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour {

    [SerializeField]
    UnityEvent Up;

    [SerializeField]
    UnityEvent Down;

    [SerializeField]
    UnityEvent Right;

    [SerializeField]
    UnityEvent Left;

    [SerializeField]
    UnityEvent Shoot;

    [SerializeField]
    float shootingClickRange;

    Vector2 clickBegin;
    Vector2 clickEnd;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Up.Invoke();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Right.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Left.Invoke();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Down.Invoke();
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale != 0)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }


        if (Input.GetMouseButtonDown(0))
            clickBegin = Input.mousePosition;

        if(Input.GetMouseButtonUp(0))
        {
            clickEnd = Input.mousePosition;
            if (Vector2.Distance(clickBegin, clickEnd) < shootingClickRange)
                Shoot.Invoke();
            else
            {
                if (Mathf.Abs((clickEnd - clickBegin).x) > Mathf.Abs((clickEnd - clickBegin).y))
                {
                    if (clickBegin.x < clickEnd.x)
                        Right.Invoke();
                    else
                        Left.Invoke();
                }
                else
                {
                    if (clickEnd.y > clickBegin.y)
                        Up.Invoke();
                    else
                        Down.Invoke();
                }
            }
        }
    }
}
