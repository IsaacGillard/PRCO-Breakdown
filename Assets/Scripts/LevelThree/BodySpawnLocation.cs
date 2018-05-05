using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawnLocation : MonoBehaviour {

    public GameObject EventSystem;

    public bool bodyInLocation = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Body")
        {
            EventSystem.GetComponent<RobotSpawner>().ResetLerp();
            bodyInLocation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Body")
        {
            bodyInLocation = false;
        }
    }
}
