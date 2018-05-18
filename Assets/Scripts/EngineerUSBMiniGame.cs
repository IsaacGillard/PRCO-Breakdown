using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class EngineerUSBMiniGame : MonoBehaviour {

    [SerializeField]
    private GameObject USBCanvas;

    private int monitorReferenceNumber;

    [SerializeField]
    private GameObject RobotBodyMonitor;

    [SerializeField]
    private GameObject RobotEyesMonitor;

    [SerializeField]
    private GameObject RobotSpeakerMonitor;

    [SerializeField]
    private GameObject RobotThrusterMonitor;

    [SerializeField]
    private GameObject NoRobotInCapsule;

    [SerializeField]
    private GameObject TestingMonitor;

    [SerializeField]
    private GameObject RestartProcess;

    [SerializeField]
    private Transform Player;

    [SerializeField]
    private GameObject PlayerRaycast;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        ResetScreen();
        Player.GetComponent<FirstPersonController>().enabled = false;
        monitorReferenceNumber = PlayerRaycast.GetComponent<Raycast>().monitorReference;
        Debug.Log(monitorReferenceNumber);

        if (monitorReferenceNumber == 1)
        {
            RobotBodyMonitor.SetActive(true);
        }
        else if (monitorReferenceNumber == 2)
        {
            RobotEyesMonitor.SetActive(true);
        }
        else if (monitorReferenceNumber == 3)
        {
            RobotSpeakerMonitor.SetActive(true);
        }
        else if (monitorReferenceNumber == 4)
        {
            RobotThrusterMonitor.SetActive(true);
        }
        else if (monitorReferenceNumber == 5)
        {
            TestingMonitor.SetActive(true);
        }
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResetScreen()
    {
        RobotBodyMonitor.SetActive(false);
        RobotEyesMonitor.SetActive(false);
        RobotSpeakerMonitor.SetActive(false);
        RobotThrusterMonitor.SetActive(false);
        TestingMonitor.SetActive(false);
        NoRobotInCapsule.SetActive(false);
        RestartProcess.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        NoRobotInCapsule.SetActive(false);
        RestartProcess.SetActive(false);
        Cursor.visible = false;
        Player.GetComponent<FirstPersonController>().enabled = true;
        USBCanvas.SetActive(false);
    }
}
