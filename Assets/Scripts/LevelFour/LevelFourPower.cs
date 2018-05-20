using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourPower : MonoBehaviour {

    [SerializeField]
    private GameObject[] Tubes;

    [SerializeField]
    private GameObject Elevator;

    private int completedTubes = 0;

    //private bool allActive = true;

    // Use this for initialization
    void Start () {
		
	}

    public void CheckAllTubes()
    {
        bool allActive = true;

        for (int i = 0; i < Tubes.Length; i++)
        {
            if (Tubes[i].GetComponent<TubeDetector>().tubeCompleted == false)
            {
                allActive = false;
                Debug.Log(i);
            }
        }

        if (allActive == true)
        {
            Elevator.GetComponent<Elevator>().OpenDoors();
        }
    }
}
