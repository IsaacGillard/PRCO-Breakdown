using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ScrewScreen : MonoBehaviour {

    public Transform Player;

	// Use this for initialization
	void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("help");
        Player.GetComponent<FirstPersonController>().enabled = false;
    }
}
