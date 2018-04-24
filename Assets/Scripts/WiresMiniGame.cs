using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class WiresMiniGame : MonoBehaviour {

    
    //public GameObject Target;
    public GameObject WiresScreen;
    public Transform Player;
    public GameObject PlayerRaycast;
    public GameObject UserInterface;
    public Slider timer;
    private float timerProgress = 5;

    [SerializeField]
    private int brokenWire = 0;

    // Use this for initialization
    void Start () {
        
        Debug.Log("Start | brokenwire: " + brokenWire.ToString());
    }

    private void OnEnable()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        Reset();
    }

    // Update is called once per frame
    void Update () {

        brokenWire = PlayerRaycast.GetComponent<Raycast>().brokenWire;

        if (timerProgress >= 0.1)
        {
            timerProgress -= Time.deltaTime;
            timer.value = timerProgress;
        }
        else
        {
            WiresMiniGameFailed();
        }

        if (Input.GetKeyDown("r"))
        {
            Debug.Log("Update | brokenwire: " + brokenWire.ToString());
            if (brokenWire == 0)
            {
                WiresMiniGameCompleted();
            }
            else
            {
                WiresMiniGameFailed();
            }
        }
        else if  (Input.GetKeyDown("g"))
        {
            Debug.Log("Update | brokenwire: " + brokenWire.ToString());
            if (brokenWire == 1)
            {
                WiresMiniGameCompleted();
            }
            else
            {
                WiresMiniGameFailed();
            }
        }
        else if (Input.GetKeyDown("b"))
        {
            Debug.Log("Update | brokenwire: " + brokenWire.ToString());
            if (brokenWire == 2)
            {
                WiresMiniGameCompleted();
            }
            else
            {
                WiresMiniGameFailed();
            }
        }
    }

    private void Reset()
    {
        timerProgress = 5;
        timer.value = 5;
    }

    public void WiresMiniGameCompleted()
    {
        
        WiresScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        PlayerRaycast.GetComponent<Raycast>().WiresSwitch();
    }

    public void WiresMiniGameFailed()
    {
        WiresScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        UserInterface.GetComponent<PlayerLives>().ReduceLife();
    }
}
