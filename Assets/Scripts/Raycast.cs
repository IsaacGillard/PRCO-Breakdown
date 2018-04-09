using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Raycast : MonoBehaviour {

    public GameObject raycastedObj;

    public Transform Player;

    public GameObject eventManager;

    public GameObject ScrewScreen;
    public GameObject WiresScreen;
    public GameObject CrowbarScreen;
    public GameObject PowerScreen;

    public GameObject Trigger;

    public GameObject screwdriver;
    public GameObject crowbar;
    public GameObject wires;
    public GameObject ductTape;
    public GameObject robotController;

    [SerializeField]
    private int rayLength = 1;

    [SerializeField]
    private LayerMask LayerMaskInteract;

    [SerializeField]
    private Image uiCrosshair;

    public int brokenWire;

    private void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, LayerMaskInteract.value))
        {
            if(hit.collider.CompareTag("Screw") && screwdriver.activeInHierarchy)
            {  
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();
                //raycastedObj.GetComponent<RaycastMaterialChange>().OnHoverOver(raycastedObj);

                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("triggered");
                    ScrewScreen.SetActive(true);
                    ScrewScreen.GetComponent<test>().ResetSlider();
                    Debug.Log("finished loop");
                }
            }
            else if (hit.collider.CompareTag("Wires") && wires.activeInHierarchy )
            {
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();
                //raycastedObj.GetComponent<RaycastMaterialChange>().OnHoverOver(raycastedObj);

                if (Input.GetKeyDown("e"))
                {
                    brokenWire = raycastedObj.GetComponent<WireStats>().BrokenWire;
                    //raycastedObj.GetComponent<RaycastMaterialChange>().ResetMaterial(raycastedObj);
                    WiresScreen.SetActive(true);
                    Player.GetComponent<FirstPersonController>().enabled = false;

                }
            }
            else if (hit.collider.CompareTag("Crowbar") && crowbar.activeInHierarchy)
            {
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();
                //raycastedObj.GetComponent<RaycastMaterialChange>().OnHoverOver(raycastedObj);

                if (Input.GetKeyDown("e"))
                {
                    raycastedObj.GetComponent<CrowbarMiniGame>().ResetSlider();
                    //raycastedObj.GetComponent<RaycastMaterialChange>().ResetMaterial(raycastedObj);
                    CrowbarScreen.SetActive(true);
                    CrowbarScreen.GetComponent<CrowbarTimer>().StartTimer();
                    Player.GetComponent<FirstPersonController>().enabled = false;
                }
            }
            else if (hit.collider.CompareTag("RobotControl") && robotController.activeInHierarchy)
            {
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();
                //raycastedObj.GetComponent<RaycastMaterialChange>().OnHoverOver(raycastedObj);

                if (Input.GetKeyDown("e"))
                {
                    eventManager.GetComponent<PlayerSwap>().SwapPlayer();
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
            CrosshairNormal();
            //raycastedObj.GetComponent<RaycastMaterialChange>().ResetMaterial(raycastedObj);
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
