using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {

    [SerializeField]
    private GameObject GameOverScreen;

    [SerializeField]
    private GameObject DeathMessage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // fail level if player enters collider
            GameOverScreen.SetActive(true);
            DeathMessage.SetActive(true);

        }
        
    }

    
}
