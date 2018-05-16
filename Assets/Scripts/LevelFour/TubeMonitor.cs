using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeMonitor : MonoBehaviour {

    [SerializeField]
    private GameObject MonitorScreen;

    [SerializeField]
    private Material[] Screens;

    private float timeLeft = 3;

    private bool timerActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(timerActive == true)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0.1)
            {
                MonitorScreen.GetComponent<Renderer>().material = Screens[1];
                timerActive = false;
            }
        }
		
	}

    public void ChangeScreen(int i)
    {
        timeLeft = 3;
        

        if(i == 2)
        {
            timerActive = true;
            MonitorScreen.GetComponent<Renderer>().material = Screens[i];
            
        }
        else
        {
            MonitorScreen.GetComponent<Renderer>().material = Screens[i];
        }
        
    }
}
