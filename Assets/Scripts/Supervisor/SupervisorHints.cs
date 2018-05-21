using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupervisorHints : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    private int levelProgression;

    [SerializeField]
    private int[] levelHints;

    public GameObject AudioManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GiveHint()
    {
        EventSystem.GetComponent<SupervisorOpinion>().ReduceOpinion(2);
 
        // depending on level progression, play the appropriate hint
        levelProgression = EventSystem.GetComponent<LevelProgression>().progression;

        if(levelProgression == 0)
        {
            AudioManager.GetComponent<AudioManager>().Play("HintOne");
        }
        else if (levelProgression == 1)
        {
            AudioManager.GetComponent<AudioManager>().Play("HintTwo");
        }
        else if (levelProgression == 2)
        {
            AudioManager.GetComponent<AudioManager>().Play("HintThree");
        }


    }
}
