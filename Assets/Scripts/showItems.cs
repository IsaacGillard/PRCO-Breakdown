using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showItems : MonoBehaviour
{

    [SerializeField]
    private GameObject screwdriver;

    [SerializeField]
    private GameObject crowbar;

    [SerializeField]
    private GameObject wires;

    [SerializeField]
    private GameObject ductTape;

    [SerializeField]
    private GameObject robotController;

    public bool showScrewdriver;
    public bool showCrowbar;
    public bool showWires;
    public bool showDuctTape;
    public bool showController;

    public int activeItem = 1;

    // Use this for initialization
    void Start () {

        showScrewdriver = true;
        showCrowbar = false;
        showWires = false;
        showDuctTape = false;
        showController = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (showScrewdriver == true)
        {
            screwdriver.SetActive(true);
            activeItem = 1;
        }
        if (showScrewdriver == false)
        {
            screwdriver.SetActive(false);
        }
        if (showCrowbar == true)
        {
            crowbar.SetActive(true);
            activeItem = 2;
        }
        if (showCrowbar == false)
        {
            crowbar.SetActive(false);
        }
        if (showWires == true)
        {
            wires.SetActive(true);
            activeItem = 3;
        }
        if (showWires == false)
        {
            wires.SetActive(false);
        }
        if (showDuctTape == true)
        {
            ductTape.SetActive(true);
            activeItem = 4;
        }
        if (showDuctTape == false)
        {
            ductTape.SetActive(false);
        }
        if (showController == true)
        {
            robotController.SetActive(true);
            activeItem = 5;
        }
        if (showController == false)
        {
            robotController.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && showScrewdriver == false)
        {
            showScrewdriver = true;
            showCrowbar = false;
            showWires = false;
            showDuctTape = false;
            showController = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && showCrowbar == false)
        {
            showScrewdriver = false;
            showCrowbar = true;
            showWires = false;
            showDuctTape = false;
            showController = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && showWires == false)
        {
            showScrewdriver = false;
            showCrowbar = false;
            showWires = true;
            showDuctTape = false;
            showController = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && showDuctTape == false)
        {
            showScrewdriver = false;
            showCrowbar = false;
            showWires = false;
            showDuctTape = true;
            showController = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && showController == false)
        {
            showScrewdriver = false;
            showCrowbar = false;
            showWires = false;
            showDuctTape = false;
            showController = true;
        }

    }
}
