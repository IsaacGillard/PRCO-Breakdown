using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ScrewMiniGame : MonoBehaviour {

    public Transform Player;
    public Transform PlayerRaycast;
    public Slider slider;
    private float progress = 0;
    public GameObject ScrewScreen;


    // Use this for initialization
    void Start () {
        //ResetSlider();
	}
	
	// Update is called once per frame
	void Update () {

        if (ScrewScreen.activeInHierarchy)
        {
            Player.GetComponent<FirstPersonController>().enabled = false;
            slider.value = progress;

            if (Input.GetKeyDown("f"))
            {
                 
                progress += 0.1f;
                slider.value = progress;
                Debug.Log(progress);
            }
            if (progress > 0)
            {
                progress -= Time.deltaTime / 3;
                if (progress <= 0.01f)
                {
                    //ResetSlider();
                    ScrewMiniGameFailed();
                }
            }
            if (progress >= 1.0f)
            {

                ResetSlider();
                progress = 0.0f;
                ScrewMiniGameCompleted();
                

            }
            if (Input.GetKeyDown("r"))
            {
                //ResetSlider();
                ScrewMiniGameFailed();
            }
        }
        else
        {

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
