﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobotTesting : MonoBehaviour {

    private GameObject Robot;

    private int StagesPassed = 0;

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject Trigger;

    [SerializeField]
    private GameObject StartScreen;

    [SerializeField]
    private GameObject NoRobotInCapsule;

    [SerializeField]
    private GameObject TestingScreen;

    [SerializeField]
    private TextMeshProUGUI EyeValue;

    [SerializeField]
    private TextMeshProUGUI VoiceValue;

    [SerializeField]
    private TextMeshProUGUI ThrusterValue;

    [SerializeField]
    private GameObject SuccessButton;

    [SerializeField]
    private GameObject FailureButton;

    private int EyeResult;
    private int VoiceResult;
    private int ThrusterResult;



    // Use this for initialization
    private void OnEnable()
    {
        TestingScreen.SetActive(false);
        StagesPassed = 0;
        SuccessButton.SetActive(false);
        FailureButton.SetActive(false);

        if (Trigger.GetComponent<BodySpawnLocation>().bodyInLocation == true)
        {
            Robot = EventSystem.GetComponent<RobotSpawner>().CompletedRobot;
            StartScreen.SetActive(true);
            NoRobotInCapsule.SetActive(false);
        }
        else
        {
            StartScreen.SetActive(false);
            NoRobotInCapsule.SetActive(true);
        }
        
    }

    public void TestRobot()
    {
        TestingScreen.SetActive(true);
        StartScreen.SetActive(false);
        EyeTest();
        VoiceTest();
        ThrusterTest();

        if (StagesPassed == 3)
        {
            SuccessButton.SetActive(true);
        }
        else
        {
            FailureButton.SetActive(true);
        }
    }

    void EyeTest()
    {
        EyeResult = Robot.GetComponent<CompletedRobot>().robotStatistics[0];

        if (EyeResult == 60)
        {
            EyeValue.text = "Pass";
            StagesPassed += 1;
        }
        else
        {
            EyeValue.text = "Fail";
        }
    }

    void VoiceTest()
    {
        VoiceResult = Robot.GetComponent<CompletedRobot>().robotStatistics[1];

        if (VoiceResult == 2)
        {
            VoiceValue.text = "Pass";
            StagesPassed += 1;
        }
        else
        {
            VoiceValue.text = "Fail";
        }
    }

    void ThrusterTest()
    {
        ThrusterResult = Robot.GetComponent<CompletedRobot>().robotStatistics[2];

        if (ThrusterResult == 50)
        {
            ThrusterValue.text = "Pass";
            StagesPassed += 1;
        }
        else
        {
            ThrusterValue.text = "Fail";
        }
    }
}