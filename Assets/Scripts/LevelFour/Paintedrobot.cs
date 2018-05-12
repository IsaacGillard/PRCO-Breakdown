using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintedrobot : MonoBehaviour {

    public string[] RobotStats;
    public Material[] PaintJobs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowValues()
    {
        for (int i = 0; i < RobotStats.Length; i++)
        {
            Debug.Log(RobotStats[i]);
        }
    }

    public void PaintRobot()
    {
        if (RobotStats[1] == "Suit")
        {
            this.GetComponent<Renderer>().material = PaintJobs[1];
        }
    }
}
