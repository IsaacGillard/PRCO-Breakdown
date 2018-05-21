using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOnePower : MonoBehaviour {

    public GameObject EventSystem;
    public GameObject ScrewPanel;
    public GameObject Wires;
    public GameObject ElevatorDoor;
    public GameObject AudioManager;

    private bool LevelComplete = false;


    private int LevelProgression = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // detect players progression through the level, and update the hints they can recieve
        if (LevelProgression == 0)
        {
            if(!ScrewPanel.activeInHierarchy)
            {
                EventSystem.GetComponent<LevelProgression>().UpdateProgression();
                LevelProgression = 1;
            }
        }
        if (LevelProgression == 1)
        {
            if (!Wires.activeInHierarchy)
            {
                EventSystem.GetComponent<LevelProgression>().UpdateProgression();
                LevelProgression = 2;
            }
        }

        if(!ElevatorDoor.activeInHierarchy)
        {
            EndlevelComment();
        }

    }

    private void EndlevelComment()
    {
        if (LevelComplete == false)
        {
            if (EventSystem.GetComponent<SupervisorOpinion>().OpinionMeter.value < 5)
            {
                Debug.Log("Bad");
                AudioManager.GetComponent<AudioManager>().Play("EndLevelBad");
            }
            else
            {
                Debug.Log("Good");
                AudioManager.GetComponent<AudioManager>().Play("EndLevelGood");
            }

            LevelComplete = true;
        }
        else
        {
            
        }
        
    }
}
