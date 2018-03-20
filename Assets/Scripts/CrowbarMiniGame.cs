using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class CrowbarMiniGame : MonoBehaviour {

    [SerializeField]
    private int ObjectType = 0;

    float timeLeft;

    

    public Transform Player;
    public GameObject PlayerRaycast;
    public Slider sliderOne;
    public Slider sliderTwo;
    public Slider sliderThree;
    public Slider timer;
    private float progress = 0;
    public GameObject CrowbarScreen;

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

        if (CrowbarScreen.activeInHierarchy)
        {
            if (timeLeft > 0)
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
                    
                    //Target.SetActive(false);
                    CrowbarMiniGameCompleted();
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            else
            {

            }
        }       
    }

    public void CrowbarMiniGameCompleted()
    {
        progress = 0.0f;
        CrowbarScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        PlayerRaycast.GetComponent<Raycast>().CrowbarCompletion();
        
        


    }
    public void CrowbarMiniGameFailed()
    {
        CrowbarScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;

    }

    public void ResetSlider()
    {
        progress = 0f;
        sliderOne.value = 0;
        sliderTwo.value = 0;
        sliderThree.value = 0;
        timer.value = 5;
        sliderOne.gameObject.SetActive(true);
        sliderTwo.gameObject.SetActive(false);
        sliderThree.gameObject.SetActive(false);
    }
}
