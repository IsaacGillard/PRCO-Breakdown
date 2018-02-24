using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ScrewMiniGame : MonoBehaviour {

    public Transform Player;

    public GameObject ScrewScreen;
    public Slider slider;
    private float progress = 0;
    
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("f"))
        {
            Debug.Log("Triggered");
                
            progress += 0.1f;
            slider.value = progress;

            Debug.Log(progress);
        }
        if (progress >= 1.0f)
        {
            Debug.Log("Completed");
            Player.GetComponent<Raycast>().ScrewMiniGameCompleted();

        }
        if(Input.GetKeyDown("e"))
        {
            ScrewScreen.SetActive(false);
        }

    }
}
