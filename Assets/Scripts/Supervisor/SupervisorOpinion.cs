using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SupervisorOpinion : MonoBehaviour {

    [SerializeField]
    private Transform Player;

    public Slider OpinionMeter;

    [SerializeField]
    private GameObject EndGameScreen;

    [SerializeField]
    private GameObject OpinionMessage;

    private void Start()
    {
        Player.GetComponent<FirstPersonController>().enabled = true;
    }

    private void Update()
    {
        if (OpinionMeter.value <= 0)
        {
            FailLevel();
        }
    }

    public void ReduceOpinion(int amount)
    {
        OpinionMeter.value -= amount;
    }

    private void FailLevel()
    {
        // if opinion reaches zero, fail level
        EndGameScreen.SetActive(true);
        OpinionMessage.SetActive(true);
    }

	
}
