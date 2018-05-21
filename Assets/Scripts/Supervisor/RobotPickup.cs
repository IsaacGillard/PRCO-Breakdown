using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPickup : MonoBehaviour {

    private GameObject AudioManager;

    public Transform hand;
    public bool isDropped = true;
    public Material[] material;
    public GameObject RobotPlayer;

    // Use this for initialization
    void Start () {

        AudioManager = GameObject.Find("AudioManager");
        material[0] = this.GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {

        if(GameObject.Find("RobotPlayer").activeInHierarchy)
        {
            hand = GameObject.Find("RobotHand").transform;
        }
		
	}

    public void Pickup()
    {
        // pick up robot and place it at location of hand, and make it child of supervisor
        this.GetComponent<Renderer>().material = material[1];
        isDropped = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = hand.position;
        this.transform.parent = GameObject.Find("RobotPlayer").transform;
        this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
        
        // depending on personality of picked up robot, play sound relating to that personality
        if (this.GetComponent<Paintedrobot>().RobotStats[1] == "Overalls")
        {
            Debug.Log("Huzzah1");
            AudioManager.GetComponent<AudioManager>().Play("Maintenance");
        }
        else if (this.GetComponent<Paintedrobot>().RobotStats[1] == "Suit")
        {
            Debug.Log("Huzzah2");
            AudioManager.GetComponent<AudioManager>().Play("Sales");
        }
        else if (this.GetComponent<Paintedrobot>().RobotStats[1] == "Military")
        {
            Debug.Log("Huzzah3");
            AudioManager.GetComponent<AudioManager>().Play("Security");
        }
        else if (this.GetComponent<Paintedrobot>().RobotStats[1] == "Nerdy")
        {
            Debug.Log("Huzzah4");
            AudioManager.GetComponent<AudioManager>().Play("TechSupport");
        }

    }

    public void Drop()
    {
        // drop the robot at position
        this.GetComponent<Renderer>().material = material[0];
        isDropped = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "tube")
        {
            
        }
    }
}
