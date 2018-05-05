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
    private Transform Player;

    [SerializeField]
    private GameObject PlayerRaycast;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        RobotBodyMonitor.SetActive(false);
        RobotEyesMonitor.SetActive(false);
        RobotSpeakerMonitor.SetActive(false);
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
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        RobotEyesMonitor.GetComponent<RobotEyesMonitor>().NoRobotInCapsule.SetActive(false);
        RobotSpeakerMonitor.GetComponent<RobotSpeakerMonitor>().NoRobotInCapsule.SetActive(false);
        Cursor.visible = false;
        Player.GetComponent<FirstPersonController>().enabled = true;
        USBCanvas.SetActive(false);
    }
}
