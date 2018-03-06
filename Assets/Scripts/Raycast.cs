using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Raycast : MonoBehaviour {

    public GameObject raycastedObj;

    public Transform Player;

    public GameObject ScrewScreen;
    public GameObject WiresScreen;
    public GameObject CrowbarScreen;

    public GameObject screwdriver;
    public GameObject crowbar;
    public GameObject wires;
    public GameObject ductTape;

    [SerializeField]
    private int rayLength = 1;

    [SerializeField]
    private LayerMask LayerMaskInteract;

    [SerializeField]
    private Image uiCrosshair;

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
                raycastedObj.GetComponent<RaycastMaterialChange>().OnHoverOver(raycastedObj);

                if (Input.GetKeyDown("e"))
                {
                    
                    ScrewScreen.SetActive(true);
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    raycastedObj.GetComponent<RaycastMaterialChange>().ResetMaterial(raycastedObj);

                }
            }
            else if (hit.collider.CompareTag("Wires") && wires.activeInHierarchy )
            {
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();
                raycastedObj.GetComponent<RaycastMaterialChange>().OnHoverOver(raycastedObj);

                

                if (Input.GetKeyDown("e"))
                {
                    raycastedObj.GetComponent<RaycastMaterialChange>().ResetMaterial(raycastedObj);
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
                    //raycastedObj.GetComponent<RaycastMaterialChange>().ResetMaterial(raycastedObj);
                    CrowbarScreen.SetActive(true);
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    

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



    public void ScrewMiniGameCompleted()
    {
        ScrewScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        raycastedObj.SetActive(false);
    }

    public void ScrewMiniGameFailed()
    {
        ScrewScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void WiresMiniGameCompleted()
    {
        WiresScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        raycastedObj.SetActive(false);
    }

    public void WiresMiniGameFailed()
    {
        SceneManager.LoadScene(0);
    }

    public void CrowbarMiniGameCompleted()
    {
        CrowbarScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        raycastedObj.SetActive(false);
    }
    public void CrowbarMiniGameFailed()
    {
        CrowbarScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        
    }
}
