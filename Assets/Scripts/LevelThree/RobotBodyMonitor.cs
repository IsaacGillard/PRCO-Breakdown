using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobotBodyMonitor : MonoBehaviour {

    [SerializeField]
    private int[] ArmLength;

    private int currentArmLength = 0;

    public int CommitedArmLength;

    public TextMeshProUGUI armLengthValue;

	// Use this for initialization
	void Start () {
		
	}


    // Update is called once per frame
    void Update () {

        armLengthValue.text = ArmLength[currentArmLength].ToString() + "cm";
		
	}

    public void IncreaseArmLength()
    {
        if(currentArmLength < 2)
        {
            currentArmLength++;
        }
        else
        {
            currentArmLength = 0;
        }        
    }

    public void DecreaseArmLength()
    {
        if (currentArmLength > 0)
        {
            currentArmLength--;
        }
        else
        {
            currentArmLength = 2;
        }
    }
}
