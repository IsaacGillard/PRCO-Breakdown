using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreePower : MonoBehaviour {

    private int terminalsWithPower = 1;

    public GameObject terminalTwo;
    public GameObject terminalThree;
    public GameObject terminalFour;

    public Material[] powerLights;
    public GameObject terminalTwoLight;

    public Material[] monitorScreens;
    public GameObject terminalTwoScreen;
    public GameObject terminalThreeScreen;
    public GameObject terminalFourScreen;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(terminalTwo.activeInHierarchy)
        {
            terminalsWithPower += 1;
            TerminalPowerOn();
            MonitorScreenOn(terminalTwoScreen);
            terminalTwoScreen.tag = "USB";
        }
        if (terminalThree.activeInHierarchy)
        {
            terminalsWithPower += 1;
            MonitorScreenOn(terminalThreeScreen);
            terminalThreeScreen.tag = "USB";
        }
        if (terminalFour.activeInHierarchy)
        {
            terminalsWithPower += 1;
            MonitorScreenOn(terminalFourScreen);
            terminalFourScreen.tag = "USB";
        }
        if (terminalsWithPower == 4)
        {

        }

    }

    private void TerminalPowerOn()
    {
        terminalTwoLight.GetComponent<Renderer>().material = powerLights[1];
    }

    private void MonitorScreenOn(GameObject target)
    {
        target.GetComponent<Renderer>().material = monitorScreens[2];
    }
}
