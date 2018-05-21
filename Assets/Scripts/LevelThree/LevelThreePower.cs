using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreePower : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject AudioManager;

    [SerializeField]
    private GameObject Elevator;

    private int terminalsWithPower = 1;

    public GameObject terminalTwo;
    public GameObject terminalThree;
    public GameObject terminalFour;

    public Material[] powerLights;
    public GameObject terminalTwoLight;

    public Material[] monitorScreens;
    public GameObject terminalTwoScreen;
    public GameObject terminalThreeScreen;
    public GameObject terminalFourScreen;

    [SerializeField]
    private GameObject WireBoxCover;

    [SerializeField]
    private GameObject[] Capsules;

    private bool LevelComplete = false;

    private bool AllCapsulesComplete = false;

    private int LevelProgression = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // detect if terminals have power, and update their screens

        if(terminalTwo.activeInHierarchy)
        {
            terminalsWithPower += 1;
            TerminalPowerOn();
            MonitorScreenOn(terminalTwoScreen);
            terminalTwoScreen.tag = "USB";
        }
        if (terminalThree.activeInHierarchy)
        {
            terminalsWithPower += 1;
            MonitorScreenOn(terminalThreeScreen);
            terminalThreeScreen.tag = "USB";
        }
        if (terminalFour.activeInHierarchy)
        {
            terminalsWithPower += 1;
            MonitorScreenOn(terminalFourScreen);
            terminalFourScreen.tag = "USB";
        }
        if (terminalsWithPower == 4)
        {

        }

        // check level progression 
        if (LevelProgression == 0)
        {
            if (!WireBoxCover.activeInHierarchy)
            {
                EventSystem.GetComponent<LevelProgression>().UpdateProgression();
                LevelProgression = 1;
            }

        }
        if (LevelProgression == 1)
        {
            AllCapsulesComplete = true;

            for (int i = 0; i < Capsules.Length; i++)
            {
                if (!Capsules[i].activeInHierarchy)
                {
                    AllCapsulesComplete = false;
                    break;
                }
            }

            if (AllCapsulesComplete == true)
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

    private void TerminalPowerOn()
    {
        terminalTwoLight.GetComponent<Renderer>().material = powerLights[1];
    }

    private void MonitorScreenOn(GameObject target)
    {
        target.GetComponent<Renderer>().material = monitorScreens[2];
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
