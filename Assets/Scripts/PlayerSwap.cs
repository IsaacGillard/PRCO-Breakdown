using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSwap : MonoBehaviour {

    public GameObject[] characters;
    private GameObject currentCharacter;
    private Transform SupervisorLocation;
    int CharactersIndex;

    public GameObject robotMesh;

	// Use this for initialization
	void Start () {
        CharactersIndex = 0;
        currentCharacter = characters[0];
        SupervisorLocation = characters[1].transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (characters[0].activeInHierarchy)
        {
            robotMesh.SetActive(true);
        }
        else
        {
            robotMesh.SetActive(false);
        }
        //if (Input.GetKeyDown("k"))
        //{
        //    SwapPlayer();
        //}
	}

    public void SwapPlayer()
    {
        Debug.Log("Woop");
        CharactersIndex++;
        if (CharactersIndex == characters.Length)
        {
            
            CharactersIndex = 0;
        }

        currentCharacter.SetActive(false);
        characters[CharactersIndex].SetActive(true);
        currentCharacter = characters[CharactersIndex];
    }
}
