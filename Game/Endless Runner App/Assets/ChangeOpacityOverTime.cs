using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeOpacityOverTime : MonoBehaviour {

    [SerializeField]
    Image image;

    float targetOpacity = 0;

	// Use this for initialization
	void Start () {
        Debug.Log(image.color.a);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(targetOpacity);
        Debug.Log(image.color.a);
        if (targetOpacity < image.color.a)
            image.color = new Color(image.color.r,image.color.g,image.color.b,image.color.a - Time.deltaTime * 4);
        else if (targetOpacity > image.color.a)
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + Time.deltaTime * 4);
    }

    public void SetOpacity(float range)
    {
        targetOpacity = range;
    }
}
