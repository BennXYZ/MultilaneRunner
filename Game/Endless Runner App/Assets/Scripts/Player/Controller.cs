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

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Up.Invoke();
        if (Input.GetMouseButtonDown(0))
            Up.Invoke();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Right.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Left.Invoke();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Down.Invoke();
    }
}
