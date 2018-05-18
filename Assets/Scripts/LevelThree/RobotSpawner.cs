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
    public GameObject CompletedRobotPositionA;
    public GameObject CompletedRobotPositionB;

    public GameObject CompletedRobot;

    public int[] completedRobotStatistics;

    private bool noRobotActive = true;

    private float lerpTime = 3;
    private float currentLerpTime = 0;

    public void SpawnBody()
    {
        if (cloneToSpawn[0])
        {
            if (cloneToSpawn[0].activeInHierarchy)
            {
                Debug.Log("nope");
            }
            else
            {
                cloneToSpawn[0] = Instantiate(robotToSpawn[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                noRobotActive = false;
            }

        }
        else
        {
            cloneToSpawn[0] = Instantiate(robotToSpawn[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            noRobotActive = false;
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

    public void SpawnThruster()
    {
        Debug.Log("spawned");
        if (cloneToSpawn[2].activeInHierarchy)
        {
            cloneToSpawn[2].SetActive(false);
            cloneToSpawn[3] = Instantiate(robotToSpawn[3], spawnLocations[3].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Debug.Log("pass");
        }
        else
        {
            
        }

    }

    private void Update()
    {
        if (cloneToSpawn[0])
        {
            if (noRobotActive == false)
            {
                if (cloneToSpawn[0].activeInHierarchy)
                {
                    if (BodySpawnLocation.GetComponent<BodySpawnLocation>().bodyInLocation == true)
                    {
                        currentLerpTime += Time.deltaTime;
                        if (currentLerpTime >= lerpTime)
                        {
                            currentLerpTime = lerpTime;
                        }

                        float percentage = currentLerpTime / lerpTime;
                        cloneToSpawn[0].transform.position = Vector3.Lerp(BodySpawnLocation.transform.position, EyesSpawnLocation.transform.position, percentage);
                    }

                }
                else if (cloneToSpawn[1].activeInHierarchy)
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
                else if (cloneToSpawn[3].activeInHierarchy)
                {
                    CompletedRobot = cloneToSpawn[3];
                    Debug.Log("activated");
                    CompletedRobot.GetComponent<CompletedRobot>().robotStatistics = completedRobotStatistics;

                    currentLerpTime += Time.deltaTime;
                    if (currentLerpTime >= lerpTime)
                    {
                        currentLerpTime = lerpTime;
                    }

                    float percentage = currentLerpTime / lerpTime;
                    cloneToSpawn[3].transform.position = Vector3.Lerp(CompletedRobotPositionA.transform.position, CompletedRobotPositionB.transform.position, percentage);
                    CompletedRobot.GetComponent<CompletedRobot>().ShowValues();


                }
            }
        }
    }

    public void DestroyRobot()
    {
        noRobotActive = true;
        for (int i = 0; i < cloneToSpawn.Length; i++)
        {
            Destroy(cloneToSpawn[i]);
            Debug.Log(noRobotActive);
            Debug.Log(i);
        }


    }

    public void ResetLerp()
    {
        currentLerpTime = 0;
        lerpTime = 3;
    }

}
