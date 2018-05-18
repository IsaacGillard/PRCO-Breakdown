using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoPower : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject AudioManager;

    [SerializeField]
    private GameObject PowerSwitch;

    [SerializeField]
    private GameObject[] PowerColumns;

    [SerializeField]
    private GameObject Elevator;

    private bool allColumnsActive = false;

    private bool LevelComplete = false;


    private int LevelProgression = 0;



    // Use this for initialization
    void Start () {
        AudioManager.GetComponent<AudioManager>().Play("Generator");
    }
	
	// Update is called once per frame
	void Update () {

        if (LevelProgression == 0)
        {
            allColumnsActive = true;

            for (int i = 0; i < PowerColumns.Length; i++)
            {
                if (!PowerColumns[i].activeInHierarchy)
                {
                    allColumnsActive = false;
                    break;
                }
            }

            if (allColumnsActive == true)
            {
                EventSystem.GetComponent<LevelProgression>().UpdateProgression();
                LevelProgression = 1;
            }

        }
        if (LevelProgression == 1)
        {
            if (PowerSwitch.activeInHierarchy)
            {
                EventSystem.GetComponent<LevelProgression>().UpdateProgression();
                LevelProgression = 2;
            }
        }

        if (Elevator.GetComponent<Elevator>().levelComplete == true)
        {
            EndlevelComment();
        }

    }

    public void EndlevelComment()
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
