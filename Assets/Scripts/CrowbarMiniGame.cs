using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowbarMiniGame : MonoBehaviour {

    float timeLeft;

    public GameObject LeftDoor;
    public GameObject RightDoor;
    public Transform Player;
    public Slider sliderOne;
    public Slider sliderTwo;
    public Slider sliderThree;
    public Slider timer;
    private float progress = 0;
    public GameObject CrowbarScreen;
    public Slider[] sliders;
    int arrayPos = 0;

    void Start()
    {
        sliderOne.gameObject.SetActive(true);
        sliderTwo.gameObject.SetActive(false);
        sliderThree.gameObject.SetActive(false);

        timer.value = 5;
        timeLeft = 5;
    }


    // Update is called once per frame
    void Update () {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if( timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timer.value = timeLeft;
        }
        else
        {
            timer.value = 5;
            timeLeft = 5;
            sliderOne.gameObject.SetActive(true);
            sliderTwo.gameObject.SetActive(false);
            sliderThree.gameObject.SetActive(false);
            Player.GetComponent<Raycast>().CrowbarMiniGameFailed();
        }

        for (int i = 0; i < sliders.Length; i++)
        {

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
                LeftDoor.SetActive(false);
                RightDoor.SetActive(false);
                Player.GetComponent<Raycast>().CrowbarMiniGameCompleted();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }  
}
