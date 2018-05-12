using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTimer : MonoBehaviour {

    private bool IsOpen = false;

    private float timerProgress = 10;

    [SerializeField]
    private GameObject HatchDoor;

    [SerializeField]
    private GameObject LeverUp;

    [SerializeField]
    private GameObject LeverDown;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (IsOpen == true)
        {
            if (timerProgress >= 0.1)
            {
                timerProgress -= Time.deltaTime;
                
            }
            else
            {
                Close();
            }
        }
		
	}

    public void Open()
    {
        IsOpen = true;
        HatchDoor.SetActive(false);
        LeverUp.SetActive(false);
        LeverDown.SetActive(true);

    }

    public void Close()
    {
        IsOpen = false;
        timerProgress = 10;
        HatchDoor.SetActive(true);
        LeverUp.SetActive(true);
        LeverDown.SetActive(false);
    }
}
