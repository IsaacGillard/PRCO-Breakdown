using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class USBLevel4 : MonoBehaviour
{

    [SerializeField]
    private GameObject USBCanvas;

    private int monitorReferenceNumber;

    [SerializeField]
    private GameObject PersonalityMonitor;

    [SerializeField]
    private GameObject PaintJobMonitor;

    [SerializeField]
    private GameObject NoRobotInCapsule;

    [SerializeField]
    private Transform Player;

    [SerializeField]
    private GameObject PlayerRaycast;

    private void OnEnable()
    {
        ResetScreen();
        Player.GetComponent<FirstPersonController>().enabled = false;
        monitorReferenceNumber = PlayerRaycast.GetComponent<Raycast>().monitorReference;
        Debug.Log(monitorReferenceNumber);

        // depending on monitor reference number form USBStats script, show the appropriate monitor

        if (monitorReferenceNumber == 1)
        {
            PersonalityMonitor.SetActive(true);
        }
        else if (monitorReferenceNumber == 2)
        {
            PaintJobMonitor.SetActive(true);
        }
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResetScreen()
    {
        // reset the screen
        PersonalityMonitor.SetActive(false);
        PaintJobMonitor.SetActive(false);
        NoRobotInCapsule.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        NoRobotInCapsule.SetActive(false);
        Cursor.visible = false;
        Player.GetComponent<FirstPersonController>().enabled = true;
        USBCanvas.SetActive(false);
    }
}
