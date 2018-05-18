using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using UnityStandardAssets.Characters.FirstPerson;

public class RobotUI : MonoBehaviour {

    public GameObject screenOverlay;
    public GameObject robot;
    private GameObject fishEye;

	// Use this for initialization
	void Start () {

        fishEye = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {

        if (robot.activeInHierarchy)
        {
            screenOverlay.SetActive(true);
        }
        else if (!robot.activeInHierarchy)
        {
            screenOverlay.SetActive(false);
        }
		
	}
}
