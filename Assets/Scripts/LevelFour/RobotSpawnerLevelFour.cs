using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawnerLevelFour : MonoBehaviour {

    [SerializeField]
    private Transform[] spawnLocations;
    [SerializeField]
    private GameObject[] robotToSpawn;
    [SerializeField]
    private GameObject[] cloneToSpawn;
    [SerializeField]
    private GameObject PersonalitySpawnA;
    [SerializeField]
    private GameObject PersonalitySpawnB;
    [SerializeField]
    private GameObject PaintJobSpawnA;
    [SerializeField]
    private GameObject PaintJobSpawnB;

    [SerializeField]
    private GameObject AudioManager;

    public GameObject CompletedRobot;

    public string[] RobotTraits;

    private bool noRobotActive = true;

    private float lerpTime = 3;
    private float currentLerpTime = 0;

    public void SpawnPersonality()
    {
        // detect is a robot is in the heirarchy, and spawn the robot depending on the players progression throught the level
        if(cloneToSpawn[0])
        {
            if (cloneToSpawn[0].activeInHierarchy)
            {
                Debug.Log("nope");
            }
            else
            {
                cloneToSpawn[0] = Instantiate(robotToSpawn[0], spawnLocations[0].transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
                noRobotActive = false;
                
            }

        }
        else
        {
            cloneToSpawn[0] = Instantiate(robotToSpawn[0], spawnLocations[0].transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
            noRobotActive = false;
        }



    }

    public void SpawnPaintJob()
    {
        // spawn the fist robot in array
        if (cloneToSpawn[0].activeInHierarchy)
        {
            cloneToSpawn[0].SetActive(false);
            cloneToSpawn[1] = Instantiate(robotToSpawn[1], spawnLocations[1].transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
            AudioManager.GetComponent<AudioManager>().Play("Drill");
        }
        else
        {

        }

    }

    public void SpawnCompletedRobot(int PaintJob)
    {
        // spawn the second robot in array
        if (cloneToSpawn[1].activeInHierarchy)
        {
            cloneToSpawn[1].SetActive(false);
            cloneToSpawn[2] = Instantiate(robotToSpawn[2], spawnLocations[2].transform.position, Quaternion.Euler(-90, 180, 0)) as GameObject;
            AudioManager.GetComponent<AudioManager>().Play("SprayPaint");
        }
        else
        {

        }

    }

    private void Start()
    {
        //SpawnPersonality();
    }

    // Update is called once per frame
    void Update () {

        if(cloneToSpawn[0])
        {
            if (noRobotActive == false)
            {
                if (cloneToSpawn[0].activeInHierarchy)
                {
                    // check if the robot is currently in the correct location, and then move the robot to the next location 
                    if (PersonalitySpawnA.GetComponent<LevelFourSpawner>().bodyInLocation == true)
                    {
                        currentLerpTime += Time.deltaTime;
                        if (currentLerpTime >= lerpTime)
                        {
                            currentLerpTime = lerpTime;
                        }

                        float percentage = currentLerpTime / lerpTime;
                        cloneToSpawn[0].transform.position = Vector3.Lerp(PersonalitySpawnA.transform.position, PersonalitySpawnB.transform.position, percentage);
                    }


                }
                else if (cloneToSpawn[1].activeInHierarchy)
                {
                    // check if the robot is currently in the correct location, and then move the robot to the next location 
                    if (PaintJobSpawnA.GetComponent<LevelFourSpawner>().bodyInLocation == true)
                    {

                        currentLerpTime += Time.deltaTime;
                        if (currentLerpTime >= lerpTime)
                        {
                            currentLerpTime = lerpTime;
                        }

                        float percentage = currentLerpTime / lerpTime;
                        cloneToSpawn[1].transform.position = Vector3.Lerp(PaintJobSpawnA.transform.position, PaintJobSpawnB.transform.position, percentage);
                    }
                }
                else if (cloneToSpawn[2].activeInHierarchy)
                {
                    // spawn the completed robot
                    CompletedRobot = cloneToSpawn[2];
                    Debug.Log("activated");
                    CompletedRobot.GetComponent<Paintedrobot>().RobotStats = RobotTraits;
                    CompletedRobot.GetComponent<Paintedrobot>().PaintRobot();
                    CompletedRobot.GetComponent<Paintedrobot>().ShowValues();
                }
            }
            else
            {

            }
        }

        if(noRobotActive == true)
        {
            // if no robot is in the heirarchy, spawn another at the start location
            Debug.Log("Spawning");
            SpawnPersonality();
        }

    }

    public void DestroyRobot()
    {
        // destroy all robots in array, prompting another to spawn at the start
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
