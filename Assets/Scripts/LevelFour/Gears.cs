using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : MonoBehaviour {

    private GameObject[] leftGears;
    private GameObject[] rightGears;
    private bool turnGears;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

            Turn();
		
	}

    private void Turn()
    {
        leftGears = GameObject.FindGameObjectsWithTag("leftGear");
        rightGears = GameObject.FindGameObjectsWithTag("rightGear");

        foreach(GameObject gear in leftGears)
        {
            gear.transform.Rotate(0, 0, 1);
        }

        foreach (GameObject gear in rightGears)
        {
            gear.transform.Rotate(0, 0, -1);
        }
    }
}
