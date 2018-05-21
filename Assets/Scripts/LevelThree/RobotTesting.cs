using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobotTesting : MonoBehaviour {

    private GameObject Robot;

    private int StagesPassed = 0;

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject AudioManager;

    [SerializeField]
    private GameObject Trigger;

    [SerializeField]
    private GameObject StartScreen;

    [SerializeField]
    private GameObject NoRobotInCapsule;

    [SerializeField]
    private GameObject TestingScreen;

    [SerializeField]
    private TextMeshProUGUI EyeValue;

    [SerializeField]
    private TextMeshProUGUI VoiceValue;

    [SerializeField]
    private TextMeshProUGUI ThrusterValue;

    [SerializeField]
    private GameObject SuccessButton;

    [SerializeField]
    private GameObject FailureButton;

    private int EyeResult;
    private int VoiceResult;
    private int ThrusterResult;

    //[SerializeField]
   // private Animation ThrusterAnimation;

    //[SerializeField]
    //private AnimationClip[] ThrusterAnimations;



    // Use this for initialization
    private void OnEnable()
    {
        TestingScreen.SetActive(false);
        StagesPassed = 0;
        SuccessButton.SetActive(false);
        FailureButton.SetActive(false);

        if (Trigger.GetComponent<BodySpawnLocation>().bodyInLocation == true)
        {
            Robot = EventSystem.GetComponent<RobotSpawner>().CompletedRobot;
            StartScreen.SetActive(true);
            NoRobotInCapsule.SetActive(false);

            
        }
        else
        {
            StartScreen.SetActive(false);
            NoRobotInCapsule.SetActive(true);
        }
        
    }

    public void TestRobot()
    {
        // test the robot, checking if all modifications are correct
        TestingScreen.SetActive(true);
        StartScreen.SetActive(false);
        EyeTest();
        VoiceTest();
        ThrusterTest();

        if (StagesPassed == 3)
        {
            SuccessButton.SetActive(true);
            AudioManager.GetComponent<AudioManager>().Play("Correct");
        }
        else
        {
            FailureButton.SetActive(true);
            AudioManager.GetComponent<AudioManager>().Play("Incorrect");
            EventSystem.GetComponent<SupervisorOpinion>().ReduceOpinion(2);
        }
    }

    void EyeTest()
    {
        EyeResult = Robot.GetComponent<CompletedRobot>().robotStatistics[0];

        if (EyeResult == 60)
        {
            EyeValue.text = "Pass";
            StagesPassed += 1;
        }
        else
        {
            EyeValue.text = "Fail";
        }
    }

    void VoiceTest()
    {
        VoiceResult = Robot.GetComponent<CompletedRobot>().robotStatistics[1];

        if (VoiceResult == 2)
        {
            VoiceValue.text = "Pass";
            StagesPassed += 1;
        }
        else
        {
            VoiceValue.text = "Fail";
        }
    }

    void ThrusterTest()
    {
        ThrusterResult = Robot.GetComponent<CompletedRobot>().robotStatistics[2];

        //AnimationClip ThrusterAnim;

        //foreach (AnimationClip clip in ThrusterAnimations)
        //{
        //    ThrusterAnimation.AddClip(clip, clip.name);
        //}

        if (ThrusterResult == 30)
        {
            
            //ThrusterAnimation.Play(ThrusterAnimations[0].name);

            
            ThrusterValue.text = "Fail";
            
        }

        else if (ThrusterResult == 50)
        {
           // ThrusterAnimation.Play(ThrusterAnimations[1].name);
            ThrusterValue.text = "Pass";
            StagesPassed += 1;
        }
        else if (ThrusterResult == 70)
        {
            //ThrusterAnimation.Play(ThrusterAnimations[2].name);
            ThrusterValue.text = "Fail";
        }
    }

    public void RestartProcess()
    {
        EventSystem.GetComponent<RobotSpawner>().DestroyRobot();
    }


}
