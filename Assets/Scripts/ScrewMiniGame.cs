using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ScrewMiniGame : MonoBehaviour {

    public Transform Player;

    public GameObject ScrewScreen;
    public GameObject Panel;
    public Slider slider;
    private float progress = 0;
    private int screwCount = 0;
    
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        slider.value = progress;

        if (Input.GetKeyDown("f"))
        {
            Debug.Log("Triggered");
                
            progress += 0.1f;
            slider.value = progress;

            Debug.Log(progress);
        }
        if(progress > 0)
        {
            progress -= Time.deltaTime/3;
            if(progress <= 0.01f)
            {
                progress = 0f;
                slider.value = 0;
                Player.GetComponent<Raycast>().ScrewMiniGameFailed();
            }
        }
        if (progress >= 1.0f)
        {
            Debug.Log("Completed");
            progress = 0f;
            slider.value = 0;
            screwCount++;
            Player.GetComponent<Raycast>().ScrewMiniGameCompleted();

        }
        if(Input.GetKeyDown("e"))
        {
            progress = 0f;
            slider.value = 0;
            Player.GetComponent<Raycast>().ScrewMiniGameFailed();
        }

        if (screwCount == 4)
        {
            Panel.SetActive(false);
        }

    }
}
