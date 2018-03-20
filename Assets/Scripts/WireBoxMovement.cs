using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBoxMovement : MonoBehaviour {

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform positionB;


    // Use this for initialization
    void Start () {

        posA = childTransform.localPosition;
        posB = positionB.localPosition;
        nextPos = posB;
		
	}
	 
	// Update is called once per frame
	void Update () {
        
	}

    public void MoveUp()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
    }

    public void Print()
    {
        Debug.Log("banter");
    }
}
