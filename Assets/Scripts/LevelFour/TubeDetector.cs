using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDetector : MonoBehaviour {

    public GameObject EventSystem;

    [SerializeField]
    private GameObject AudioManager;

    public bool bodyInLocation = false;

    public bool tubeCompleted = false;

    [SerializeField]
    private string personality;

    [SerializeField]
    private string paintJob;

    [SerializeField]
    private GameObject Supervisor;

    [SerializeField]
    private GameObject Monitor;


    private Collider Robot;

    private void OnEnable()
    {
        Monitor.GetComponent<TubeMonitor>().ChangeScreen(1);
    }

    private void Update()
    {
        if(Robot)
        {
            if (bodyInLocation == true)
            {
                // if a robot is dropped within the collider, detect its personality and paint job, and either accept it and complete tube, or reject it and destroy robot
                if (Robot.GetComponent<RobotPickup>().isDropped == true)
                {
                    Debug.Log("dropped");
                    if (Robot.GetComponent<Paintedrobot>().RobotStats[0] == personality)
                    {
                        Debug.Log("correct personality");
                        if (Robot.GetComponent<Paintedrobot>().RobotStats[1] == paintJob)
                        {
                            Debug.Log("correct paintJob");
                            AudioManager.GetComponent<AudioManager>().Play("Correct");
                            tubeCompleted = true;
                            Monitor.GetComponent<TubeMonitor>().ChangeScreen(3);
                            EventSystem.GetComponent<LevelFourPower>().CheckAllTubes();
                            EventSystem.GetComponent<RobotSpawnerLevelFour>().DestroyRobot();
                        }
                        else
                        {
                            Debug.Log("correct personality, incorrect paintjob");
                            AudioManager.GetComponent<AudioManager>().Play("Incorrect");
                            Monitor.GetComponent<TubeMonitor>().ChangeScreen(2);
                            EventSystem.GetComponent<RobotSpawnerLevelFour>().DestroyRobot();
                        }
                    }
                    else
                    {
                        Debug.Log("incorrect personality");
                        AudioManager.GetComponent<AudioManager>().Play("Incorrect");
                        Monitor.GetComponent<TubeMonitor>().ChangeScreen(2);
                        EventSystem.GetComponent<RobotSpawnerLevelFour>().DestroyRobot();
                    }
                }
                else
                {
                    Debug.Log("not dropped");
                }
            }
        }
        else
        {

        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Robot")
        {
            bodyInLocation = true;
            Robot = other;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Robot")
        {
            bodyInLocation = false;
        }
    }
}
