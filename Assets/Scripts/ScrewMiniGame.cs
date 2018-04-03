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
    private int alternator = 0;


    // Use this for initialization
    void Start () {
        //ResetSlider();
	}
	
	// Update is called once per frame
	void Update () {

        if (ScrewScreen.activeInHierarchy)
        {
            //Player.GetComponent<FirstPersonController>().enabled = false;
            //slider.value = progress;

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
                }
            }
            if (progress >= 3)
            {
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

    //public void ScrewGame()
    //{
        
    //        Player.GetComponent<FirstPersonController>().enabled = false;
    //        //slider.value = progress;

    //        if (Input.GetKeyDown("f") && alternator == 0)
    //        {
    //            alternator = 1;
    //            progress += 0.1f;
    //            slider.value = progress;
    //            Debug.Log("1");
    //        }
    //        if (Input.GetKeyDown("f") && alternator == 1)
    //        {
    //            ResetSlider();
    //        Debug.Log("2");
    //    }
    //        if (Input.GetKeyDown("g") && alternator == 1)
    //        {
    //            alternator = 0;
    //            progress += 0.1f;
    //            slider.value = progress;
    //            Debug.Log(progress);
    //        Debug.Log("3");
    //    }
    //        if (Input.GetKeyDown("g") && alternator == 0)
    //        {
    //            ResetSlider();
    //        Debug.Log("4");
    //    }
    //        if (progress >= 1)
    //        {
    //            ScrewMiniGameCompleted();
    //        }
    //        if (Input.GetKeyDown("r"))
    //        {
    //            //ResetSlider();
    //            ScrewMiniGameFailed();
    //        }
    //}

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
