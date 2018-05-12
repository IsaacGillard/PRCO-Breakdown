using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedRobot : MonoBehaviour {

    public int[] robotStatistics;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowValues ()
    {
        for (int i = 0; i < robotStatistics.Length; i++)
        {
            Debug.Log(robotStatistics[i]);
        }
    }
}
