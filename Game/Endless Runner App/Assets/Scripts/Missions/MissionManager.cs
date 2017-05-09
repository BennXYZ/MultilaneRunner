using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionManager : MonoBehaviour {

    int[] missionProgressPoints;

    [SerializeField]
    int missionNumber;

    [SerializeField]
    GameObject[] possibleMissions;

    GameObject[] currentMissions;

    //List of Missions
        
        // 0 None. Null. Nothing. Just ignore the 0. It's pointless.
        // 1 ???

	// Use this for initialization
	void Start () {
        missionProgressPoints = new int[missionNumber];
        currentMissions = new GameObject[3];
        GetSavedMissions();
        CheckEmptyMissions();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckEmptyMissions()
    {
        for(int i = 0; i < 3; i++)
        {
            if(currentMissions[i] == null)
            {
                GameObject pickAMission = possibleMissions[Random.Range(1,possibleMissions.Length)];
                while(Contains(currentMissions, pickAMission))
                {
                    pickAMission = possibleMissions[Random.Range(1, possibleMissions.Length)];
                }
            }
        }
    }

    bool Contains(GameObject[] objects, GameObject searchedObject)
    {
        for(int i = 0; i < objects.Length; i++)
        {
            if (objects[i] == searchedObject)
                return true;
        }
        return false;
    }

    void GetSavedMissions()
    {
        for(int i = 0; i < 3; i++)
        {
            if (possibleMissions[PlayerPrefs.GetInt("Mission" + i.ToString(), 0)] != null)
                currentMissions[i] = possibleMissions[PlayerPrefs.GetInt("Mission" + i.ToString(), 0)];
        }
    }

    public void CheckMissions()
    {
        for(int i = 0; i < 3; i++)
        {
            
        }
    }

    public void MissionProgress(int index, int value)
    {
        missionProgressPoints[index] += value;
    }
}
