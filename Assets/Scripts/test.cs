using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class test : MonoBehaviour {

    public Transform Player;
    public Transform PlayerRaycast;
    public Slider slider;
    private float progress = 0;
    public GameObject ScrewScreen;
    private int alternator = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Player.GetComponent<FirstPersonController>().enabled = false;

        if (Input.GetKeyDown("f"))
        {
            if (alternator == 0)
            {
                alternator = 1;
                progress += 0.1f;
                slider.value = progress;
                Debug.Log(progress);
            }
            else if (alternator == 1)
            {
                ScrewMiniGameFailed();
                ResetSlider();
            }
        }

        if (Input.GetKeyDown("h"))
        {
            if (alternator == 1)
            {
                alternator = 0;
                progress += 0.1f;
                slider.value = progress;
                Debug.Log(progress);
            }
            else if (alternator == 0)
            {
                ScrewMiniGameFailed();
                ResetSlider();
            }
        }
        if (progress >= 3)
        {
            ScrewMiniGameCompleted();
            ResetSlider();
        }
        if (Input.GetKeyDown("r"))
        {
            ResetSlider();
            ScrewMiniGameFailed();
        }
    }
    public void ResetSlider()
    {
        Debug.Log("slider reset");

        progress = 0f;
        slider.value = 0;
        Debug.Log(slider.value);
    }

    void ScrewMiniGameCompleted()
    {
        ScrewScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        PlayerRaycast.GetComponent<Raycast>().RemoveObject();

    }

    void ScrewMiniGameFailed()
    {
        ScrewScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;

    }

}



