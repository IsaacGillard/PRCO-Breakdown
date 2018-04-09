﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPickup : MonoBehaviour {

    public Transform hand;
    public bool isDropped = true;
    public Material[] material;

    // Use this for initialization
    void Start () {
        this.GetComponent<Renderer>().material = material[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pickup()
    {
        this.GetComponent<Renderer>().material = material[1];
        isDropped = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = hand.position;
        this.transform.parent = GameObject.Find("RobotPlayer").transform;
        this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
    }

    public void Drop()
    {
        this.GetComponent<Renderer>().material = material[0];
        isDropped = true;
        this.transform.parent = null;
        //GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "tube")
        {
            Debug.Log("Huzzah");
        }
    }
}
