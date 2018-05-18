using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject MainPower;

    [SerializeField]
    private GameObject MonitorScreen;

    public GameObject ColumnOne;
    public GameObject ColumnTwo;
    public GameObject ColumnThree;

    // Use this for initialization
    void Start()
    {

        if (ColumnOne.activeInHierarchy && ColumnTwo.activeInHierarchy && ColumnThree.activeInHierarchy)
        {
            MainPower.SetActive(true);
            MonitorScreen.SetActive(true);
        }
        else
        {
            
        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
