using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarMiniGameCompletion : MonoBehaviour {

    [SerializeField]
    private int ObjectType;

    [SerializeField]
    private GameObject Target;

    [SerializeField]
    private GameObject TargetB;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Completion()
    {
        if (ObjectType == 0)
        {
            this.Target.SetActive(false);
        }
        else if (ObjectType == 1)
        {
            Debug.Log("Success");
            this.Target.SetActive(false);
            this.TargetB.SetActive(true);
        }
        else if (ObjectType == 2)
        {
            Target.GetComponent<LeverTimer>().Open();
        }
    }
}
