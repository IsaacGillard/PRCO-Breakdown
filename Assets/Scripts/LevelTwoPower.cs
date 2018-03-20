using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoPower : MonoBehaviour {

    [SerializeField]
    private GameObject MainPower;

    [SerializeField]
    private GameObject MonitorScreen;

    public GameObject ColumnOne;
    public GameObject ColumnTwo;
    public GameObject ColumnThree;

    // Use this for initialization
    void Start () {

        if(ColumnOne.activeInHierarchy && ColumnTwo.activeInHierarchy && ColumnThree.activeInHierarchy)
        {
            MainPower.SetActive(true);
            MonitorScreen.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
