using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{

    [SerializeField]
    UnityEvent Left = new UnityEvent();

    [SerializeField]
    UnityEvent Right = new UnityEvent();

    [SerializeField]
    UnityEvent Up = new UnityEvent();

    [SerializeField]
    UnityEvent Down = new UnityEvent();

    List<Touch> touches;

    List<Vector2> touchOrigin;
    List<Vector2> touchEnd;
    List<Vector2> touchMovement;

    // Use this for initialization
    void Start()
    {
        touches = new List<Touch>();
        touchOrigin = new List<Vector2>();
        touchEnd = new List<Vector2>();
        touchMovement = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Left.Invoke();

            if (Input.GetKeyDown(KeyCode.RightArrow))
                Right.Invoke();

            if (Input.GetKeyDown(KeyCode.UpArrow))
                Up.Invoke();

            if (Input.GetKeyDown(KeyCode.DownArrow))
                Down.Invoke();
        }

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                touches.Add(Input.touches[i]);
            }
            for (int i = 0; i < touches.Count; i++)
            {
                if (touches[i].phase == TouchPhase.Began)
                {
                    touchOrigin.Add(touches[i].position);
                    touchEnd.Add(Vector2.zero);
                    touchMovement.Add(Vector2.zero);
                }
                else if (touches[i].phase == TouchPhase.Ended && touchOrigin[i].x >= 0)
                {
                    touchEnd[i] = touches[i].position;
                    touchMovement[i] = new Vector2(touchEnd[i].x - touchOrigin[i].x, touchEnd[i].y - touchOrigin[i].y);
                    touchOrigin.RemoveAt(i);
                    touchEnd.RemoveAt(i);

                    if (touchMovement[i].y > Mathf.Abs(touchMovement[i].x))
                        Up.Invoke();
                    else if (touchMovement[i].y < Mathf.Abs(touchMovement[i].x))
                        Down.Invoke();
                    else if (touchMovement[i].x > Mathf.Abs(touchMovement[i].y))
                        Right.Invoke();
                    else if (touchMovement[i].x < Mathf.Abs(touchMovement[i].y))
                        Left.Invoke();
                }
            }
        }
    }
}
