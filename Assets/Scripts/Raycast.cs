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
            if(hit.collider.CompareTag("Screw"))
            {
                equipmentHints[0].SetActive(true);
                CrosshairActive();
                if (screwdriver.activeInHierarchy)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        
                        UserInterface.SetActive(false);
                        raycastedObj = hit.collider.gameObject;
                        ScrewScreen.SetActive(true);
                    }
                }
                
                
                //raycastedObj.GetComponent<RaycastMaterialChange>().OnHoverOver(raycastedObj);

                
            }
            else if (hit.collider.CompareTag("Crowbar"))
            {
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
                equipmentHints[2].SetActive(true);

                CrosshairActive();

                if (engineerUSB.activeInHierarchy)
                {
                    raycastedObj = hit.collider.gameObject;
                    if (Input.GetKeyDown("e"))
                    {
                        UserInterface.SetActive(false);
                        monitorReference = raycastedObj.GetComponent<USBStats>().MonitorReferenceNumber;
                        Debug.Log(monitorReference);
                        EngineerUSBScreen.SetActive(true);

                    }
                }
            }

            else if (hit.collider.CompareTag("RobotControl"))
            {
                if (robotController.activeInHierarchy)
                {
                    raycastedObj = hit.collider.gameObject;
                    CrosshairActive();

                    if (Input.GetKeyDown("e"))
                    {
                        eventManager.GetComponent<PlayerSwap>().SwapPlayer();
                    }
                }
                else
                {
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
