using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplayMission : MonoBehaviour {

    enum State { name, description, progress};

    [SerializeField]
    State state;

    Text text;

    [Range(0, 2)]
    [SerializeField]
    int missionNumber;

    Mission mission;

	// Use this for initialization
	void Start () {
	}

    private void OnEnable()
    {
        switch (state)
        {
            case State.name:
                text.text = mission.name;
                break;

            case State.description:
                text.text = mission.description;
                break;

            case State.progress:
                text.text = mission.getProgress().ToString() + " / " + mission.getGoal().ToString();
                break;
        }
    }

    private void Awake()
    {
        text = GetComponent<Text>();
        mission = GameObject.FindGameObjectWithTag("MissionManager").GetComponent<MissionManager>().GetCurrentMission(missionNumber);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
