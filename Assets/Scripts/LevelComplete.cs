using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public GameObject ElevatorLeftDoor;
    public GameObject ElevatorRightDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OpenElevator()
    {
        ElevatorLeftDoor.SetActive(false);
        ElevatorRightDoor.SetActive(false);
    }
}
