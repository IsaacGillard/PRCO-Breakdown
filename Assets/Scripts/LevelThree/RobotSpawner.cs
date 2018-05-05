using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] robotToSpawn;
    public GameObject[] cloneToSpawn;
    public GameObject BodySpawnLocation;
    public GameObject EyesSpawnLocation;
    public GameObject SpeakerSpawnLocation;
    public GameObject ThrusterSpawnLocation;

    private bool noRobotActive = true;

    private float lerpTime = 3;
    private float currentLerpTime = 0;

    public void SpawnBody(int armLength)
    {
        if(cloneToSpawn[0].activeInHierarchy)
        {
            Debug.Log("nope");
        }
        else
        {
            cloneToSpawn[0] = Instantiate(robotToSpawn[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        
    }

    public void SpawnEyes()
    {
        if (cloneToSpawn[0].activeInHierarchy)
        {
            cloneToSpawn[0].SetActive(false);
            cloneToSpawn[1] = Instantiate(robotToSpawn[1], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        else
        {
            
        }

    }

    public void SpawnSpeaker()
    {
        if (cloneToSpawn[1].activeInHierarchy)
        {
            cloneToSpawn[1].SetActive(false);
            cloneToSpawn[2] = Instantiate(robotToSpawn[2], spawnLocations[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        else
        {

        }

    }

    private void Update()
    {
        if (cloneToSpawn[0].activeInHierarchy)
        {
            if (BodySpawnLocation.GetComponent<BodySpawnLocation>().bodyInLocation == true)
            {
                currentLerpTime += Time.deltaTime;
                if(currentLerpTime >= lerpTime)
                {
                    currentLerpTime = lerpTime;
                }

                float percentage = currentLerpTime / lerpTime;
                cloneToSpawn[0].transform.position = Vector3.Lerp(BodySpawnLocation.transform.position, EyesSpawnLocation.transform.position, percentage); 
            }
            
        } 
        else if(cloneToSpawn[1].activeInHierarchy)
        {
            if (EyesSpawnLocation.GetComponent<BodySpawnLocation>().bodyInLocation == true)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime >= lerpTime)
                {
                    currentLerpTime = lerpTime;
                }

                float percentage = currentLerpTime / lerpTime;
                cloneToSpawn[1].transform.position = Vector3.Lerp(EyesSpawnLocation.transform.position, SpeakerSpawnLocation.transform.position, percentage);
            }
        }
        else if (cloneToSpawn[2].activeInHierarchy)
        {
            if (SpeakerSpawnLocation.GetComponent<BodySpawnLocation>().bodyInLocation == true)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime >= lerpTime)
                {
                    currentLerpTime = lerpTime;
                }

                float percentage = currentLerpTime / lerpTime;
                cloneToSpawn[2].transform.position = Vector3.Lerp(SpeakerSpawnLocation.transform.position, ThrusterSpawnLocation.transform.position, percentage);
            }
        }
    }

    public void ResetLerp()
    {
        currentLerpTime = 0;
        lerpTime = 3;
    }

}
