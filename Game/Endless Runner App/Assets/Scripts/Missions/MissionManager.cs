using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionManager : MonoBehaviour {

    int[] missionProgressPoints;

    [SerializeField]
    GameObject[] possibleMissions;

    GameObject[] currentMissions;

    //List of Missions
        
        // 0 None. Null. Nothing. Just ignore the 0. It's pointless.
        // 1 ???

	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(gameObject);
        //if (GameObject.FindGameObjectsWithTag("MissionManager").Length > 2)
        //    Destroy(gameObject);
        //else
        //{
            missionProgressPoints = new int[possibleMissions.Length];
            currentMissions = new GameObject[3];
            GetSavedMissions();
            CheckEmptyMissions();
            ResetsAtEndOfLevel();
            SaveMissions();
        //}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckEmptyMissions()
    {
        for(int i = 0; i < 3; i++)
        {
            while(currentMissions[i] == null)
            {
                int pickAMission = Random.Range(1, possibleMissions.Length);
                if (!Contains(currentMissionIndex(), possibleMissions[pickAMission].GetComponent<Mission>().index))
                    currentMissions[i] = GameObject.Instantiate(possibleMissions[pickAMission],transform);
            }
        }
    }

    int[] currentMissionIndex()
    {
        int[] numbers = new int[3];
        for(int i = 0; i < 3; i++)
        {
            if (currentMissions[i] != null)
                numbers[i] = currentMissions[i].GetComponent<Mission>().index;
            else
                numbers[i] = 0;
        }
        return numbers;
    }

    bool Contains(int[] numbers, int index)
    {
        for(int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == index)
                return true;
        }
        return false;
    }

    void GetSavedMissions()
    {
        for(int i = 0; i < 3; i++)
        {
            if (possibleMissions[PlayerPrefs.GetInt("Mission" + i.ToString(), 0)] != null)
            {
                currentMissions[i] = Instantiate(possibleMissions[PlayerPrefs.GetInt("Mission" + i.ToString(), 0)],transform);
                currentMissions[i].GetComponent<Mission>().AddProgress(PlayerPrefs.GetInt("MissionProgress" + i.ToString(), 0));
            }
        }
    }

    public void SaveMissions()
    {
        for(int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("Mission" + i.ToString(), currentMissions[i].GetComponent<Mission>().index);
            PlayerPrefs.SetInt("MissionProgress" + i.ToString(), currentMissions[i].GetComponent<Mission>().getProgress());
        }
    }

    public void CheckMissions()
    {
        for(int i = 0; i < 3; i++)
        {
            Mission mission = currentMissions[i].GetComponent<Mission>();
            mission.AddProgress(missionProgressPoints[mission.index]);
            missionProgressPoints[mission.index] = 0;
            if (mission.CheckProgress())
            {
                Destroy(currentMissions[i]);
                currentMissions[i] = null;
            }
        }
        CheckEmptyMissions();
        SaveMissions();
    }

    public Mission GetCurrentMission(int index)
    {
        return currentMissions[index].GetComponent<Mission>();
    }

    public void CheckProgress()
    {
        for (int i = 0; i < 3; i++)
        {
            Mission mission = currentMissions[i].GetComponent<Mission>();
            mission.AddProgress(missionProgressPoints[mission.index]);
            missionProgressPoints[mission.index] = 0;
        }
    }

    //public void CheckMissionProgress()
    //{
    //    for(int i = 0; i < 3; i++)
    //    {
    //        currentMissions[i].GetComponent<Mission>().CheckProgress();
    //    }
    //    CheckEmptyMissions();
    //}

        public void ResetProgress(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            Mission mission = currentMissions[i].GetComponent<Mission>();
            if (mission.index == index)
                mission.ResetProgress();
        }

    }

    public void MissionProgress(int index, int value)
    {
        missionProgressPoints[index] += value;
    }

    public void AddProgressByOne(int index)
    {
        missionProgressPoints[index] += 1;
    }

    public void ResetsAtEndOfLevel()
    {
        for(int i = 0; i < 3; i++)
        {
            currentMissions[i].GetComponent<Mission>().ResetOnLevelEnd();
        }
    }
}
