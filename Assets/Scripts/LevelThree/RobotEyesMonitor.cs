﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobotEyesMonitor : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject AudioManager;

    public GameObject EyeCapsule;

    public GameObject EyesMonitor;

    public GameObject NoRobotInCapsule;

    [SerializeField]
    private int[] LensStrength;

    private int currentLensStrength = 0;

    private int CommitedLensStrength;

    public TextMeshProUGUI LensStrengthValue;

    private void OnEnable()
    {
        NoRobotInCapsule.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

        LensStrengthValue.text = LensStrength[currentLensStrength].ToString() + "W";

    }

    public void IncreaseLensStrength()
    {
        if (currentLensStrength < 2)
        {
            currentLensStrength++;
        }
        else
        {
            currentLensStrength = 0;
        }
    }

    public void DecreaseLensStrength()
    {
        if (currentLensStrength > 0)
        {
            currentLensStrength--;
        }
        else
        {
            currentLensStrength = 2;
        }
    }

    public void CommitEyes()
    {
        if(EyeCapsule.GetComponent<BodySpawnLocation>().bodyInLocation == true)
        {
            // commit the users changes on the monito, and send the committed lens strength to the completed robot the player is building. Then spawn the next robot to be sent to the next capsule.
            AudioManager.GetComponent<AudioManager>().Play("Drill");
            CommitedLensStrength = LensStrength[currentLensStrength];
            EventSystem.GetComponent<RobotSpawner>().completedRobotStatistics[0] = CommitedLensStrength;
            EventSystem.GetComponent<RobotSpawner>().SpawnEyes();
        }
        else
        {
            EyesMonitor.SetActive(false);
            NoRobotInCapsule.SetActive(true);
        }
    }
}
