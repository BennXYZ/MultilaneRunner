using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onTriggerScript : MonoBehaviour {

    enum States { Enter, Update, Exit};

    [SerializeField]
    States state;

    [SerializeField]
    string objectTag;

    [SerializeField]
    UnityEvent Triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == States.Enter)
            if (collision.gameObject.tag == objectTag)
                Triggered.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (state == States.Update)
            if (collision.gameObject.tag == objectTag)
                Triggered.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (state == States.Exit)
            if (collision.gameObject.tag == objectTag)
                Triggered.Invoke();
    }
}
