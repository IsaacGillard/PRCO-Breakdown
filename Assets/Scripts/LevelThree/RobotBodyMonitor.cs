using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobotBodyMonitor : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    private bool noRobotSpawned = true;

	// Use this for initialization
	void Start () {
		
	}


    // Update is called once per frame
    void Update () {

        
		
	}

   
    public void CommitBody()
    {
        
        EventSystem.GetComponent<RobotSpawner>().SpawnBody();
    }

    public void CheckForActiveRobot()
    {
        for (int i = 0; i < EventSystem.GetComponent<RobotSpawner>().cloneToSpawn.Length; i++)
        {
            if (EventSystem.GetComponent<RobotSpawner>().cloneToSpawn[i])
            {
                if (EventSystem.GetComponent<RobotSpawner>().cloneToSpawn[i].activeInHierarchy)
                {
                    noRobotSpawned = false;
                    break;

                }
                if (noRobotSpawned == true)
                {
                    CommitBody();
                }
            }
            if (noRobotSpawned == true)
            {
                CommitBody();
            }

        }

        

    }
}
