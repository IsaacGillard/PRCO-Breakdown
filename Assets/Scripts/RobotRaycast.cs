using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class RobotRaycast : MonoBehaviour {

    public GameObject raycastedObj;

    public Transform Robot;

    public GameObject eventManager;

    public bool isCarrying = false;

    [SerializeField]
    private int rayLength = 1;

    [SerializeField]
    private LayerMask LayerMaskInteract;

    [SerializeField]
    private Image uiCrosshair;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, LayerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Robot"))
            {
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();

                if (Input.GetKeyDown("e"))
                {
                    if (isCarrying == false)
                    {
                        isCarrying = true;
                        raycastedObj.GetComponent<RobotPickup>().Pickup();
                    }
                    else if (isCarrying == true)
                    {
                        isCarrying = false;
                        raycastedObj.GetComponent<RobotPickup>().Drop();
                    }
                    
                }
            }
        }
        else
        {
            CrosshairNormal();
        }

        if (Input.GetKeyDown("r"))
        {
            eventManager.GetComponent<PlayerSwap>().SwapPlayer();
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
}
