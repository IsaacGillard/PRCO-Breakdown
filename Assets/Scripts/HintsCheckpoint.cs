using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsCheckpoint : MonoBehaviour {

    public GameObject EventSystem;

	// Use this for initialization
	void Start () {

        EventSystem.GetComponent<LevelProgression>().UpdateProgression();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
