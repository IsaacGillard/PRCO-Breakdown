using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerColumn : MonoBehaviour {

    [SerializeField]
    private GameObject AudioManager;

    // Use this for initialization
    void Start () {
        AudioManager.GetComponent<AudioManager>().Play("PowerColumn");
    }
	
}
