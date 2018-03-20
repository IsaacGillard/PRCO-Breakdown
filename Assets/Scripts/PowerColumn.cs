using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerColumn : MonoBehaviour {

    [SerializeField]
    private GameObject energyTube;

	// Use this for initialization
	void Start () {
        energyTube.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PowerOn()
    {
        energyTube.SetActive(true);
    }
}
