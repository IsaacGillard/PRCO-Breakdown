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

    public GameObject CompletedRobot;

    public string[] RobotTraits;

    private bool noRobotActive = true;

    private float lerpTime = 3;
    private float currentLerpTime = 0;

    public void SpawnPersonality()
    {
        if (cloneToSpawn[0].activeInHierarchy)
        {
            Debug.Log("nope");
        }
        else
        {
            cloneToSpawn[0] = Instantiate(robotToSpawn[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }

    }

    public void SpawnPaintJob()
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

    public void SpawnCompletedRobot()
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

    private void Start()
    {
        SpawnPersonality();
    }

    // Update is called once per frame
    void Update () {

        if (cloneToSpawn[0].activeInHierarchy)
        {
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
            CompletedRobot = cloneToSpawn[2];
            Debug.Log("activated");
            CompletedRobot.GetComponent<Paintedrobot>().RobotStats = RobotTraits;
            CompletedRobot.GetComponent<Paintedrobot>().PaintRobot();
            CompletedRobot.GetComponent<Paintedrobot>().ShowValues();
        }

    }

    public void ResetLerp()
    {
        currentLerpTime = 0;
        lerpTime = 3;
    }
}
