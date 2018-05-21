using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Raycast : MonoBehaviour {

    public GameObject raycastedObj;

    public Transform Player;
    public Transform PlayerRaycast;

    public GameObject eventManager;

    public GameObject AudioManager;

    public GameObject[] equipmentHints;

    public GameObject UserInterface;

    public GameObject ScrewScreenCamera;

    public GameObject ScrewScreen;
    public GameObject WiresScreen;
    public GameObject CrowbarScreen;
    public GameObject PowerScreen;
    public GameObject EngineerUSBScreen;

    public GameObject Trigger;

    public GameObject screwdriver;
    public GameObject crowbar;
    public GameObject wires;
    public GameObject engineerUSB;
    public GameObject robotController;

    [SerializeField]
    private int rayLength = 1;

    [SerializeField]
    private LayerMask LayerMaskInteract;

    [SerializeField]
    private Image uiCrosshair;

    public int brokenWire;

    public int monitorReference;

    private void Start()
    {
        RemoveHints();
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, LayerMaskInteract.value))
        {
            //If the raycast detects an object with the Screw tag
            if(hit.collider.CompareTag("Screw"))
            {
                // set the equipment hint to the screwdriver hint
                equipmentHints[0].SetActive(true);
                // change the colour of the crosshair
                CrosshairActive();
                // If the player has the screwdriver currently equipped
                if (screwdriver.activeInHierarchy)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        // Disable the User Interface and activate the Screwdriver Minigame UI
                        UserInterface.SetActive(false);
                        raycastedObj = hit.collider.gameObject;
                        ScrewScreen.SetActive(true);
                    }
                }                                         
            }
            else if (hit.collider.CompareTag("Crowbar"))
            {
                // identical to above
                equipmentHints[1].SetActive(true);              
                CrosshairActive();

                if (crowbar.activeInHierarchy)
                {
                    raycastedObj = hit.collider.gameObject;
                    if (Input.GetKeyDown("e"))
                    {
                        UserInterface.SetActive(false);
                        CrowbarScreen.SetActive(true);
                    }
                }

                
            }
            else if (hit.collider.CompareTag("Wires"))
            {
                // identical to above
                equipmentHints[2].SetActive(true);
                
                CrosshairActive();

                if (wires.activeInHierarchy)
                {
                    raycastedObj = hit.collider.gameObject;
                    if (Input.GetKeyDown("e"))
                    {
                        UserInterface.SetActive(false);
                        brokenWire = raycastedObj.GetComponent<WireStats>().BrokenWire;
                        WiresScreen.SetActive(true);

                    }
                }   
            }
            else if (hit.collider.CompareTag("USB"))
            {
                // identical to above
                equipmentHints[4].SetActive(true);

                CrosshairActive();

                if (engineerUSB.activeInHierarchy)
                {
                    raycastedObj = hit.collider.gameObject;
                    if (Input.GetKeyDown("e"))
                    {
                        AudioManager.GetComponent<AudioManager>().Play("Monitor");
                        UserInterface.SetActive(false);
                        monitorReference = raycastedObj.GetComponent<USBStats>().MonitorReferenceNumber;
                        Debug.Log(monitorReference);
                        EngineerUSBScreen.SetActive(true);

                    }
                }
            }

            else if (hit.collider.CompareTag("RobotControl"))
            {
                // depending on equipment active, ask for hint or activate robot controller
                if (robotController.activeInHierarchy)
                {
                    equipmentHints[3].SetActive(false);
                    equipmentHints[5].SetActive(true);
                    raycastedObj = hit.collider.gameObject;
                    CrosshairActive();

                    if (Input.GetKeyDown("e"))
                    {
                        equipmentHints[5].SetActive(false);
                        eventManager.GetComponent<PlayerSwap>().SwapPlayer();
                    }
                }
                else
                {
                    equipmentHints[3].SetActive(true);
                    equipmentHints[5].SetActive(false);
                    raycastedObj = hit.collider.gameObject;
                    CrosshairActive();

                    if (Input.GetKeyDown("e"))
                    {
                        raycastedObj.GetComponent<SupervisorHints>().GiveHint();
                    }
                    
                }
            }

            else if (hit.collider.CompareTag("Monitor"))
            {
                // identical to above
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();

                if (Input.GetKeyDown("e"))
                {
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    PowerScreen.SetActive(true);
                }
            }
        }         
        else
        {
            UserInterface.SetActive(true);
            RemoveHints();
            CrosshairNormal();
        }
    }

    void RemoveHints()
    {
        foreach (GameObject i in equipmentHints)
        {
            i.SetActive(false);
        }
    }

    void CrosshairActive()
    {
        uiCrosshair.color = Color.green;
    }

     void CrosshairNormal()
    {
        uiCrosshair.color = Color.cyan;
    }

    public void CrowbarCompletion()
    {
        raycastedObj.GetComponent<CrowbarMiniGameCompletion>().Completion();
    }

    public void WiresSwitch()
    {
        raycastedObj.GetComponent<WiresCompletion>().Completion();
    }

    public void RemoveObject()
    {
        raycastedObj.SetActive(false);
    }

    
}
