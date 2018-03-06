using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WiresMiniGame : MonoBehaviour {

    public GameObject brokenWires;
    public GameObject fixedWires;
    public GameObject elevatorButton;
    public GameObject elevator;
    public Transform Player;

    // Use this for initialization
    void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("r"))
        {
            fixedWires.SetActive(true);
            elevatorButton.SetActive(true);
            elevator.SetActive(true);
            Player.GetComponent<Raycast>().WiresMiniGameCompleted();
        }
        if (Input.GetKeyDown("g") || Input.GetKeyDown("b"))
        {
            Player.GetComponent<Raycast>().WiresMiniGameFailed();
        }

    }
}
