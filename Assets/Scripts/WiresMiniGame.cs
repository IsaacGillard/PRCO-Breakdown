using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class WiresMiniGame : MonoBehaviour {

    
    public GameObject Target;
    public GameObject WiresScreen;
    public Transform Player;
    public GameObject PlayerRaycast;

    [SerializeField]
    private int brokenWire = 0;

    // Use this for initialization
    void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {

        if( brokenWire == 0)
        {
            if (Input.GetKeyDown("r"))
            {               
                WiresMiniGameCompleted();
                
            }
            if (Input.GetKeyDown("g") || Input.GetKeyDown("b"))
            {
                WiresMiniGameFailed();
            }
        }
        else if (brokenWire == 1)
        {
            if (Input.GetKeyDown("g"))
            {
                WiresMiniGameCompleted();
                
            }
            if (Input.GetKeyDown("r") || Input.GetKeyDown("b"))
            {
                WiresMiniGameFailed();
            }
        }
        else if (brokenWire == 2)
        {
            if (Input.GetKeyDown("b"))
            {
                WiresMiniGameCompleted();
                
            }
            if (Input.GetKeyDown("r") || Input.GetKeyDown("g"))
            {
                WiresMiniGameFailed();
            }
        }
        else if (brokenWire == 3)
        {
            if (Input.GetKeyDown("b") || Input.GetKeyDown("r") || Input.GetKeyDown("g")) 
            {
                WiresMiniGameFailed();
            }
            
        }
        
    }

    public void WiresMiniGameCompleted()
    {
        
        WiresScreen.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        PlayerRaycast.GetComponent<Raycast>().WiresCompletion();
    }

    public void WiresMiniGameFailed()
    {
        SceneManager.LoadScene(0);
    }
}
