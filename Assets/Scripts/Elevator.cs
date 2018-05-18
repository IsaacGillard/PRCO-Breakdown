using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject AudioManager;

    [SerializeField]
    private GameObject LeftDoor;

    [SerializeField]
    private GameObject RightDoor;

    [SerializeField]
    private GameObject LeftSpawnA;
    [SerializeField]
    private GameObject LeftSpawnB;
    [SerializeField]
    private GameObject RightSpawnA;
    [SerializeField]
    private GameObject RightSpawnB;

    [HideInInspector]
    public bool levelComplete;

    private float lerpTime = 3;
    private float currentLerpTime = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(levelComplete == true)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float percentage = currentLerpTime / lerpTime;
            LeftDoor.transform.position = Vector3.Lerp(LeftSpawnA.transform.position, LeftSpawnB.transform.position, percentage);
            RightDoor.transform.position = Vector3.Lerp(RightSpawnA.transform.position, RightSpawnB.transform.position, percentage);
        }
		
	}

    public void OpenDoors()
    {
        AudioManager.GetComponent<AudioManager>().Play("Elevator");
        levelComplete = true;

    }
}
