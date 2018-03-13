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
        ResetSlider();
	}
	
	// Update is called once per frame
	void Update () {

        if (ScrewScreen.activeInHierarchy)
        {
            slider.value = progress;

            if (Input.GetKeyDown("f"))
            {
                progress += 0.1f;
                slider.value = progress;               
            }
            if (progress > 0)
            {
                progress -= Time.deltaTime / 3;
                if (progress <= 0.01f)
                {
                    ResetSlider();
                    Player.GetComponent<Raycast>().ScrewMiniGameFailed();
                }
            }
            if (progress >= 1.0f)
            {
                Debug.Log("Completed");
                ResetSlider();
                Player.GetComponent<Raycast>().ScrewMiniGameCompleted();

            }
            if (Input.GetKeyDown("e"))
            {
                ResetSlider();
                Player.GetComponent<Raycast>().ScrewMiniGameFailed();
            }
        }
        else
        {

        }
    }

    void ResetSlider()
    {
        progress = 0f;
        slider.value = 0;
    }

}
