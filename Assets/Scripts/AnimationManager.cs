using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    public Animator animator;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WireBoxRise()
    {
        if(animator.gameObject.activeSelf)
        {
            animator.SetBool("IsActive", true);
        }
        
    }
}
