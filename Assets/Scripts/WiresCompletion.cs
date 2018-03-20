using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresCompletion : MonoBehaviour {

    [SerializeField]
    private GameObject Target;

    public GameObject brokenWires;
    public GameObject fixedWires;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Completion()
    {

        fixedWires.SetActive(true);
        brokenWires.SetActive(false);
        Target.SetActive(true);
        
    }
}
