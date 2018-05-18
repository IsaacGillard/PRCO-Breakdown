using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ScrewMiniGame : MonoBehaviour {

    public Transform Player;
    public Transform PlayerRaycast;
    public Slider slider;
    public Slider timer;
    private float progress = 0;
    private float timerProgress = 5;
    public GameObject ScrewScreen;
    private int alternator = 0;
    public GameObject UserInterface;

    public GameObject EventSystem;
    public GameObject AudioManager;

    // Use this for initialization
    void OnEnable ()
    {
        ResetSlider();
        ResetTimer();
        
	}
	
	// Update is called once per frame
	void Update () {

        Player.GetComponent<FirstPersonController>().enabled = false;

        if (timerProgress >= 0.1)
        {
            timerProgress -= Time.deltaTime;
            timer.value = timerProgress;
        }
        else
        {
            ScrewMiniGameFailed();
        }

        if (Input.GetKeyDown("f"))
        {
            if (alternator == 0)
            {
                alternator = 1;
                progress += 0.1f;
                slider.value = progress;
                Debug.Log(progress);
                AudioManager.GetComponent<AudioManager>().Play("Screwdriver");
            }
            else if (alternator == 1)
            {
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
                AudioManager.GetComponent<AudioManager>().Play("Screwdriver");
            }
            else if (alternator == 0)
            {
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
        alternator = 0;
        progress = 0f;
        slider.value = 0;

        Debug.Log(slider.value);
    }

    public void ResetTimer()
    {
        timer.value = 5;
        timerProgress = 5;
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
        EventSystem.GetComponent<SupervisorOpinion>().ReduceOpinion(2);


    }

}



