using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupervisorHints : MonoBehaviour {

    [SerializeField]
    private GameObject EventSystem;

    private int levelProgression;

    [SerializeField]
    private int[] levelHints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GiveHint()
    {
        EventSystem.GetComponent<SupervisorOpinion>().ReduceOpinion(2);
        //int rand = Random.Range(0, levelHints.Length);

        levelProgression = EventSystem.GetComponent<LevelProgression>().progression;

        Debug.Log(levelHints[levelProgression]);

    }
}
