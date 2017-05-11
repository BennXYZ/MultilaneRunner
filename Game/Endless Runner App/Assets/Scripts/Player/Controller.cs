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

    [SerializeField]
    float actionDistance;

    bool freeze = false;

    bool action;

    Vector2 clickBegin;
    Vector2 clickEnd;

    // Use this for initialization
    void Start () {
        action = false;
    }
	
    public void setFreeze(bool freeze)
    {
        this.freeze = freeze;
    }

	// Update is called once per frame
	void Update () {
        if(!freeze)
        {
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


            if (Input.GetMouseButtonDown(0) && !action)
            {
                clickBegin = Input.mousePosition;
                action = true;
            }

            if (action &&(Input.GetMouseButtonUp(0) || (Input.GetMouseButton(0) && Vector2.Distance(Input.mousePosition,clickBegin) > actionDistance)))
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

                action = false;
            }
        }
    }
}
