using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPickup : MonoBehaviour {
    public Transform hand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pickup()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = hand.position;
        this.transform.parent = GameObject.Find("RobotPlayer").transform;
        this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
    }

    public void Drop()
    {
        this.transform.parent = null;
        //GetComponent<Rigidbody>().useGravity = true;
    }
}
