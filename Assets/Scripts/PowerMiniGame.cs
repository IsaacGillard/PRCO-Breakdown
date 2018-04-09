using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PowerMiniGame : MonoBehaviour {

    public Transform Player;

    public GameObject miniGameScreen;
    public GameObject Elevator;

    public Slider columnOne;
    public Slider columnTwo;
    public Slider columnThree;

    private int currentSlider;
    public float energyValue;
    private int direction;

	// Use this for initialization
	void Start () {
        RestartGame();
    }

    private void OnEnable()
    {
        RestartGame();
    }

    // Update is called once per frame
    void Update () {

        if(currentSlider == 1)
        {
            if(direction ==1)
            {
                energyValue += Time.deltaTime;
                columnOne.value = energyValue;
                if(energyValue >= 1)
                {
                    direction = 2;
                }
            }
            if (direction == 2)
            {
                energyValue -= Time.deltaTime;
                columnOne.value = energyValue;
                if (energyValue <= 0)
                {
                    direction = 1;
                }
            }
        }
        if (currentSlider == 2)
        {
            if (direction == 1)
            {
                energyValue += Time.deltaTime * 2;
                columnTwo.value = energyValue;
                if (energyValue >= 1)
                {
                    direction = 2;
                }
            }
            if (direction == 2)
            {
                energyValue -= Time.deltaTime * 2;
                columnTwo.value = energyValue;
                if (energyValue <= 0)
                {
                    direction = 1;
                }
            }

        }
        if (currentSlider == 3)
        {
            if (direction == 1)
            {
                energyValue += Time.deltaTime * 3;
                columnThree.value = energyValue;
                if (energyValue >= 1)
                {
                    direction = 2;
                }
            }
            if (direction == 2)
            {
                energyValue -= Time.deltaTime * 3;
                columnThree.value = energyValue;
                if (energyValue <= 0)
                {
                    direction = 1;
                }
            }

        }

        if(currentSlider == 4)
        {
            Elevator.GetComponent<LevelComplete>().OpenElevator();
            Player.GetComponent<FirstPersonController>().enabled = true;
            miniGameScreen.SetActive(false);
            
            Debug.Log("Huzzah");
        }

        if (Input.GetKeyDown("e"))
        {
            if(energyValue <= 0.55 && energyValue >= 0.45)
            {
                currentSlider++;
                Debug.Log(columnOne.value);
            }
            else
            {
                RestartGame();
            }
        }
		
	}

    public void RestartGame()
    {
        currentSlider = 1;
        energyValue = 0;
        columnOne.value = 0;
        columnTwo.value = 0;
        columnThree.value = 0;
        direction = 1;
    }
}
