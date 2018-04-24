using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour {

    public GameObject LifeOne;
    public GameObject LifeTwo;
    public GameObject LifeThree;

    private int lives;

    // Use this for initialization
    void Start () {

        lives = 3;
        LifeOne.SetActive(true);
        LifeTwo.SetActive(true);
        LifeThree.SetActive(true);

    }

    // Update is called once per frame
    void Update ()
    {

        if(lives == 2)
        {
            LifeThree.SetActive(false);
        }
        else if(lives == 1)
        {
            LifeTwo.SetActive(false);
        }
        else if (lives == 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {

        }
		
	}

    public void ReduceLife()
    {
        lives -= 1;
    }
}
