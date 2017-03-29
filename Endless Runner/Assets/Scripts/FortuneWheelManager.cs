using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FortuneWheelManager : MonoBehaviour
{
    int spinAmount;
    public int SpinAmount
    {
        get { return spinAmount; }
        set { spinAmount = value; }
    }

    [SerializeField]
    float timerToSwitch;

    float timer;


	void Start ()
    {
        //GameObject.FindGameObjectWithTag("GameManager") //Get Component and Spin Amount
        SpinAmount = 3;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(spinAmount);

        if(spinAmount <= 0)
        {
            timer += Time.deltaTime;
        }

        if(timer >= timerToSwitch)
        {
            SceneManager.LoadScene("FortuneWheel");
        }
	}
}
