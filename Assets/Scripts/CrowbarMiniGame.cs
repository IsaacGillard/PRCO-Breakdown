using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class CrowbarMiniGame : MonoBehaviour {
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


    private void OnEnable()
    {
        Reset();      
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
            CrowbarMiniGameFailed();
        }


        if (sliderOne.enabled)
            {
                progress = sliderOne.value;

                if (progress >= 1.0f)
                {
                    sliderOne.gameObject.SetActive(false);
                    sliderTwo.gameObject.SetActive(true);
                }
            }
            if (sliderTwo.enabled)
            {
                progress = sliderTwo.value;

                if (progress >= 1.0f)
                {
                    sliderTwo.gameObject.SetActive(false);
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
        CrowbarScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        PlayerRaycast.GetComponent<Raycast>().CrowbarCompletion();
    }

    public void CrowbarMiniGameFailed()
    {
        CrowbarScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        UserInterface.GetComponent<PlayerLives>().ReduceLife();
    }

    public void Reset()
    {
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
