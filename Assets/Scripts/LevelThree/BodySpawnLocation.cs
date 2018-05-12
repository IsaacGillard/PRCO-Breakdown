﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawnLocation : MonoBehaviour {

    public GameObject EventSystem;

    public bool bodyInLocation = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Body")
        {
            Debug.Log("Anus");
            EventSystem.GetComponent<RobotSpawner>().ResetLerp();
            bodyInLocation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Body")
        {
            Debug.Log("fart");
            bodyInLocation = false;
        }
    }
}
