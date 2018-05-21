using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // if the player is inside elevator, go to next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
