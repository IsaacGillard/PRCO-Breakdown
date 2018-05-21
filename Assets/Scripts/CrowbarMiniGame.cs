using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class CrowbarMiniGame : MonoBehaviour {

    public GameObject AudioManager;
    public GameObject EventSystem;
    public Transform Player;
    public GameObject PlayerRaycast;
    public Slider sliderOne;
    public Slider sliderTwo;
    public Slider sliderThree;
    public Slider timer;
    private float timerProgress = 5;
    private float progress = 0;
    public GameObject CrowbarScreen;
    public GameObject UserInterface;

    private bool isPlayingAudio = false;


    private void OnEnable()
    {
        Reset();      
    }

    // Update is called once per frame
    void Update () {

        Player.GetComponent<FirstPersonController>().enabled = false;
        // timer for minigame
        if (timerProgress >= 0.1)
        {
            timerProgress -= Time.deltaTime;
            timer.value = timerProgress;
        }
        else
        {
            CrowbarMiniGameFailed();
        }

        // run through arrow sliders until player completes minigame
        if (sliderOne.enabled)
        { 
            progress = sliderOne.value;

            if (progress >= 1.0f)
            {                
                sliderOne.gameObject.SetActive(false);
                sliderTwo.gameObject.SetActive(true);

                isPlayingAudio = true;

                if(isPlayingAudio == true)
                {
                    AudioManager.GetComponent<AudioManager>().Play("CrowbarTwo");
                    isPlayingAudio = false;
                }
            }
        }
        if (sliderTwo.enabled)
        {
                
            progress = sliderTwo.value;

            if (progress >= 1.0f)
            {
                sliderTwo.gameObject.SetActive(false);
                AudioManager.GetComponent<AudioManager>().Play("CrowbarTwo");
                sliderThree.gameObject.SetActive(true);

            }
        }
        if (sliderThree.enabled)
        {
                
            progress = sliderThree.value;

            if (progress >= 1.0f)
            {
                CrowbarMiniGameCompleted();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else
        {

        }
             
    }

    public void CrowbarMiniGameCompleted()
    {
        // complete minigame
        AudioManager.GetComponent<AudioManager>().Play("CrowbarTwo");
        CrowbarScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        PlayerRaycast.GetComponent<Raycast>().CrowbarCompletion();
    }

    public void CrowbarMiniGameFailed()
    {
        // fail minigame
        CrowbarScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        EventSystem.GetComponent<SupervisorOpinion>().ReduceOpinion(2);
    }

    public void Reset()
    {// reset minigame
        progress = 0f;
        sliderOne.value = 0;
        sliderTwo.value = 0;
        sliderThree.value = 0;
        timer.value = 5;
        timerProgress = 5;
        sliderOne.gameObject.SetActive(true);
        sliderTwo.gameObject.SetActive(false);
        sliderThree.gameObject.SetActive(false);
    }
}
