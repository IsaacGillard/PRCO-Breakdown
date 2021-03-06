﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewPanel : MonoBehaviour {

    public GameObject Panel;
    public GameObject[] Screws;
    public GameObject EventSystem;
    bool allInActive = true;

    void Update ()
    {
        for (int i = 0; i < Screws.Length; i++ )
        {
            // if all screws attached to panel have been removed, remove the panel
            if (Screws[i].activeInHierarchy)
            {
                allInActive = false;
                break;
            }
            else
            {
                allInActive = true;
            }
        }

        if (allInActive == true)
        {
            Panel.SetActive(false);
        }
    }
}
