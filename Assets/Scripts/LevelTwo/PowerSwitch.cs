using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    [SerializeField]
    private GameObject GameOverScreen;

    [SerializeField]
    private GameObject DeathMessage;

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
        // if all power columns are activated, activate main column, else fail level

        if (ColumnOne.activeInHierarchy && ColumnTwo.activeInHierarchy && ColumnThree.activeInHierarchy)
        {
            MainPower.SetActive(true);
            MonitorScreen.SetActive(true);
        }
        else
        {
            GameOverScreen.SetActive(true);
            DeathMessage.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
