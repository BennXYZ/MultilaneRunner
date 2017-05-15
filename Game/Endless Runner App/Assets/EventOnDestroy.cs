using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnDestroy : MonoBehaviour {

    [SerializeField]
    UnityEvent myEvent;

    private void OnDestroy()
    {
        myEvent.Invoke();
    }
}
